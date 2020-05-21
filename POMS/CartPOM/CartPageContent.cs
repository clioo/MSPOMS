
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace UnosquareTest.POMS.CartPOM
{
    public class CartPageContent
    {
        IWebDriver Driver;

        [FindsBy(How = How.CssSelector, Using = "div.item-quantity > select")]
        public IWebElement AmountDropDown { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.item-quantity > select > option")]
        public IList<IWebElement> AmountDropDownOptions { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div._2sIP_B7x > button")]
        public IWebElement CheckoutButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.XsLPvCL_  strong > span[itemprop=price]")]
        public IWebElement TotalPriceTag { get; set; }

        [FindsBy(How = How.Id, Using = "primaryArea")]
        public IWebElement PrimaryArea { get; set; }

        //primaryArea


    }
}
