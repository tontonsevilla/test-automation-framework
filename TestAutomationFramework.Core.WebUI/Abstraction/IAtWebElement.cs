using OpenQA.Selenium;

namespace TestAutomationFramework.Core.WebUI.Abstraction
{
    public interface IAtWebElement
    {
        void Set(
            IWebDriver webDriver,
            IAtBy atBy);

        void Click();

        void SendKeys(string text);
        string GetText();
        string GetAttribute(string attributeName);
        void MouseHover();
        bool IsDisplayed();
        void DoubleClick();
        void ClickWithJS();
        IWebElement GetElement();
    }
}
