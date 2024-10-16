namespace TestAutomationFramework.Core.WebUI.Abstraction
{
    public interface IGlobalProperties
    {
        string browsertype { get; set; }
        string gridhuburl { get; set; }
        bool stepscreenshot { get; set; }
        string extentreportportalurl { get; set; }
        bool extentreporttoportal { get; set; }
        string loglevel { get; set; }
        string datasetlocation { get; set; }
        string downloadedlocation { get; set; }

        void Configuration();
    }
}
