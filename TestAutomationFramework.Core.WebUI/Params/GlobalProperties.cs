using Microsoft.Extensions.Configuration;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Reports;

namespace TestAutomationFramework.Core.WebUI.Params
{
    public class GlobalProperties : IGlobalProperties
    {
        private readonly IDefaultVariables _defaultVariables;
        private readonly ILogging _logging;

        public GlobalProperties(
            IDefaultVariables defaultVariables,
            ILogging logging)
        {
            _defaultVariables = defaultVariables;
            _logging = logging;
        }

        public void Configuration()
        {
            try
            {
                var config = new ConfigurationBuilder().AddJsonFile(_defaultVariables.FrameworkSettingsJsonPath).Build();
            }
            catch(Exception ex)
            {
                _logging.Error("File does not exists. " + ex.Message);
                System.Environment.Exit(0);
            }
            
        }
    }
}
