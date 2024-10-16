using OpenQA.Selenium;

namespace TestAutomationFramework.Core.WebUI.Abstraction
{
    public interface IDrivers
    {
        IWebDriver GetWebDriver();
        void CloseBrowser();
    }
}
