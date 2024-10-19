
namespace TestAutomationFramework.Core.WebUI.Abstraction
{
    public interface IExtentFeatureReport
    {
        void FlushExtent();
        AventStack.ExtentReports.ExtentReports GetExtentReport();
        void InitializeExtentReport();
    }
}
