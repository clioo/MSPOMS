using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace UnosquareTest.POMS.WindowsPOM
{
    public class WindowsPageContent
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "c-shellmenu_50")]
        public IWebElement WindowsDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "search")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.Id, Using = "cli_shellHeaderSearchInput")]
        public IWebElement SearchInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#c-shellmenu_50 + ul > li")]
        public IList<IWebElement> WindowsDropDownOptions { get; set; }

    }
}
