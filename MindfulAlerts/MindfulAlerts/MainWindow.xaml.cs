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

        public MainWindow()
        {
            InitializeComponent();

            ThemePicker.ItemsSource = OverlayTheme.All.Select(t => t.Name).ToArray();
            ThemePicker.SelectedIndex = 0;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(IntervalBox.Text.Trim(), out _intervalMinutes) || _intervalMinutes < 0.5)
            {
                ValidationText.Text = "Please enter a number ≥ 0.5 minutes (e.g. 0.5, 1, 5).";
                ValidationText.Visibility = Visibility.Visible;
                return;
            }

            ValidationText.Visibility = Visibility.Collapsed;

            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;
            IntervalBox.IsEnabled = false;

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

            StatusText.Text = "Status: Stopped";
            CountdownText.Visibility = Visibility.Collapsed;
        }

        private void AlertTimer_Tick(object? sender, EventArgs e)
        {
            _secondsRemaining = (int)Math.Round(_intervalMinutes * 60);
            var theme = OverlayTheme.All[ThemePicker.SelectedIndex];
            var overlay = new AlertOverlay(theme);
            overlay.Show();
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
        }
    }
}
