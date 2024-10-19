using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V127.Debugger;
using OpenQA.Selenium.Interactions;
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

        int IAtWebElement.NumberOfElement => _webDriver.FindElements(_atBy.By).Count();

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

        public void Clear()
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    var webElement = GetElement();
                    webElement.SendKeys(Keys.Control + "A");
                    webElement.SendKeys(Keys.Delete);
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

        public string GetText()
        {
            var text = string.Empty;

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    var webElement = GetElement();
                    text = webElement.Text;
                    break;
                }
                catch (StaleElementReferenceException) { }
                catch (Exception ex)
                {
                    var message = $"Error while getting text of the element: {ex.Message}";
                    _logging.Error(message);
                    throw new TestAutomationFrameworkException(message);
                }
            }

            return text;
        }

        public string GetAttribute(string attributeName)
        {
            var text = string.Empty;

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    var webElement = GetElement();
                    text = webElement.GetAttribute(attributeName);
                    break;
                }
                catch (StaleElementReferenceException) { }
                catch (Exception ex)
                {
                    var message = $"Error while getting attrbute value of an element: {ex.Message}";
                    _logging.Error(message);
                    throw new TestAutomationFrameworkException(message);
                }
            }

            return text;
        }

        public void MouseHover()
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    var webElement = GetElement();
                    var actions = new Actions(_webDriver);
                    actions.MoveToElement(webElement).Build().Perform();
                    break;
                }
                catch (StaleElementReferenceException) { }
                catch (Exception ex)
                {
                    var message = $"Error while hovering mouse on the element: {ex.Message}";
                    _logging.Error(message);
                    throw new TestAutomationFrameworkException(message);
                }
            }
        }

        public bool IsDisplayed()
        {
            bool isDisplayed = false;

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    var webElement = GetElement();
                    isDisplayed = webElement.Displayed;
                    break;
                }
                catch (StaleElementReferenceException) { }
                catch (Exception ex)
                {
                    var message = $"Error while checking if the element is displayed: {ex.Message}";
                    _logging.Error(message);
                    throw new TestAutomationFrameworkException(message);
                }
            }

            return isDisplayed;
        }

        public void DoubleClick()
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    var webElement = GetElement();
                    var actions = new Actions(_webDriver);
                    actions.ContextClick(webElement);
                    break;
                }
                catch (StaleElementReferenceException) { }
                catch (Exception ex)
                {
                    var message = $"Error while performing double click: {ex.Message}";
                    _logging.Error(message);
                    throw new TestAutomationFrameworkException(message);
                }
            }
        }

        public void ClickWithJS()
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    var webElement = GetElement();
                    var jsExecutor = (IJavaScriptExecutor)_webDriver;
                    jsExecutor.ExecuteScript("arguments[0].click();", webElement);
                    break;
                }
                catch (StaleElementReferenceException) { }
                catch (Exception ex)
                {
                    var message = $"Error while performing click with JavaScript: {ex.Message}";
                    _logging.Error(message);
                    throw new TestAutomationFrameworkException(message);
                }
            }
        }
    }
}
