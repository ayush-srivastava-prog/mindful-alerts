using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace MindfulAlerts
{
    public partial class AlertOverlay : Window
    {
        private static readonly string[] Messages =
        [
            "Take a deep breath. Are you fully present right now?",
            "Be here now!",
            "Check in with yourself. Body, mind, and breath.",
            "You are more than a passive observer. Stay aware.",
            "Gently bring your attention back to the present.",
            "How is your posture? Relax your shoulders and keep your back straight.",
            "Focus on the present. You are here, right now.",
        ];

        private readonly DispatcherTimer? _autoDismissTimer;
        private int _secondsLeft;

        public AlertOverlay(OverlayTheme theme, bool autoDismiss, int autoDismissSeconds)
        {
            InitializeComponent();
            ApplyTheme(theme);

            var rng = new Random();
            MessageText.Text = Messages[rng.Next(Messages.Length)];

            PlaceRandomly(rng);

            if (autoDismiss)
            {
                _secondsLeft = autoDismissSeconds;
                _autoDismissTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
                _autoDismissTimer.Tick += AutoDismiss_Tick;
                _autoDismissTimer.Start();
                UpdateDismissLabel();
            }
            else
            {
                DismissCountdown.Visibility = Visibility.Collapsed;
            }
        }

        private void PlaceRandomly(Random rng)
        {
            var area = SystemParameters.WorkArea;

            var maxLeft = Math.Max(0, area.Width - Width);
            var maxTop = Math.Max(0, area.Height - Height);

            Left = area.Left + rng.NextDouble() * maxLeft;
            Top = area.Top + rng.NextDouble() * maxTop;
        }

        private void ApplyTheme(OverlayTheme theme)
        {
            Opacity = theme.WindowOpacity;
            CardBorder.Background = new SolidColorBrush(theme.CardBackground);
            CardBorder.BorderBrush = new SolidColorBrush(theme.BorderColor);
            HeaderText.Foreground = new SolidColorBrush(theme.HeaderForeground);
            MessageText.Foreground = new SolidColorBrush(theme.MessageForeground);
            DismissCountdown.Foreground = new SolidColorBrush(theme.MessageForeground);
            DismissButton.Background = new SolidColorBrush(theme.ButtonBackground);
            DismissButton.Foreground = new SolidColorBrush(theme.ButtonForeground);
        }

        private void AutoDismiss_Tick(object? sender, EventArgs e)
        {
            _secondsLeft--;
            UpdateDismissLabel();

            if (_secondsLeft <= 0)
                CloseOverlay();
        }

        private void UpdateDismissLabel()
        {
            DismissCountdown.Text = $"Auto-dismissing in {_secondsLeft}s";
        }

        private void Dismiss_Click(object sender, RoutedEventArgs e) => CloseOverlay();

        private void CloseOverlay()
        {
            _autoDismissTimer?.Stop();
            Close();
        }
    }
}
