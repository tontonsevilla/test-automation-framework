using OpenQA.Selenium;
using Reqnroll;
using TestAutomationFramework.DemoUI.Pages;
using TestAutomationFramework.DemoUI.WebAbstraction;

namespace TestAutomationFramework.DemoUI.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;
        private readonly IAtConfiguration _atConfiguration;

        public LoginSteps(IAtConfiguration atConfiguration, IWebDriver webDriver)
        {
            _loginPage = new LoginPage(atConfiguration, webDriver);
            _atConfiguration = atConfiguration;
        }

        [Given("Login with valid credentials")]
        public void GivenLoginWithValidCredentials()
        {
            _loginPage.LoginWithValidCredentials(_atConfiguration.GetConfiguration("username"), _atConfiguration.GetConfiguration("password"));
        }

        [Given("Login with invalid credentials")]
        public void GivenLoginWithInvalidCredentials()
        {
            _loginPage.LoginWithInvalidCredentials("standard_user", "wrong");
        }

    }
}
