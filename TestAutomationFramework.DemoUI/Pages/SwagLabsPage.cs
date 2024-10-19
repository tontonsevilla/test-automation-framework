using Reqnroll;
using Reqnroll.Assist;
using Reqnroll.BoDi;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Base;
using TestAutomationFramework.DemoUI.DataTables;
using TestAutomationFramework.DemoUI.WebAbstraction;

namespace TestAutomationFramework.DemoUI.Pages
{
    public class SwagLabsPage : TestBase, ISwagLabsPage
    {
        private readonly IAtConfiguration _atConfiguration;
        private readonly IDrivers _drivers;
        private readonly ScenarioContext _scenarioContext;

        IAtBy byProductItems => GetBy(LocatorType.XPath, "//div[@class='inventory_list']/div");
        IAtWebElement ProductItems => _drivers.FindElement(byProductItems);

        IAtBy byProductName(int index) => GetBy(LocatorType.XPath, $"//div[@class='inventory_list']/div[{index}]//div[@class='inventory_item_label']//a");
        IAtWebElement ProductName(int index) => _drivers.FindElement(byProductName(index));

        IAtBy byProductPrice(int index) => GetBy(LocatorType.XPath, $"//div[@class='inventory_list']/div[{index}]//div[@class='inventory_item_price']");
        IAtWebElement ProductPrice(int index) => _drivers.FindElement(byProductPrice(index));

        IAtBy byAddCart(int index) => GetBy(LocatorType.XPath, "//div[@class='inventory_list']/div[" + index + "]/div[@class='inventory_item_description']//button");
        IAtWebElement AddCart(int index) => _drivers.FindElement(byAddCart(index));

        IAtBy byShoppingCartBadge => GetBy(LocatorType.XPath, "//div[@id='shopping_cart_container']//span");
        IAtWebElement ShoppingCartBadge => _drivers.FindElement(byShoppingCartBadge);
       
        int intCartBadge => _drivers.FindElementsCount(byShoppingCartBadge);
        IAtBy byCartContainer => GetBy(LocatorType.XPath, "//div[@id='shopping_cart_container']//a[@class='shopping_cart_link']");
        IAtWebElement CartContainer => _drivers.FindElement(byCartContainer);

        public SwagLabsPage(
            IObjectContainer objectContainer,
            IAtConfiguration atConfiguration,
            IDrivers drivers,
            ScenarioContext scenarioContext) : base(objectContainer)
        {
            _atConfiguration = atConfiguration;
            _drivers = drivers;
            _scenarioContext = scenarioContext;
        }

        public void VerifyProductItems(DataTable dataTable)
        {
            DataTable tableProduct = new DataTable(new string[] { "Item", "Price" });
            int count = ProductItems.NumberOfElement;

            for (int i = 1; i < count; i++)
            {
                tableProduct.AddRow(ProductName(i).GetText(), ProductPrice(i).GetText());
            }

            Assert.AreEqual(tableProduct.ToProjection<Product>().Except(dataTable.ToProjection<Product>()).Count(), 0);
        }

        private void addRemoveCartItems(IList<string> cartItems, string btnText)
        {
            int count = ProductItems.NumberOfElement;
            for (int i = 1; i < count; i++)
            {
                if (cartItems.Contains(ProductName(i).GetText().Trim()))
                {
                    AddCart(i).Click();
                    Thread.Sleep(500);
                    Assert.AreEqual(AddCart(1).GetText(), btnText);
                }
            }
        }

        public void AddCartItems(IList<string> cartItems)
        {
            addRemoveCartItems(cartItems, "Remove");

            _scenarioContext["cartItems"] = cartItems;
        }

        public void MatchSelectedCartItems()
        {
            var cartItems = (IList<string>)_scenarioContext["cartItems"];
            Assert.AreEqual(int.Parse(ShoppingCartBadge.GetText()), cartItems.Count);
        }

        public void RemoveCartItems(IList<string> cartItems)
        {
            addRemoveCartItems(cartItems, "Add to cart");

            var scCartItems = (IList<string>)_scenarioContext["cartItems"];

            foreach (var item in scCartItems)
            {
                cartItems.Remove(item);
            }
            _scenarioContext["cartItems"] = cartItems;
        }

        public void CartIsEmpty()
        {
            Assert.IsEmpty(CartContainer.GetText().Trim());
        }
    }
}
