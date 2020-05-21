
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnosquareTest.POMS.ProductDetailsPOM
{
    public class ProductDetailsPageContent
    {
        IWebDriver Driver;

        [FindsBy(How = How.ClassName, Using = "sfw-dialog")]
        public IWebElement SignMeUpModal { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.sfw-dialog div.glyph-cancel")]
        public IWebElement CloseSignUpModalButton { get; set; }

        [FindsBy(How = How.Id, Using = "ProductPrice_productPrice_PriceContainer")]
        public IWebElement PriceTag { get; set; }

        [FindsBy(How = How.Id, Using = "buttonPanel_AddToCartButton")]
        public IWebElement AddToCartButton { get; set; }

    }
}
