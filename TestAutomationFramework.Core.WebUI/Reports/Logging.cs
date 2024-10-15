using Serilog;
using Serilog.Core;
using TestAutomationFramework.Core.WebUI.Abstraction;

namespace TestAutomationFramework.Core.WebUI.Reports
{
    public class Logging : ILogging
    {
        private readonly IDefaultVariables _defaultVariables;
        LoggingLevelSwitch loggingLevelSwitch;

        public Logging(IDefaultVariables defaultVariables)
        {
            _defaultVariables = defaultVariables;

            loggingLevelSwitch = new LoggingLevelSwitch(Serilog.Events.LogEventLevel.Debug);
            Log.Logger = new LoggerConfiguration().MinimumLevel.ControlledBy(loggingLevelSwitch)
                .WriteTo.File(_defaultVariables.LogPath, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj} {NewLine} {Exception}")
                .Enrich.WithThreadName().CreateLogger();
        }

        public void LogLevel(string level)
        {
            switch (level.ToLower())
            {
                case "error":
                    loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Error; break;
                case "information":
                    loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Information; break;
                case "warning":
                    loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Warning; break;
                default:
                    loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Debug; break;
            }
        }

        public void Debug(string message)
        {
            Log.Debug(message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }

        public void Fatal(string message)
        {
            Log.Fatal(message);
        }

        public void Warning(string message)
        {
            Log.Warning(message);
        }

        public void Information(string message)
        {
            Log.Information(message);
        }
    }
}
