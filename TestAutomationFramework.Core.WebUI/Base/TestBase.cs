using OpenQA.Selenium;
using Reqnroll.BoDi;
using TestAutomationFramework.Core.WebUI.Abstraction;

namespace TestAutomationFramework.Core.WebUI.Base
{
    public class TestBase
    {
        private readonly IObjectContainer _objectContainer;

        public TestBase(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        public IAtBy GetBy(LocatorType locatorType, string value)
        {
            By by;
            var atBy = _objectContainer.Resolve<IAtBy>();

            switch (locatorType)
            {
                case LocatorType.XPath:
                    by = By.XPath(value);
                    break;
                case LocatorType.Id:
                    by = By.Id(value);
                    break;
                case LocatorType.ClassName:
                    by = By.ClassName(value);
                    break;
                case LocatorType.TagName:
                    by = By.TagName(value);
                    break;
                case LocatorType.PartialLinkText:
                    by = By.PartialLinkText(value);
                    break;
                case LocatorType.LinkText:
                    by = By.LinkText(value);
                    break;
                default:
                    by = By.XPath(value);
                    break;
            }

            atBy.By = by;

            return atBy;
        }
    }
}
