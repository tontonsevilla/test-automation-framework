namespace TestAutomationFramework.Core.WebUI.Abstraction
{
    public interface IDefaultVariables
    {
        string LogPath { get; }
        string FrameworkSettingsJsonPath { get; }
        string ApplicationConfigJsonPath { get; }
        string GridHubUrl { get; }
        string DataSetLocationPath { get; }
        string ExtentReportPath { get; }
    }
}
