using Reqnroll;

namespace TestAutomationFramework.DemoUI.WebAbstraction
{
    public interface ISwagLabsPage
    {
        void AddCartItems(IList<string> cartItems);
        void CartIsEmpty();
        void MatchSelectedCartItems();
        void RemoveCartItems(IList<string> cartItems);
        void VerifyProductItems(DataTable dataTable);
    }
}
