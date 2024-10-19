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

        [When("User cart items from product list to cart")]
        public void WhenUserCartItemsFromProductListToCart(DataTable dataTable)
        {
            _swagLabsPage.AddCartItems(dataTable.Rows.Select(row => row["Items"].ToString()).ToList());
        }

        [Then("User checks count in cart of selected items")]
        public void ThenUserChecksCountInCartOfSelectedItems()
        {
            _swagLabsPage.MatchSelectedCartItems();
        }

        [When("User uncart items from product list")]
        public void WhenUserUncartItemsFromProductList(DataTable dataTable)
        {
            _swagLabsPage.RemoveCartItems(dataTable.Rows.Select(row => row["Items"].ToString()).ToList());
        }

        [Then("user verifies no item in cart")]
        public void ThenUserVerifiesNoItemInCart()
        {
            _swagLabsPage.CartIsEmpty();
        }

    }
}
