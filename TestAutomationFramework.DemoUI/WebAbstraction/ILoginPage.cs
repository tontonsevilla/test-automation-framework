namespace TestAutomationFramework.DemoUI.WebAbstraction
{
    public interface ILoginPage
    {
        void LoginWithInvalidCredentials(string username, string password);
        void LoginWithValidCredentials(string username, string password);
    }
}
