using AventStack.ExtentReports.Reporter;
using TestAutomationFramework.Core.WebUI.Abstraction;

namespace TestAutomationFramework.Core.WebUI.Reports
{
    public class ExtentFeatureReport : IExtentFeatureReport
    {
        private readonly IDefaultVariables _defaultVariables;
        AventStack.ExtentReports.ExtentReports extentReports;

        public ExtentFeatureReport(IDefaultVariables defaultVariables)
        {
            _defaultVariables = defaultVariables;
        }

        public void InitializeExtentReport()
        {
            var extentHtmlReport = new ExtentHtmlReporter(_defaultVariables.ExtentReportPath);
            extentReports = new AventStack.ExtentReports.ExtentReports();
            extentReports.AttachReporter(extentHtmlReport);
        }

        public AventStack.ExtentReports.ExtentReports GetExtentReport()
        {
            return extentReports;
        }

        public void FlushExtent()
        {
            extentReports.Flush();
        }
    }
}
