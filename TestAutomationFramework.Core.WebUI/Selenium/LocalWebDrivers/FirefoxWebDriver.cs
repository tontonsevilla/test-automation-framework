using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Runner;
using WebDriverManager.DriverConfigs.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace TestAutomationFramework.Core.WebUI.Selenium.LocalWebDrivers
{
    public class FirefoxWebDriver : IFirefoxWebDriver
    {
        IGlobalProperties _globalProperties;
        public FirefoxWebDriver()
        {
            _globalProperties = SpecflowRunner._serviceProvider.GetRequiredService<IGlobalProperties>();
        }

        public IWebDriver GetFirefoxDriver()
        {
            IWebDriver webDriver;

            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            webDriver = new FirefoxDriver(GetOptions());
            webDriver.Manage().Window.Maximize();

            return webDriver;
        }

        public FirefoxOptions GetOptions()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AcceptInsecureCertificates = true;
            options.SetPreference("network.http.phishy-userpass-length", 255);
            options.SetPreference("network.automatic-ntlm-auth.allow-non-fqdn", true);
            options.SetPreference("network.negotiate-auth.allow-non-fqdn", true);
            options.SetPreference("browser.tabs.remote.autostart", false);
            options.SetPreference("browser.tabs.remote.autostart.1", false);
            options.SetPreference("browser.tabs.remote.autostart.2", false);
            options.SetPreference("browser.tabs.remote.force-enable", "false");
            options.SetPreference("browser.download.folderList", 2);
            options.SetPreference("browser.helperApps.alwaysAsk.force", false);
            options.SetPreference("browser.download.manager.showWhenStarting", false);
            options.SetPreference("browser.download.useDownloadDir", true);
            options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            options.SetPreference("browser.download.manager.alertOnEXEOpen", false);
            options.SetPreference("browser.download.manager.focusWhenStarting", false);
            options.SetPreference("browser.download.manager.useWindow", false);
            options.SetPreference("browser.download.manager.showAlertOnComplete", false);
            options.SetPreference("browser.download.manager.closeWhenDone", true);
            options.SetPreference("browser.download.dir", _globalProperties.datasetlocation);
            return options;
        }
    }
}
