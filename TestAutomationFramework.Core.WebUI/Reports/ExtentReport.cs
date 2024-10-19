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

        public void Pass(string msg, string base64)
        {
            _scenario.Log(AventStack.ExtentReports.Status.Pass, 
                msg,
                AventStack.ExtentReports.MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
        }

        public void Fail(string msg, string base64)
        {
            _scenario.Log(AventStack.ExtentReports.Status.Fail, 
                msg,
                AventStack.ExtentReports.MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
        }

        public void Warning(string msg, string base64)
        {
            _scenario.Log(AventStack.ExtentReports.Status.Warning, 
                msg,
                AventStack.ExtentReports.MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
        }

        public void Error(string msg, string base64)
        {
            _scenario.Log(AventStack.ExtentReports.Status.Error, 
                msg,
                AventStack.ExtentReports.MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
        }
    }
}
