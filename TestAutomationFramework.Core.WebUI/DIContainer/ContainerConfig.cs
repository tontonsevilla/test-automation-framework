using Microsoft.Extensions.DependencyInjection;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Params;
using TestAutomationFramework.Core.WebUI.Reports;

namespace TestAutomationFramework.Core.WebUI.DIContainer
{
    public class ContainerConfig
    {
        public static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDefaultVariables, DefaultVariables>();
            services.AddSingleton<ILogging, Logging>();
            services.AddSingleton<IGlobalProperties, GlobalProperties>();
            return services.BuildServiceProvider();
        }
    }
}
