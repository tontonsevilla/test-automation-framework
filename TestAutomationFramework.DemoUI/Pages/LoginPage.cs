using OpenQA.Selenium;
using Reqnroll.BoDi;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Base;
using TestAutomationFramework.DemoUI.WebAbstraction;

namespace TestAutomationFramework.DemoUI.Pages
{
    public class LoginPage : TestBase, ILoginPage
    {
        IWebDriver _webDriver;
        private readonly IAtConfiguration _atConfiguration;
        private readonly IDrivers _drivers;

        IAtBy byUserName => GetBy(LocatorType.XPath, "//input[@id='user-name']");
        IAtWebElement inputUserName => _drivers.FindElement(byUserName);

        IAtBy byPassword => GetBy(LocatorType.XPath, "//input[@id='password']");
        IAtWebElement inputPassword => _drivers.FindElement(byPassword);

        IAtBy byLogin => GetBy(LocatorType.XPath, "//input[@id='login-button']");
        IAtWebElement inputLogin => _drivers.FindElement(byLogin);

        public LoginPage(
            IAtConfiguration atConfiguration, 
            IDrivers drivers,
            IObjectContainer objectContainer) : base(objectContainer)
        {
            _atConfiguration = atConfiguration;
            _drivers = drivers;
        }

        public void LoginWithValidCredentials(string username, string password)
        {
            _drivers.NavigateTo(_atConfiguration.GetConfiguration("url"));
            inputUserName.SendKeys(username);
            inputPassword.SendKeys(password);
            inputLogin.Click();
        }

        public void LoginWithInvalidCredentials(string username, string password)
        {
            _drivers.NavigateTo(_atConfiguration.GetConfiguration("url"));
            inputUserName.SendKeys(username);
            inputPassword.SendKeys(password);
            inputLogin.Click();
        }
    }
}
