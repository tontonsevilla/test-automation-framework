namespace TestAutomationFramework.Core.WebUI.Abstraction
{
    public interface ILogging
    {
        void LogLevel(string level);
        void Debug(string message);
        void Error(string message);
        void Fatal(string message);
        void Warning(string message);
        void Information(string message);
    }
}
