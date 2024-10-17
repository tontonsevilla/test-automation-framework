using Reqnroll;
using Reqnroll.BoDi;
using TestAutomationFramework.Core.WebUI.DIContainer;
using TestAutomationFramework.DemoUI.Configuration;
using TestAutomationFramework.DemoUI.Pages;
using TestAutomationFramework.DemoUI.Steps;
using TestAutomationFramework.DemoUI.WebAbstraction;

namespace TestAutomationFramework.DemoUI.Container
{
    [Binding]
    public class ContainerConfig
    {
        [BeforeScenario(Order = 1)]
        public void BeforeScenario(IObjectContainer objectContainer)
        {
            objectContainer.RegisterTypeAs<AtConfiguration, IAtConfiguration>();
            objectContainer.RegisterTypeAs<LoginPage, ILoginPage>();
            objectContainer.RegisterTypeAs<LoginSteps, ILoginSteps>();

            objectContainer = CoreContainerConfig.SetContainer(objectContainer);
        }
    }
}
