using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;
using UnosquareTest.Base;
using UnosquareTest.POMS.ProductOfferingPOM;

namespace UnosquareTest.POMS.WindowsPOM
{
    public class WindowsPage : BasePOM
    {
        WindowsPageContent windowsPageContent = new WindowsPageContent();

        public WindowsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, windowsPageContent);
        }

        public void ClickOnWindows10Menu()
        {
            windowsPageContent.WindowsDropDown.Click();
        }

        public void PrintAllWindowsDropDownOptions()
        {
            Console.WriteLine("***Windows Dropd    own options.***");
            foreach (IWebElement option in windowsPageContent.WindowsDropDownOptions)
            {
                //Need a thread because of a NUnit bug
                Thread.Sleep(500);
                string optionText = option.Text;
                Console.WriteLine(option.Text);
            }
        }

        public void ClickOnSearchButton()
        {
            windowsPageContent.SearchButton.Click();
            WaitUntil(windowsPageContent.SearchInput, (element) => element.Displayed);
        }

        public ProductOfferingPage SearchQuery(string query)
        {
            windowsPageContent.SearchInput.SendKeys(query);
            windowsPageContent.SearchButton.Click();
            return new ProductOfferingPage(Driver);
        }
    }
}
