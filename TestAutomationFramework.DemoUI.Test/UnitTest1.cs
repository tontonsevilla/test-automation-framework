using Microsoft.Extensions.DependencyInjection;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.DIContainer;

namespace TestAutomationFramework.DemoUI.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var serviceProvider = ContainerConfig.ConfigureServices();
            var logging = serviceProvider.GetRequiredService<ILogging>();
            logging.Warning("Hello this is a warning message.");
            logging.Information("Hello this is an information message.");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}