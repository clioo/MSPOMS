using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace UnosquareTest.POMS.ProductOfferingPOM
{
    public class ProductOfferingContent
    {
        IWebDriver Driver;

        [FindsBy(How = How.CssSelector, Using = "div.c-price span[itemprop=price]")]
        public IList<IWebElement> PriceTags { get; set; }

        [FindsBy(How = How.Id, Using = "R1MarketRedirect-1")]
        public IWebElement LanguageModal { get; set; }

        //R1MarketRedirect-close
        [FindsBy(How = How.Id, Using = "R1MarketRedirect-close")]
        public IWebElement CloseModalButton { get; set; }

    }
}
