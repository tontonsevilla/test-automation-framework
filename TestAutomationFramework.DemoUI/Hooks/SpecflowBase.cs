using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Runner;
using TestAutomationFramework.Core.WebUI.Selenium.LocalWebDrivers;

namespace TestAutomationFramework.DemoUI.Hooks
{
    [Binding]
    public class SpecflowBase
    {
        private readonly IChromeWebDriver _chromeWebDriver;
        private readonly IFirefoxWebDriver _firefoxWebDriver;
        private IGlobalProperties _globalProperties;

        public SpecflowBase(
            IChromeWebDriver chromeWebDriver, 
            IFirefoxWebDriver firefoxWebDriver)
        {
            _chromeWebDriver = chromeWebDriver;
            _firefoxWebDriver = firefoxWebDriver;
        }

        [BeforeScenario(Order = 2)]
        public void BeforeScenario(IObjectContainer objectContainer)
        {
            IWebDriver webDriver;

            _globalProperties = SpecflowRunner._serviceProvider.GetRequiredService<IGlobalProperties>();

            switch (_globalProperties.browsertype)
            {
                case "firefox":
                    webDriver = _firefoxWebDriver.GetFirefoxDriver();
                    break;
                default:
                    webDriver = _chromeWebDriver.GetChromeWebDriver();
                    break;
            }

            objectContainer.RegisterInstanceAs(webDriver);
        }
    }
}
