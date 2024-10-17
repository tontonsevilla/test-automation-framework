using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V127.Debugger;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.CustomException;
using TestAutomationFramework.Core.WebUI.Runner;

namespace TestAutomationFramework.Core.WebUI.WebElements
{
    public class AtWebElement : IAtWebElement
    {
        private IWebDriver _webDriver;
        private IAtBy _atBy;
        private readonly ILogging _logging;

        public AtWebElement()
        {
            _logging = SpecflowRunner._serviceProvider.GetRequiredService<ILogging>();   
        }

        public void Set(
            IWebDriver webDriver,
            IAtBy atBy)
        {
            _webDriver = webDriver;
            _atBy = atBy;
        }

        public IWebElement GetElement()
        {
            try
            {
                var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
                wait.IgnoreExceptionTypes(
                    typeof(StaleElementReferenceException),
                    typeof(NoSuchElementException),
                    typeof(ElementNotVisibleException),
                    typeof(ElementNotInteractableException));

                return wait.Until<IWebElement>(ExpectedConditions.ElementToBeClickable(_atBy.By));
            }
            catch (Exception ex)
            {
                var message = $"Element not clickable: {ex.Message}";
                _logging.Error(message);
                throw new TestAutomationFrameworkException(message);
            }
        }

        public void Click()
        {
            for (var i = 0; i < 5; i++) 
            {
                try
                {
                    var webElement = GetElement();
                    webElement.Click();
                    break;
                }
                catch (StaleElementReferenceException) { }
                catch (Exception ex)
                {
                    var message = $"Error while clicking the element: {ex.Message}";
                    _logging.Error(message);
                    throw new TestAutomationFrameworkException(message);
                }
            }
        }

        public void SendKeys(string text)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    var webElement = GetElement();
                    webElement.SendKeys(text);
                    break;
                }
                catch (StaleElementReferenceException) { }
                catch (Exception ex)
                {
                    var message = $"Error while sending keys to the element: {ex.Message}";
                    _logging.Error(message);
                    throw new TestAutomationFrameworkException(message);
                }
            }
        }
    }
}
