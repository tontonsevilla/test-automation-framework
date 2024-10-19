using OpenQA.Selenium;

namespace TestAutomationFramework.Core.WebUI.Abstraction
{
    public interface IDrivers
    {
        IWebDriver GetWebDriver();
        IAtWebElement FindElement(IAtBy atBy);
        void NavigateTo(string url);
        void CloseBrowser();
        string GetPageTitle();
        void GetNewTab();
        void CloseCurrentBrowser();
        void SwitchToWindowWithHandle(string handle);
        void SwitchToWindowWithTitle(string title);
        void SwitchToFrameWithName(string frameName);
        void Maximize();
        void ExecuteJavaScript(string script);
        void ScrollWithPixel();
        void ScrollByHeight();
        void ScrollIntoView(IAtWebElement atWebElement);
        string GetScreenshot();
    }
}
