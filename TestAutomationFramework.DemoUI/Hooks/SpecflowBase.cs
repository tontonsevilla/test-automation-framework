using Reqnroll;
using Reqnroll.BoDi;
using TestAutomationFramework.Core.WebUI.Abstraction;

namespace TestAutomationFramework.DemoUI.Hooks
{
    [Binding]
    public class SpecflowBase
    {
        private readonly IChromeWebDriver _chromeWebDriver;
        private readonly IFirefoxWebDriver _firefoxWebDriver;
        private IGlobalProperties _globalProperties;
        private IDrivers _drivers;

        public SpecflowBase(
            IChromeWebDriver chromeWebDriver, 
            IFirefoxWebDriver firefoxWebDriver)
        {
            _chromeWebDriver = chromeWebDriver;
            _firefoxWebDriver = firefoxWebDriver;
        }

        [BeforeScenario(Order = 2)]
        public void BeforeScenario(IObjectContainer objectContainer)
        {
           _drivers = objectContainer.Resolve<IDrivers>();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Thread.Sleep(3000);
            _drivers.CloseBrowser();
        }
    }
}
