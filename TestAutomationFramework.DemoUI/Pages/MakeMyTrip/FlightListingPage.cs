using Reqnroll;
using Reqnroll.BoDi;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Base;
using TestAutomationFramework.DemoUI.WebAbstraction;

namespace TestAutomationFramework.DemoUI.Pages.MakeMyTrip
{
    public class FlightListingPage : TestBase, IFlightListingPage
    {
        private readonly IAtConfiguration _atConfiguration;
        private readonly IDrivers _drivers;
        private readonly ScenarioContext _scenarioContext;

        IAtWebElement FromCity => _drivers.FindElement(GetBy(LocatorType.XPath, "//input[@id='fromCity']"));

        public FlightListingPage(
           IObjectContainer objectContainer,
           IAtConfiguration atConfiguration,
           IDrivers drivers,
           ScenarioContext scenarioContext) : base(objectContainer)
        {
            _atConfiguration = atConfiguration;
            _drivers = drivers;
            _scenarioContext = scenarioContext;
        }

        public void VerifySearchCriteria()
        {
            var dataTable = (DataTable)_scenarioContext["searchCriteria"];
            Assert.AreEqual(FromCity.GetAttribute("value").Trim(), dataTable.Rows[0]["From"].Trim());
        }
    }
}
