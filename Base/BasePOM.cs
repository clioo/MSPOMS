using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnosquareTest.Base
{
    public abstract class BasePOM
    {
        protected IWebDriver Driver;
        private WebDriverWait Wait { get; set; }

        #region Constructor
        public BasePOM(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //Waits until page is completely loaded
            Wait.Until(Driver => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));

        }

        public BasePOM(IWebDriver driver, string url)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Driver.Navigate().GoToUrl(url);
        }
        #endregion

        public void WaitUntil(IWebElement element,Func<IWebElement, bool> until)
        {
            try
            {
                Wait.Until<IWebElement>(d =>
                {
                    //given conditions returns true
                    until(element);
                    return element;

                });
            }
            catch (Exception)
            {
                throw new ElementNotVisibleException("Element not found.");
            }
        }

    }
}
