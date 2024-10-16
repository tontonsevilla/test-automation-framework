using OpenQA.Selenium;
using Reqnroll.BoDi;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Base;
using TestAutomationFramework.DemoUI.WebAbstraction;

namespace TestAutomationFramework.DemoUI.Pages
{
    public class LoginPage : TestBase
    {
        IWebDriver _webDriver;
        private readonly IAtConfiguration _atConfiguration;

        IAtBy byUserName => GetBy(LocatorType.XPath, "//input[@id='user-name']");
        IWebElement inputUserName => _webDriver.FindElement(byUserName.By);

        IAtBy byPassword => GetBy(LocatorType.XPath, "//input[@id='password']");
        IWebElement inputPassword => _webDriver.FindElement(byPassword.By);

        IAtBy byLogin => GetBy(LocatorType.XPath, "//input[@id='login-button']");
        IWebElement inputLogin => _webDriver.FindElement(byLogin.By);

        public LoginPage(
            IAtConfiguration atConfiguration, 
            IDrivers drivers,
            IObjectContainer objectContainer) : base(objectContainer)
        {
            _atConfiguration = atConfiguration;
            _webDriver = drivers.GetWebDriver();
            _webDriver.Manage().Window.Maximize();
        }

        public void LoginWithValidCredentials(string username, string password)
        {
            _webDriver.Navigate().GoToUrl(_atConfiguration.GetConfiguration("url"));
            inputUserName.SendKeys(username);
            inputPassword.SendKeys(password);
            inputLogin.Click();
        }

        public void LoginWithInvalidCredentials(string username, string password)
        {
            _webDriver.Navigate().GoToUrl(_atConfiguration.GetConfiguration("url"));
            inputUserName.SendKeys(username);
            inputPassword.SendKeys(password);
            inputLogin.Click();
        }
    }
}
