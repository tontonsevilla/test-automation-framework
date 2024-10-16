using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
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

        public void Click()
        {
            try
            {
                _webDriver.FindElement(_atBy.By).Click();
            }
            catch (Exception ex)
            {
                _logging.Error("Error while clicking the element: " + ex.Message);
                throw new TestAutomationFrameworkException("Error while clicking the element: " + ex.Message);
            }
        }

        public void SendKeys(string text)
        {
            try
            {
                _webDriver.FindElement(_atBy.By).SendKeys(text);
            }
            catch (Exception ex)
            {
                _logging.Error("Error while sending keys to the element: " + ex.Message);
                throw new TestAutomationFrameworkException("Error while sending keys to the element: " + ex.Message);
            }
        }
    }
}
