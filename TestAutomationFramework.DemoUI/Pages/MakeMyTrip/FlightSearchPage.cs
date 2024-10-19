using Reqnroll;
using Reqnroll.BoDi;
using TestAutomationFramework.Core.WebUI.Abstraction;
using TestAutomationFramework.Core.WebUI.Base;
using TestAutomationFramework.DemoUI.WebAbstraction;

namespace TestAutomationFramework.DemoUI.Pages.MakeMyTrip
{
    public class FlightSearchPage : TestBase, IFlightSearchPage
    {
        private readonly IAtConfiguration _atConfiguration;
        private readonly IDrivers _drivers;
        private readonly ScenarioContext _scenarioContext;

        IAtBy byCloseModal => GetBy(LocatorType.XPath, "//span[@data-cy='closeModal']");
        IAtWebElement CloseModal => _drivers.FindElement(byCloseModal);

        IAtWebElement FromCity => _drivers.FindElement(GetBy(LocatorType.XPath, "//input[@id='fromCity']"));
        IAtWebElement FromCityInput => _drivers.FindElement(GetBy(LocatorType.XPath, "//input[@placeholder='From']"));

        IAtWebElement ToCity => _drivers.FindElement(GetBy(LocatorType.XPath, "//input[@id='toCity']"));
        IAtWebElement ToCityInput => _drivers.FindElement(GetBy(LocatorType.XPath, "//input[@placeholder='To']"));

        IAtWebElement FromOption(string value) => _drivers.FindElement(GetBy(LocatorType.XPath, $"//div[contains(@class, 'searchCity')]//span[contains(text(), '{value}')]"));
        IAtWebElement ToOption(string value) => _drivers.FindElement(GetBy(LocatorType.XPath, $"//div[contains(@class, 'searchToCity')]//span[contains(text(), '{value}')]"));

        IAtWebElement Departure => _drivers.FindElement(GetBy(LocatorType.XPath, "//input[@id='departure']"));
        IAtWebElement Travellers => _drivers.FindElement(GetBy(LocatorType.XPath, "//div[@data-cy='flightTraveller']"));
        IAtWebElement ReturnLabel => _drivers.FindElement(GetBy(LocatorType.XPath, "//p[text()='Tap to add a return date for bigger discounts']"));
        IAtWebElement Search => _drivers.FindElement(GetBy(LocatorType.XPath, "//p[@data-cy='submit']/a[contains(text(), 'Search')]"));
        
        IAtWebElement CalendarView(int index) => _drivers.FindElement(GetBy(LocatorType.XPath, $"//div[@class='DayPicker-Month'][{index}]//div[@class='DayPicker-Caption']//div"));
        IAtWebElement Day(int view, int day) => _drivers.FindElement(GetBy(LocatorType.XPath, $"//div[@class='DayPicker-Month'][{view}]//div[@class='dateInnerCell']/p[text()='{day}']"));
        IAtWebElement NextSetOfCalendars => _drivers.FindElement(GetBy(LocatorType.XPath, "//span[@aria-label='Next Month']"));

        IAtWebElement Adults(int noOfAdults) => _drivers.FindElement(GetBy(LocatorType.XPath, $"//li[@data-cy='adults-{noOfAdults}']"));
        IAtWebElement Children(int noOfChildren) => _drivers.FindElement(GetBy(LocatorType.XPath, $"//li[@data-cy='children-{noOfChildren}']"));

        IAtWebElement Apply => _drivers.FindElement(GetBy(LocatorType.XPath, "//button[@data-cy='travellerApplyBtn']"));

        public FlightSearchPage(
            IObjectContainer objectContainer,
            IAtConfiguration atConfiguration,
            IDrivers drivers,
            ScenarioContext scenarioContext) : base(objectContainer)
        {
            _atConfiguration = atConfiguration;
            _drivers = drivers;
            _scenarioContext = scenarioContext;
        }

        public void NavigateToLandingPage()
        {
            string url = _atConfiguration.GetConfiguration("guesturl");
            _drivers.NavigateTo(url);
            CloseModal.Click();
        }

        public void AddSearchCriteria(DataTable dataTable)
        {
            NavigateToLandingPage();

            var fromSplit = dataTable.Rows[0]["From"].Split(",");
            FromCity.Click();
            FromCityInput.SendKeys(fromSplit[0].Trim());
            FromOption(fromSplit[0].Trim()).Click();

            var toCitySplit = dataTable.Rows[0]["To"].Split(",");
            ToCity.Click();
            ToCityInput.SendKeys(toCitySplit[0].Trim());
            ToOption(toCitySplit[0].Trim()).Click();

            setDepartureDate(dataTable);

            var travellersSplit = dataTable.Rows[0]["Travellers"].Split("-");
            var noOfAdults = int.Parse(travellersSplit[0]);
            var noOfChildren = int.Parse(travellersSplit[1]);

            Travellers.Click();
            Adults(noOfAdults).Click();
            Children(noOfChildren).Click();
            Apply.Click();

            _scenarioContext["searchCriteria"] = dataTable;
        }

        private void setDepartureDate(DataTable dataTable)
        {
            string departureDate = dataTable.Rows[0]["DepartureDate"];
            string dt = string.Empty;

            switch (departureDate.Substring(1, 1).ToLower())
            {
                case "m":
                default:
                    var noOfMonths = int.Parse(departureDate.Substring(0, 1));
                    dt = DateTime.Now.AddMonths(noOfMonths).ToString("MMMM yyyy-d");
                    break;
            }

            var hasSelectedDepartureDate = false;

            while (!hasSelectedDepartureDate)
            {
                var dtSplit = dt.Split("-");
                var calendarView = dtSplit[0].Trim();
                var day = int.Parse(dtSplit[1].Trim());

                if (calendarView.Equals(CalendarView(1).GetText().Trim()))
                {
                    Day(1, day).Click();
                    hasSelectedDepartureDate = true;
                }
                else if (calendarView.Equals(CalendarView(2).GetText().Trim()))
                {
                    Day(2, day).Click();
                    hasSelectedDepartureDate = true;
                }
                else
                {
                    NextSetOfCalendars.Click();
                }
            }
        }

        public void NavigateToFlightListingPage()
        {
            Search.Click();
        }
    }
}
