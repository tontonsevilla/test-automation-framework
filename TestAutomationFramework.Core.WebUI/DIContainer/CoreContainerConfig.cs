using Microsoft.Extensions.DependencyInjection;
using Reqnroll.BoDi;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Params;
using TestAutomationFramework.Core.WebUI.Reports;
using TestAutomationFramework.Core.WebUI.Selenium.LocalWebDrivers;

namespace TestAutomationFramework.Core.WebUI.DIContainer
{
    public class CoreContainerConfig
    {
        public static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDefaultVariables, DefaultVariables>();
            services.AddSingleton<ILogging, Logging>();
            services.AddSingleton<IGlobalProperties, GlobalProperties>();
            return services.BuildServiceProvider();
        }

        public static IObjectContainer SetContainer(IObjectContainer container)
        {
            container.RegisterTypeAs<ChromeWebDriver, IChromeWebDriver>();
            container.RegisterTypeAs<FirefoxWebDriver, IFirefoxWebDriver>();

            return container;
        }
    }
}
