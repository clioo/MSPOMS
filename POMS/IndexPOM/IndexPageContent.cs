
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnosquareTest.POMS.IndexPOM
{
    class IndexPageContent
    {
        private IWebDriver Driver;

        [FindsBy(How = How.Id, Using = "shellmenu_1")]
        public IWebElement OfficeMenuItem { get; set; }

        [FindsBy(How = How.Id, Using = "shellmenu_2")]
        public IWebElement WindowsMenuItem { get; set; }

        [FindsBy(How = How.Id, Using = "shellmenu_3")]
        public IWebElement SurfaceMenuItem { get; set; }

        [FindsBy(How = How.Id, Using = "shellmenu_4")]
        public IWebElement XboxMenuItem { get; set; }

        [FindsBy(How = How.Id, Using = "shellmenu_5")]
        public IWebElement DealsMenuItem { get; set; }

        [FindsBy(How = How.Id, Using = "l1_support")]
        public IWebElement SupportMenuItem { get; set; }
    }
}
