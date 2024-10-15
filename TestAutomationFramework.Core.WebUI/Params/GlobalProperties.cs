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
            Configuration();
        }

        public string browsertype { get; set; }
        public string gridhuburl { get; set; }
        public bool stepscreenshot { get; set; }
        public string extentreportportalurl { get; set; }
        public bool extentreporttoportal { get; set; }
        public string loglevel { get; set; }
        public string datasetlocation { get; set; }
        public string downloadedlocation { get; set; }

        public void Configuration()
        {
            var builder = (dynamic)null;

            try
            {
                builder = new ConfigurationBuilder().AddJsonFile(_defaultVariables.FrameworkSettingsJsonPath).Build();
            }
            catch(Exception ex)
            {
                _logging.Error("File does not exists. " + ex.Message);
                System.Environment.Exit(0);
            }

            browsertype = string.IsNullOrEmpty(builder["BrowserType"]) ? "chrome" : builder["BrowserType"];
            gridhuburl = string.IsNullOrEmpty(builder["GridHubUrl"]) ? _defaultVariables.GridHubUrl : builder["GridHubUrl"];
            stepscreenshot = builder["StepScreenShot"].ToLower().Equals("on") ? true : false;
            extentreportportalurl = builder["ExtentReportPortalUrl"];
            extentreporttoportal = builder["ExtentReportToPortal"].ToLower().Equals("on") ? true : false;
            loglevel = builder["LogLevel"];
            datasetlocation = string.IsNullOrEmpty(builder["DataSetLocation"]) ? _defaultVariables.DataSetLocationPath : builder["DataSetLocation"];
            downloadedlocation = string.IsNullOrEmpty(builder["DataSetLocation"]) ? _defaultVariables.DataSetLocationPath : builder["DownloadedLocation"];

            _logging.LogLevel(loglevel);

            _logging.Debug("********************************************************************************");
            _logging.Information("********************************************************************************");
            _logging.Information("Configuration |RUN PARAMETERS");
            _logging.Information("********************************************************************************");
            _logging.Information("Configuration|BROWSER TYPE: " + browsertype);
            _logging.Information("Configuration|GRID HUB URL: " + gridhuburl);
            _logging.Information("Configuration|STEP SCREENSHOT: " + stepscreenshot);
            _logging.Information("Configuration|EXTENT REPORT PORTAL URL: " + extentreportportalurl);
            _logging.Information("Configuration|EXTENT REPORT LOCALLY: " + extentreporttoportal);
            _logging.Information("Configuration|LOG LEVEL: " + loglevel);
            _logging.Information("Configuration|DATA SET LOCATION: " + datasetlocation);
            _logging.Information("Configuration|DOWNLOADED LOCATION: " + datasetlocation);
            _logging.Information("********************************************************************************");
            _logging.Information("********************************************************************************");
        }
    }
}
