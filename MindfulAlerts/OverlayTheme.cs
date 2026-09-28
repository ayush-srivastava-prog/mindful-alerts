using System.Windows.Media;

namespace MindfulAlerts
{
    public class OverlayTheme
    {
        public string Name { get; init; } = "";
        public Color CardBackground { get; init; }
        public Color BorderColor { get; init; }
        public Color HeaderForeground { get; init; }
        public Color MessageForeground { get; init; }
        public Color ButtonBackground { get; init; }
        public Color ButtonForeground { get; init; } = Colors.White;
        public double WindowOpacity { get; init; } = 0.88;

        public static readonly OverlayTheme[] All =
        [
            new()
            {
                Name = "🌿 Green (Default)",
                CardBackground  = Color.FromArgb(0xCC, 0xEE, 0xF7, 0xEE),
                BorderColor     = Color.FromArgb(0x88, 0x4C, 0xAF, 0x50),
                HeaderForeground  = Color.FromRgb(0x2E, 0x7D, 0x32),
                MessageForeground = Color.FromRgb(0x33, 0x33, 0x33),
                ButtonBackground  = Color.FromRgb(0x4C, 0xAF, 0x50),
                WindowOpacity = 0.88,
            },
            new()
            {
                Name = "🔵 Blue",
                CardBackground  = Color.FromArgb(0xCC, 0xE3, 0xF2, 0xFD),
                BorderColor     = Color.FromArgb(0x88, 0x19, 0x76, 0xD2),
                HeaderForeground  = Color.FromRgb(0x0D, 0x47, 0xA1),
                MessageForeground = Color.FromRgb(0x1A, 0x1A, 0x2E),
                ButtonBackground  = Color.FromRgb(0x19, 0x76, 0xD2),
                WindowOpacity = 0.88,
            },
            new()
            {
                Name = "🔴 Red",
                CardBackground  = Color.FromArgb(0xCC, 0xFF, 0xEB, 0xEE),
                BorderColor     = Color.FromArgb(0x88, 0xC6, 0x28, 0x28),
                HeaderForeground  = Color.FromRgb(0xB7, 0x1C, 0x1C),
                MessageForeground = Color.FromRgb(0x33, 0x33, 0x33),
                ButtonBackground  = Color.FromRgb(0xC6, 0x28, 0x28),
                WindowOpacity = 0.88,
            },
            new()
            {
                Name = "🟡 Yellow",
                CardBackground  = Color.FromArgb(0xCC, 0xFF, 0xFD, 0xE7),
                BorderColor     = Color.FromArgb(0x88, 0xF9, 0xA8, 0x25),
                HeaderForeground  = Color.FromRgb(0xE6, 0x5C, 0x00),
                MessageForeground = Color.FromRgb(0x33, 0x2B, 0x00),
                ButtonBackground  = Color.FromRgb(0xF9, 0xA8, 0x25),
                WindowOpacity = 0.88,
            },
            new()
            {
                Name = "🟣 Purple",
                CardBackground  = Color.FromArgb(0xCC, 0xF3, 0xE5, 0xF5),
                BorderColor     = Color.FromArgb(0x88, 0x7B, 0x1F, 0xA2),
                HeaderForeground  = Color.FromRgb(0x4A, 0x14, 0x8C),
                MessageForeground = Color.FromRgb(0x33, 0x33, 0x33),
                ButtonBackground  = Color.FromRgb(0x7B, 0x1F, 0xA2),
                WindowOpacity = 0.88,
            },
            new()
            {
                Name = "🪟 Glass (Dark bg)",
                CardBackground  = Color.FromArgb(0x99, 0xFF, 0xFF, 0xFF),
                BorderColor     = Color.FromArgb(0xCC, 0xFF, 0xFF, 0xFF),
                HeaderForeground  = Color.FromRgb(0xFF, 0xFF, 0xFF),
                MessageForeground = Color.FromRgb(0xF0, 0xF0, 0xF0),
                ButtonBackground  = Color.FromArgb(0xBB, 0xFF, 0xFF, 0xFF),
                WindowOpacity = 0.92,
            },
            new()
            {
                Name = "🪟 Glass (Light bg)",
                CardBackground    = Color.FromArgb(0x44, 0x00, 0x00, 0x00),
                BorderColor       = Color.FromArgb(0x55, 0x44, 0x44, 0x44),
                HeaderForeground  = Color.FromRgb(0x11, 0x11, 0x11),
                MessageForeground = Color.FromRgb(0x22, 0x22, 0x22),
                ButtonBackground  = Color.FromArgb(0x88, 0x33, 0x33, 0x33),
                ButtonForeground  = Colors.White,
                WindowOpacity = 0.82,
            },
            new()
            {
                Name = "🤖 J.A.R.V.I.S.",
                CardBackground    = Color.FromArgb(0xCC, 0x00, 0x0A, 0x14),
                BorderColor       = Color.FromArgb(0xFF, 0x00, 0xB8, 0xFF),
                HeaderForeground  = Color.FromRgb(0x00, 0xE5, 0xFF),
                MessageForeground = Color.FromRgb(0x80, 0xD8, 0xFF),
                ButtonBackground  = Color.FromRgb(0x00, 0x6E, 0xA6),
                ButtonForeground  = Color.FromRgb(0x00, 0xE5, 0xFF),
                WindowOpacity = 0.95,
            },
        ];
    }
}
