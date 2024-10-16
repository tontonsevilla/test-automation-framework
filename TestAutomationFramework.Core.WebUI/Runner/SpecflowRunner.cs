using Reqnroll;
using TestAutomationFramework.Core.WebUI.DIContainer;

namespace TestAutomationFramework.Core.WebUI.Runner
{
    [Binding]
    public class SpecflowRunner
    {
        public static IServiceProvider _serviceProvider;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _serviceProvider = CoreContainerConfig.ConfigureServices();
        }
    }
}
