using Reqnroll;

namespace TestAutomationFramework.DemoUI.WebAbstraction
{
    public interface IFlightSearchPage
    {
        void AddSearchCriteria(DataTable dataTable);
        void NavigateToFlightListingPage();
    }
}
