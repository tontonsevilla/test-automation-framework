using OpenQA.Selenium;

namespace TestAutomationFramework.Core.WebUI.Abstraction
{
    public interface IDrivers
    {
        IWebDriver GetWebDriver();
        IAtWebElement FindElement(IAtBy atBy);
        void NavigateTo(string url);
        void CloseBrowser();
    }
}
