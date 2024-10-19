using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationFramework.Core.WebUI.Abstraction
{
    public interface IExtentReport
    {
        void CreateFeature(string featureName);
        void CreateScenario(string scenarioName);
        void Error(string msg);
        void Fail(string msg);
        void Pass(string msg);
        void Warning(string msg);
    }
}
