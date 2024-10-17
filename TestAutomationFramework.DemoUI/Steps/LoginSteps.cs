using Reqnroll;
using Reqnroll.BoDi;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.DemoUI.Pages;
using TestAutomationFramework.DemoUI.WebAbstraction;

namespace TestAutomationFramework.DemoUI.Steps
{
    [Binding]
    public class LoginSteps : ILoginSteps
    {
        private readonly ILoginPage _loginPage;
        private readonly IAtConfiguration _atConfiguration;

        public LoginSteps(
            IAtConfiguration atConfiguration, 
            IDrivers drivers,
            IObjectContainer objectContainer,
            ILoginPage loginPage)
        {
            _loginPage = loginPage;
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
