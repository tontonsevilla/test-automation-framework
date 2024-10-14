using TestAutomationFramework.Core.WebUI.Reports;

namespace TestAutomationFramework.DemoUI.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Logging logging = new Logging();
            logging.Warning("Hello this is a warning message.");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}