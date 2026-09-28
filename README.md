# 🧘 Mindful Alerts

A lightweight desktop app that gently reminds you to stay present while doing passive activities like watching videos, listening to audio, or reading — by popping up a mindfulness overlay at a configurable interval.

## Features

- **Configurable reminder interval** — set any interval down to 0.5 minutes.
- **Start / Stop control** — start reminders when you're ready, stop them anytime.
- **Live countdown** — see exactly when the next reminder will appear.
- **Always-on-top overlay** — a translucent popup with a random mindfulness prompt appears over whatever you're doing.
- **Random screen position** — each reminder appears at a different spot on screen, so it never becomes easy to ignore.
- **Flexible dismissal** — either let the overlay close itself after a configurable number of seconds, or turn auto-dismiss off so it waits until you click **"I'm aware ✓"**.
- **One reminder at a time** — the interval pauses while a reminder is on screen and restarts only after it is dismissed.
- **Settings loaded from a config file** — defaults come from `appsettings.json`, editable without rebuilding.
- **Multiple overlay themes** — choose the look of your reminder popup:
  - 🌿 Green (Default)
  - 🔵 Blue
  - 🔴 Red
  - 🟡 Yellow
  - 🟣 Purple
  - 🪟 Glass (Dark bg) / 🪟 Glass (Light bg) — semi-transparent glass styles
  - 🤖 J.A.R.V.I.S. — Iron Man HUD-inspired cyan-on-navy theme
- **Random theme mode** — optionally shuffle to a different theme on every reminder.
- **Modern resizable UI** — clean card-based layout with a custom styled dropdown and inputs.

## Requirements

- **OS:** Windows 10 or later (Windows 11 recommended)
- **Runtime:** [.NET 10 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/10.0) (only required if not using a self-contained build)
- **Build tools:** Visual Studio 2022+ / 2026 with the ".NET Desktop Development" workload, or the .NET 10 SDK

## Usage

1. Enter the number of minutes between reminders (minimum `0.5`).
2. Choose how the reminder should close:
   - Leave **"Close the reminder automatically"** checked and set the number of seconds (minimum `1`), or
   - Uncheck it so the reminder stays until you dismiss it yourself.
3. Pick an overlay theme, or check **"Use a random theme for each reminder"** to shuffle.
4. Click **▶ Start** — the countdown begins immediately.
5. When the interval elapses, a themed mindfulness overlay appears at a random position on screen.
   - Click **"I'm aware ✓"** to dismiss it, or let it auto-close if auto-dismiss is enabled.
   - The next interval starts counting once the reminder is dismissed.
6. Click **■ Stop** at any time to end the reminder session.

## Configuration

Startup defaults are read from `appsettings.json`, which is copied next to the executable on build:

```json
{
  "IntervalMinutes": 0.5,
  "AutoDismiss": true,
  "AutoDismissSeconds": 15,
  "RandomTheme": false
}
```

| Setting | Description |
|---|---|
| `IntervalMinutes` | Minutes between reminders (clamped to a minimum of `0.5`) |
| `AutoDismiss` | Whether the overlay closes itself automatically |
| `AutoDismissSeconds` | Seconds before auto-dismiss (clamped to a minimum of `1`) |
| `RandomTheme` | Whether to pick a random theme for each reminder |

Values can still be changed in the UI at runtime. If the file is missing or malformed, built-in defaults are used.

## Project Structure

| File | Purpose |
|---|---|
| `MainWindow.xaml` / `.xaml.cs` | Main control panel — interval, dismissal and theme options, start/stop, status/countdown |
| `AlertOverlay.xaml` / `.xaml.cs` | The topmost mindfulness popup shown at each interval |
| `OverlayTheme.cs` | Defines all available overlay color themes |
| `AppSettings.cs` | Loads and validates settings from `appsettings.json` |
| `appsettings.json` | User-editable startup defaults |

## License

This project is intended for personal use. Add a license of your choice if distributing publicly.
