using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationFramework.DemoUI.Configuration;
using TestAutomationFramework.DemoUI.WebAbstraction;
using WebDriverManager.DriverConfigs.Impl;

namespace TestAutomationFramework.DemoUI.Pages
{
    public class LoginPage
    {
        IWebDriver _webDriver;
        private readonly IAtConfiguration _atConfiguration;

        IWebElement inputUserName => _webDriver.FindElement(By.XPath("//input[@id='user-name']"));
        IWebElement inputPassword => _webDriver.FindElement(By.XPath("//input[@id='password']"));
        IWebElement inputSubmit => _webDriver.FindElement(By.XPath("//input[@id='login-button']"));

        public LoginPage(IAtConfiguration atConfiguration)
        {
            _atConfiguration = atConfiguration;
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
        }

        public void LoginWithValidCredentials(string username, string password)
        {
            _webDriver.Navigate().GoToUrl(_atConfiguration.GetConfiguration("url"));
            inputUserName.SendKeys(username);
            inputPassword.SendKeys(password);
            inputSubmit.Click();
        }

        public void LoginWithInvalidCredentials(string username, string password)
        {
            _webDriver.Navigate().GoToUrl(_atConfiguration.GetConfiguration("url"));
            inputUserName.SendKeys(username);
            inputPassword.SendKeys(password);
            inputSubmit.Click();
        }
    }
}
