
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnosquareTest.Base;
using UnosquareTest.Locators;

namespace UnosquareTest.PageObjects
{
    public class IndexPage:BasePOM
    {
        #region Constructor
        public IndexPage(IWebDriver driver):base(driver)
        {
            IndexPageContent indexPageContent = new IndexPageContent();
            PageFactory.InitElements(driver, indexPageContent);
        }

        public IndexPage(IWebDriver driver, string url) : base(driver, url)
        {
            IndexPageContent indexPageContent = new IndexPageContent();
            PageFactory.InitElements(driver, indexPageContent);
        }
        #endregion
    }
}
