using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Drivers(
            IChromeWebDriver chromeWebDriver,
            IFirefoxWebDriver firefoxWebDriver)
        {
            _chromeWebDriver = chromeWebDriver;
            _firefoxWebDriver = firefoxWebDriver;
        }

        public IWebDriver GetWebDriver()
        {
            if (webDriver == null)
            {
                GetNewWebDriver();
            }

            return webDriver;
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

        public void CloseBrowser()
        {
            webDriver.Quit();
        }
    }
}
