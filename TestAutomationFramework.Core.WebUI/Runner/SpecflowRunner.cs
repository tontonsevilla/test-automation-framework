using Reqnroll;
using TestAutomationFramework.Core.WebUI.DIContainer;

namespace TestAutomationFramework.Core.WebUI.Runner
{
    [Binding]
    public class SpecflowRunner
    {
        private IServiceProvider _serviceProvider;

        [BeforeTestRun]
        public void BeforeTestRun()
        {
            _serviceProvider = ContainerConfig.ConfigureServices();
        }
    }
}
