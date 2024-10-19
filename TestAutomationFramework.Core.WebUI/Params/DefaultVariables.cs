using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationFramework.Core.WebUI.Abstraction;

namespace TestAutomationFramework.Core.WebUI.Params
{
    public class DefaultVariables : IDefaultVariables
    {
        public string ReportPath
        {
            get
            {
                return System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName + "\\Result\\Report"
                    + DateTime.Now.ToString("yyyyMMdd HHmmss");
            }
        }

        public string LogPath
        {
            get
            {
                return ReportPath + "\\log.txt";
            }
        }

        public string ExtentReportPath
        {
            get
            {
                return ReportPath + "\\index.html";
            }
        }

        public string FrameworkSettingsJsonPath
        {
            get
            {
                return @$"{System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName}\Resources\frameworkSettings.json";
            }
        }

        public string ApplicationConfigJsonPath
        {
            get
            {
                return @$"{System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName}\Resources\applicationConfig.json";
            }
        }

        public string GridHubUrl
        {
            get
            {
                return "https://localhost:4444/wd/hub";
            }
        }

        public string DataSetLocationPath
        {
            get
            {
                return @$"{System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName}\DataSet";
            }
        }
    }
}
