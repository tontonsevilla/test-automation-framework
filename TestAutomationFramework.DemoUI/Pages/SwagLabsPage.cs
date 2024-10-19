using OpenQA.Selenium;
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

        IAtBy byProductItems => GetBy(LocatorType.XPath, "//div[@class='inventory_list']/div");
        IAtWebElement ProductItems => _drivers.FindElement(byProductItems);

        IAtBy byProductName(int index) => GetBy(LocatorType.XPath, $"//div[@class='inventory_list']/div[{index}]//div[@class='inventory_item_label']//a");
        IAtWebElement ProductName(int index) => _drivers.FindElement(byProductName(index));

        IAtBy byProductPrice(int index) => GetBy(LocatorType.XPath, $"//div[@class='inventory_list']/div[{index}]//div[@class='inventory_item_price']");
        IAtWebElement ProductPrice(int index) => _drivers.FindElement(byProductPrice(index));

        public SwagLabsPage(
            IObjectContainer objectContainer,
            IAtConfiguration atConfiguration,
            IDrivers drivers) : base(objectContainer)
        {
            _atConfiguration = atConfiguration;
            _drivers = drivers;
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
    }
}
