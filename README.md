# 🧘 Mindful Alerts

A lightweight desktop app that gently reminds you to stay present while doing passive activities like watching videos, listening to audio, or reading — by popping up a mindfulness overlay at a configurable interval.

## Features

- **Configurable reminder interval** — set any interval down to 0.5 minutes.
- **Start / Stop control** — start reminders when you're ready, stop them anytime.
- **Live countdown** — see exactly when the next reminder will appear.
- **Always-on-top overlay** — a translucent popup with a random mindfulness prompt appears over whatever you're doing.
- **Auto-dismiss** — the overlay closes itself after 15 seconds, or you can dismiss it immediately with a click.
- **Multiple overlay themes** — choose the look of your reminder popup:
  - 🌿 Green (Default)
  - 🔵 Blue
  - 🔴 Red
  - 🟡 Yellow
  - 🟣 Purple
  - 🪟 Glass (Dark bg) / 🪟 Glass (Light bg) — semi-transparent glass styles
  - 🤖 J.A.R.V.I.S. — Iron Man HUD-inspired cyan-on-navy theme
- **Modern resizable UI** — clean card-based layout with a custom styled dropdown and interval input.

## Requirements

- **OS:** Windows 10 or later (Windows 11 recommended)
- **Runtime:** [.NET 10 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/10.0) (only required if not using a self-contained build)
- **Build tools:** Visual Studio 2022+ / 2026 with the ".NET Desktop Development" workload, or the .NET 10 SDK

## Usage

1. Enter the number of minutes between reminders (minimum `0.5`).
2. Pick an overlay theme from the dropdown.
3. Click **▶ Start** — the countdown begins immediately.
4. When the interval elapses, a themed mindfulness overlay appears on top of your screen.
   - Click **"I'm aware ✓"** to dismiss it, or let it auto-close after 15 seconds.
5. Click **■ Stop** at any time to end the reminder session.

## Project Structure

| File | Purpose |
|---|---|
| `MainWindow.xaml` / `.xaml.cs` | Main control panel — interval input, theme picker, start/stop, status/countdown |
| `AlertOverlay.xaml` / `.xaml.cs` | The topmost mindfulness popup shown at each interval |
| `OverlayTheme.cs` | Defines all available overlay color themes |

## License

This project is intended for personal use. Add a license of your choice if distributing publicly.
