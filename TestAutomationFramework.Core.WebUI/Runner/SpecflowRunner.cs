using Microsoft.Extensions.DependencyInjection;
using Reqnroll;
using TestAutomationFramework.Core.WebUI.Abstraction;
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
            _serviceProvider.GetService<IGlobalProperties>();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext) 
        {
            var extentReport = _serviceProvider.GetRequiredService<IExtentReport>();
            
            extentReport.CreateFeature(featureContext.FeatureInfo.Title);

            featureContext["extentReport"] = extentReport;
        }
    }
}
