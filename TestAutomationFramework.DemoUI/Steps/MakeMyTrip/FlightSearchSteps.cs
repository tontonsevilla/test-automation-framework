using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationFramework.DemoUI.WebAbstraction;

namespace TestAutomationFramework.DemoUI.Steps.MakeMyTrip
{
    [Binding]
    public class FlightSearchSteps
    {
        private readonly IFlightSearchPage _flightSearchPage;

        public FlightSearchSteps(IFlightSearchPage flightSearchPage)
        {
            _flightSearchPage = flightSearchPage;
        }

        [Given("User enters flight search criteria on the flight landing page")]
        public void GivenUserEntersFlightSearchCriteriaOnTheFlightLandingPage(DataTable dataTable)
        {
            _flightSearchPage.AddSearchCriteria(dataTable);
        }

        [When("User navigate to flight listing page")]
        public void WhenUserNavigateToFlightListingPage()
        {
            _flightSearchPage.NavigateToFlightListingPage();
        }
    }
}
