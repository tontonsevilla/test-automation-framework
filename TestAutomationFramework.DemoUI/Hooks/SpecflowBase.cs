using Microsoft.Extensions.DependencyInjection;
using Reqnroll;
using Reqnroll.BoDi;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Runner;

namespace TestAutomationFramework.DemoUI.Hooks
{
    [Binding]
    public class SpecflowBase
    {
        private readonly IChromeWebDriver _chromeWebDriver;
        private readonly IFirefoxWebDriver _firefoxWebDriver;
        private IGlobalProperties _globalProperties;
        private IDrivers _drivers;
        private IExtentFeatureReport _extentFeatureReport;
        private ScenarioContext _scenarioContext;

        public SpecflowBase(
            IChromeWebDriver chromeWebDriver, 
            IFirefoxWebDriver firefoxWebDriver,
            IDrivers drivers)
        {
            _chromeWebDriver = chromeWebDriver;
            _firefoxWebDriver = firefoxWebDriver;
            _drivers = drivers;
        }

        [BeforeScenario(Order = 2)]
        public void BeforeScenario(
            IObjectContainer objectContainer,
            ScenarioContext scenarioContext,
            FeatureContext featureContext)
        {
            _drivers = objectContainer.Resolve<IDrivers>();
            var extentReport = (IExtentReport)featureContext["extentReport"];
            extentReport.CreateScenario(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep(
            ScenarioContext scenarioContext,
            FeatureContext featureContext)
        {
            var extentReport = (IExtentReport)featureContext["extentReport"];
            string screenshotBase64String = string.Empty;

            if (scenarioContext.TestError != null)
            {
                screenshotBase64String =_drivers.GetScreenshot();
                extentReport.Fail(scenarioContext.StepContext.StepInfo.Text, screenshotBase64String);
            }
            else
            {
                _globalProperties = SpecflowRunner._serviceProvider.GetRequiredService<IGlobalProperties>();
                if (_globalProperties.stepscreenshot)
                {
                    screenshotBase64String = _drivers.GetScreenshot();
                }
                extentReport.Pass(scenarioContext.StepContext.StepInfo.Text, screenshotBase64String);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _extentFeatureReport = SpecflowRunner._serviceProvider.GetRequiredService<IExtentFeatureReport>();
            _extentFeatureReport.FlushExtent();
            Thread.Sleep(3000);
            _drivers.CloseBrowser();
        }
    }
}
