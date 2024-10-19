using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Runner;
using WebDriverManager.DriverConfigs.Impl;

namespace TestAutomationFramework.Core.WebUI.Selenium.WebDrivers
{
    public class ChromeWebDriver : IChromeWebDriver
    {
        private readonly IGlobalProperties _globalProperties;

        public ChromeWebDriver()
        {
            _globalProperties = SpecflowRunner._serviceProvider.GetRequiredService<IGlobalProperties>();
        }

        public IWebDriver GetChromeWebDriver()
        {
            IWebDriver webDriver;

            if (string.IsNullOrWhiteSpace(_globalProperties.gridhuburl))
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                webDriver = new ChromeDriver(GetOptions());

                webDriver.Manage().Window.Maximize();
            }
            else
            {
                webDriver = new RemoteWebDriver(new Uri(_globalProperties.gridhuburl), GetOptions());
            }

            return webDriver;
        }

        public ChromeOptions GetOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;

            options.AddExcludedArgument("enable-automation");
            options.AddArgument("disable-extensions");
            options.AddArgument("disable-infobars");
            options.AddArgument("disable-notifications");
            options.AddArgument("disable-web-security");
            options.AddArgument("dns-prefetch-disable");
            options.AddArgument("disable-browser-side-navigation");
            options.AddArgument("disable-gpu");
            options.AddArgument("always-authorize-plugins");
            options.AddArgument("load-extension=src/main/resources/chrome_load_stopper");
            options.AddUserProfilePreference("download.default_directory", _globalProperties.datasetlocation);
            return options;
        }
    }
}
