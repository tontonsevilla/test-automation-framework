using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Runner;

namespace TestAutomationFramework.Core.WebUI.DriverContext
{
    [Binding]
    public class Drivers : IDrivers
    {
        private IGlobalProperties _globalProperties;
        private IWebDriver webDriver;
        private readonly IChromeWebDriver _chromeWebDriver;
        private readonly IFirefoxWebDriver _firefoxWebDriver;
        private readonly IObjectContainer _objectContainer;

        public Drivers(
            IChromeWebDriver chromeWebDriver,
            IFirefoxWebDriver firefoxWebDriver,
            IObjectContainer objectContainer)
        {
            _chromeWebDriver = chromeWebDriver;
            _firefoxWebDriver = firefoxWebDriver;
            _objectContainer = objectContainer;
        }

        public IWebDriver GetWebDriver()
        {
            if (webDriver == null)
            {
                GetNewWebDriver();
            }

            return webDriver;
        }

        public IAtWebElement FindElement(IAtBy atBy)
        {
            var atWebElement = _objectContainer.Resolve<IAtWebElement>();
            atWebElement.Set(GetWebDriver(), atBy);

            return atWebElement;
        }

        public void GetNewWebDriver()
        {
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
        }

        public void NavigateTo(string url)
        {
            GetWebDriver().Navigate().GoToUrl(url);
        }

        public void CloseBrowser()
        {
            webDriver.Quit();
        }
    }
}
