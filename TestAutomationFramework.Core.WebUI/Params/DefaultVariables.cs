using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationFramework.Core.WebUI.Params
{
    public class DefaultVariables
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
    }
}
