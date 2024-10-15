using Reqnroll;
using TestAutomationFramework.DemoUI.Pages;

namespace TestAutomationFramework.DemoUI.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPage _loginPage;

        public LoginSteps()
        {
            _loginPage = new LoginPage();
        }

        [Given("Login with valid credentials")]
        public void GivenLoginWithValidCredentials()
        {
            _loginPage.LoginWithValidCredentials("standard_user", "secret_sauce");
        }

        [Given("Login with invalid credentials")]
        public void GivenLoginWithInvalidCredentials()
        {
            _loginPage.LoginWithInvalidCredentials("standard_user", "wrong");
        }

    }
}
