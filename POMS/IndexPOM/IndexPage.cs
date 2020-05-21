using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnosquareTest.Base;
using UnosquareTest.POMS.WindowsPOM;

namespace UnosquareTest.POMS.IndexPOM
{
    public class IndexPage : BasePOM
    {
        IndexPageContent indexPageContent = new IndexPageContent();
        #region Constructor
        public IndexPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, indexPageContent);
        }

        public IndexPage(IWebDriver driver, string url) : base(driver, url)
        {
            PageFactory.InitElements(driver, indexPageContent);
        }
        #endregion


        public bool AreMenuItemsPresent()
        {
            const int menuItems = 6;
            int desplayedItems = 0;
            //Office menu
            WaitUntil(indexPageContent.OfficeMenuItem, (element) => element.Displayed);
            desplayedItems += indexPageContent.OfficeMenuItem.Displayed ? 1 : 0;
            //WindowsMenu
            WaitUntil(indexPageContent.WindowsMenuItem, (element) => element.Displayed);
            desplayedItems += indexPageContent.WindowsMenuItem.Displayed ? 1 : 0;
            //SurfaceMenu
            WaitUntil(indexPageContent.SurfaceMenuItem, (element) => element.Displayed);
            desplayedItems += indexPageContent.SurfaceMenuItem.Displayed ? 1 : 0;
            //Xbox Menu
            WaitUntil(indexPageContent.XboxMenuItem, (element) => element.Displayed);
            desplayedItems += indexPageContent.XboxMenuItem.Displayed ? 1 : 0;
            //Deals menu
            WaitUntil(indexPageContent.DealsMenuItem, (element) => element.Displayed);
            desplayedItems += indexPageContent.DealsMenuItem.Displayed ? 1 : 0;
            //Support Menu
            WaitUntil(indexPageContent.SupportMenuItem, (element) => element.Displayed);
            desplayedItems += indexPageContent.SupportMenuItem.Displayed ? 1 : 0;
            bool areMenuItemsPresent = desplayedItems == menuItems;
            return areMenuItemsPresent;
        }

        public WindowsPage ClickOnWindowsMenuItem()
        {
            indexPageContent.WindowsMenuItem.Click();
            return new WindowsPage(Driver);
        }
    }
}
