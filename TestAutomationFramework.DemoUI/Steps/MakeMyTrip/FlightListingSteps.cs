using Reqnroll;
using TestAutomationFramework.DemoUI.WebAbstraction;

namespace TestAutomationFramework.DemoUI.Steps.MakeMyTrip
{
    [Binding]
    public class FlightListingSteps
    {
        private readonly IFlightListingPage _flightListingPage;

        public FlightListingSteps(IFlightListingPage flightListingPage)
        {
            _flightListingPage = flightListingPage;
        }

        [Then("User verifies search criteria on the flight listing page")]
        public void ThenUserVerifiesSearchCriteriaOnTheFlightListingPage()
        {
            _flightListingPage.VerifySearchCriteria();
        }

    }
}
