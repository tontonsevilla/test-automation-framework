using Reqnroll;
using TestAutomationFramework.DemoUI.Pages;
using TestAutomationFramework.DemoUI.WebAbstraction;

namespace TestAutomationFramework.DemoUI.Steps
{
    [Binding]
    public class SwagLabsSteps
    {
        private readonly ISwagLabsPage _swagLabsPage;

        public SwagLabsSteps(ISwagLabsPage swagLabsPage)
        {
            _swagLabsPage = swagLabsPage;
        }

        [Then("user verifies swag lab products")]
        public void ThenUserVerifiesSwagLabProducts(DataTable dataTable)
        {
            _swagLabsPage.VerifyProductItems(dataTable);
        }

    }
}
