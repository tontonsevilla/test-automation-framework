using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Runner;

namespace TestAutomationFramework.Core.WebUI.DriverContext
{
    [Binding]
    public class Drivers : IDrivers
    {
        private IGlobalProperties _globalProperties;
        private IWebDriver webDriver;
        private readonly IChromeWebDriver _chromeWebDriver;
        private readonly IFirefoxWebDriver _firefoxWebDriver;
        private readonly IObjectContainer _objectContainer;

        public Drivers(
            IChromeWebDriver chromeWebDriver,
            IFirefoxWebDriver firefoxWebDriver,
            IObjectContainer objectContainer)
        {
            _chromeWebDriver = chromeWebDriver;
            _firefoxWebDriver = firefoxWebDriver;
            _objectContainer = objectContainer;
        }

        public IWebDriver GetWebDriver()
        {
            if (webDriver == null)
            {
                GetNewWebDriver();
            }

            return webDriver;
        }

        public int FindElementsCount(IAtBy iatBy)
        {
            return GetWebDriver().FindElements(iatBy.By).Count;
        }

        public IAtWebElement FindElement(IAtBy atBy)
        {
            var atWebElement = _objectContainer.Resolve<IAtWebElement>();
            atWebElement.Set(GetWebDriver(), atBy);

            return atWebElement;
        }

        public void GetNewWebDriver()
        {
            _globalProperties = SpecflowRunner._serviceProvider.GetRequiredService<IGlobalProperties>();

            switch (_globalProperties.browsertype)
            {
                case "firefox":
                    webDriver = _firefoxWebDriver.GetFirefoxDriver();
                    break;
                default:
                    webDriver = _chromeWebDriver.GetChromeWebDriver();
                    break;
            }
        }

        public void CloseBrowser()
        {
            webDriver.Quit();
        }

        public void NavigateTo(string url)
        {
            GetWebDriver().Navigate().GoToUrl(url);
        }

        public string GetPageTitle()
        {
            return GetWebDriver().Title;
        }

        public void GetNewTab()
        {
            GetWebDriver().SwitchTo().NewWindow(WindowType.Tab);
        }

        public void CloseCurrentBrowser()
        {
            GetWebDriver().Close();
        }

        public void SwitchToWindowWithHandle(string handle)
        {
            GetWebDriver().SwitchTo().Window(handle);
        }

        public void SwitchToWindowWithTitle(string title)
        {
            IList<string> windowHandes = GetWebDriver().WindowHandles;

            foreach (var windowHandle in windowHandes)
            {
                if (GetWebDriver().SwitchTo().Window(windowHandle).Title.Contains(title))
                {
                    break;
                }
            }
        }

        public void SwitchToFrameWithName(string frameName)
        {
            GetWebDriver().SwitchTo().Frame(frameName);
        }

        public void Maximize()
        {
            GetWebDriver().Manage().Window.Maximize();
        }

        public void ExecuteJavaScript(string script)
        {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)GetWebDriver();
            javaScriptExecutor.ExecuteScript(script);
        }

        public void ScrollWithPixel()
        {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)GetWebDriver();
            javaScriptExecutor.ExecuteScript("window.scrollBy(0, 500);");
        }

        public void ScrollByHeight()
        {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)GetWebDriver();
            javaScriptExecutor.ExecuteScript("window.scrollBy(0, document.body.scrollHeight);");
        }

        public void ScrollIntoView(IAtWebElement atWebElement)
        {
            var webElement = atWebElement.GetElement();
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)GetWebDriver();
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView", webElement);
        } 

        public string GetScreenshot()
        {
            return ((ITakesScreenshot)GetWebDriver()).GetScreenshot().AsBase64EncodedString;
        }
    }
}
