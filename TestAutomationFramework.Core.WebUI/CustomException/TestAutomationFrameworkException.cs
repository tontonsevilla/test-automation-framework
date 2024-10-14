namespace TestAutomationFramework.Core.WebUI.CustomException
{
    public class TestAutomationFrameworkException : Exception
    {
        public TestAutomationFrameworkException(string message) : base(message) { }
        public TestAutomationFrameworkException(ErrorItems errorItems) : base($"{errorItems}") { }
        public TestAutomationFrameworkException(ErrorItems errorItems, string message) : base($"{errorItems} : {message}") { }
    }
}
