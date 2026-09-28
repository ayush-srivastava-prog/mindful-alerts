using System.IO;
using System.Text.Json;

namespace MindfulAlerts
{
    public class AppSettings
    {
        public double IntervalMinutes { get; set; } = 5;
        public bool AutoDismiss { get; set; } = true;
        public int AutoDismissSeconds { get; set; } = 15;
        public bool RandomTheme { get; set; }

        private const string FileName = "appsettings.json";

        private static string FilePath =>
            Path.Combine(AppContext.BaseDirectory, FileName);

        public static AppSettings Load()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    var json = File.ReadAllText(FilePath);
                    var settings = JsonSerializer.Deserialize<AppSettings>(json);
                    if (settings is not null)
                        return settings.Validated();
                }
            }
            catch (Exception)
            {
                // Fall back to defaults if the file is missing or malformed.
            }

            return new AppSettings();
        }

        private AppSettings Validated()
        {
            if (IntervalMinutes < 0.5)
                IntervalMinutes = 0.5;

            if (AutoDismissSeconds < 1)
                AutoDismissSeconds = 1;

            return this;
        }
    }
}
