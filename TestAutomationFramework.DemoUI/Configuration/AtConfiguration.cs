using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Runner;
using TestAutomationFramework.DemoUI.WebAbstraction;

namespace TestAutomationFramework.DemoUI.Configuration
{
    public class AtConfiguration : IAtConfiguration
    {
        IConfiguration _configuration;

        public AtConfiguration()
        {
            var defaultVariables = SpecflowRunner._serviceProvider.GetRequiredService<IDefaultVariables>();
            _configuration = new ConfigurationBuilder().AddJsonFile(defaultVariables.ApplicationConfigJsonPath).Build();
        }

        public string GetConfiguration(string key)
        {
            return _configuration[key];
        }
    }
}
