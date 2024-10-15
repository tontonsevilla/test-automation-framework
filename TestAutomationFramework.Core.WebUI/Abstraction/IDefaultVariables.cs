namespace TestAutomationFramework.Core.WebUI.Abstraction
{
    public interface IDefaultVariables
    {
        string LogPath { get; }
        string FrameworkSettingsJsonPath { get; }
        string GridHubUrl { get; }
        string DataSetLocationPath { get; }
    }
}
