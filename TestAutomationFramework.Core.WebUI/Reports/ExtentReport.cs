using TestAutomationFramework.Core.WebUI.Abstraction;

namespace TestAutomationFramework.Core.WebUI.Reports
{
    public class ExtentReport : IExtentReport
    {
        private readonly IExtentFeatureReport _extentFeatureReport;
        AventStack.ExtentReports.ExtentTest _feature, _scenario;

        public ExtentReport(IExtentFeatureReport extentFeatureReport)
        {
            _extentFeatureReport = extentFeatureReport;
        }

        public void CreateFeature(string featureName)
        {
            _feature = _extentFeatureReport.GetExtentReport().CreateTest(featureName);
        }

        public void CreateScenario(string scenarioName)
        {
            _scenario = _feature.CreateNode(scenarioName);
        }

        public void Pass(string msg)
        {
            _scenario.Log(AventStack.ExtentReports.Status.Pass, msg);
        }

        public void Fail(string msg)
        {
            _scenario.Log(AventStack.ExtentReports.Status.Fail, msg);
        }

        public void Warning(string msg)
        {
            _scenario.Log(AventStack.ExtentReports.Status.Warning, msg);
        }

        public void Error(string msg)
        {
            _scenario.Log(AventStack.ExtentReports.Status.Error, msg);
        }
    }
}
