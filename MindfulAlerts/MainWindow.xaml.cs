using System.Windows;
using System.Windows.Threading;

namespace MindfulAlerts
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer? _alertTimer;
        private DispatcherTimer? _countdownTimer;
        private double _intervalMinutes;
        private int _secondsRemaining;
        private bool _autoDismiss = true;
        private int _autoDismissSeconds = 15;
        private bool _randomTheme;
        private readonly Random _rng = new();
        private AlertOverlay? _activeOverlay;

        public MainWindow()
        {
            InitializeComponent();

            ThemePicker.ItemsSource = OverlayTheme.All.Select(t => t.Name).ToArray();
            ThemePicker.SelectedIndex = 0;

            var settings = AppSettings.Load();
            IntervalBox.Text = settings.IntervalMinutes.ToString();
            DismissSecondsBox.Text = settings.AutoDismissSeconds.ToString();
            AutoDismissCheck.IsChecked = settings.AutoDismiss;
            AutoDismissCheck_Changed(this, new RoutedEventArgs());

            RandomThemeCheck.IsChecked = settings.RandomTheme;
            RandomThemeCheck_Changed(this, new RoutedEventArgs());
        }

        private void AutoDismissCheck_Changed(object sender, RoutedEventArgs e)
        {
            if (AutoDismissPanel is null || ManualDismissHint is null)
                return;

            var enabled = AutoDismissCheck.IsChecked == true;
            AutoDismissPanel.Visibility = enabled ? Visibility.Visible : Visibility.Collapsed;
            ManualDismissHint.Visibility = enabled ? Visibility.Collapsed : Visibility.Visible;
        }

        private void RandomThemeCheck_Changed(object sender, RoutedEventArgs e)
        {
            if (ThemePicker is null)
                return;

            _randomTheme = RandomThemeCheck.IsChecked == true;
            ThemePicker.IsEnabled = !_randomTheme;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(IntervalBox.Text.Trim(), out _intervalMinutes) || _intervalMinutes < 0.5)
            {
                ValidationText.Text = "Please enter a number ≥ 0.5 minutes (e.g. 0.5, 1, 5).";
                ValidationText.Visibility = Visibility.Visible;
                return;
            }

            _autoDismiss = AutoDismissCheck.IsChecked == true;
            if (_autoDismiss &&
                (!int.TryParse(DismissSecondsBox.Text.Trim(), out _autoDismissSeconds) || _autoDismissSeconds < 1))
            {
                ValidationText.Text = "Auto-dismiss seconds must be a whole number ≥ 1.";
                ValidationText.Visibility = Visibility.Visible;
                return;
            }

            ValidationText.Visibility = Visibility.Collapsed;

            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;
            IntervalBox.IsEnabled = false;
            AutoDismissCheck.IsEnabled = false;
            DismissSecondsBox.IsEnabled = false;
            RandomThemeCheck.IsEnabled = false;

            _secondsRemaining = (int)Math.Round(_intervalMinutes * 60);
            UpdateCountdown();
            CountdownText.Visibility = Visibility.Visible;
            StatusText.Text = "Status: Running";

            _alertTimer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(_intervalMinutes) };
            _alertTimer.Tick += AlertTimer_Tick;
            _alertTimer.Start();

            _countdownTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _countdownTimer.Tick += CountdownTimer_Tick;
            _countdownTimer.Start();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            StopTimers();

            StartButton.IsEnabled = true;
            StopButton.IsEnabled = false;
            IntervalBox.IsEnabled = true;
            AutoDismissCheck.IsEnabled = true;
            DismissSecondsBox.IsEnabled = true;
            RandomThemeCheck.IsEnabled = true;

            StatusText.Text = "Status: Stopped";
            CountdownText.Visibility = Visibility.Collapsed;
        }

        private void AlertTimer_Tick(object? sender, EventArgs e)
        {
            if (_activeOverlay is not null)
                return;

            // Pause the schedule while the reminder is on screen so only one
            // overlay is ever shown; the interval restarts once it is dismissed.
            _alertTimer?.Stop();
            _countdownTimer?.Stop();
            CountdownText.Text = "Reminder showing…";

            var theme = _randomTheme
                ? OverlayTheme.All[_rng.Next(OverlayTheme.All.Length)]
                : OverlayTheme.All[ThemePicker.SelectedIndex];
            _activeOverlay = new AlertOverlay(theme, _autoDismiss, _autoDismissSeconds);
            _activeOverlay.Closed += Overlay_Closed;
            _activeOverlay.Show();
        }

        private void Overlay_Closed(object? sender, EventArgs e)
        {
            _activeOverlay = null;

            // Only resume if the session is still running.
            if (_alertTimer is null || _countdownTimer is null)
                return;

            _secondsRemaining = (int)Math.Round(_intervalMinutes * 60);
            UpdateCountdown();
            _alertTimer.Start();
            _countdownTimer.Start();
        }

        private void CountdownTimer_Tick(object? sender, EventArgs e)
        {
            if (_secondsRemaining > 0)
                _secondsRemaining--;

            UpdateCountdown();
        }

        private void UpdateCountdown()
        {
            var ts = TimeSpan.FromSeconds(_secondsRemaining);
            CountdownText.Text = $"Next alert in: {ts:mm\\:ss}";
        }

        private void StopTimers()
        {
            _alertTimer?.Stop();
            _alertTimer = null;
            _countdownTimer?.Stop();
            _countdownTimer = null;

            if (_activeOverlay is not null)
            {
                _activeOverlay.Closed -= Overlay_Closed;
                _activeOverlay.Close();
                _activeOverlay = null;
            }
        }
    }
}
