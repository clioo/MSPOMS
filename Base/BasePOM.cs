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
        }

        public BasePOM(IWebDriver driver, string url)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Driver.Navigate().GoToUrl(url);
        }
        #endregion

        public IWebElement GetElementWaitUntil(By by, Func<IWebElement, bool> until,
                                               int waitSeconds = 30)
        {
            Wait.Timeout = TimeSpan.FromSeconds(waitSeconds);
            IWebElement element = null;
            try
            {
                var waitedElement = Wait.Until<IWebElement>(d =>
                {
                    element = Driver.FindElement(by);

                    //given conditions returns true
                    if (until(element)) return element;

                    return element;
                });
                return element;
            }
            catch (Exception)
            {
                return element;
            }
        }
    }
}
