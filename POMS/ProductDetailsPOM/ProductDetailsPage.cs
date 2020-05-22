using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Reflection;
using UnosquareTest.Base;
using UnosquareTest.POMS.CartPOM;

namespace UnosquareTest.POMS.ProductDetailsPOM
{
    public class ProductDetailsPage : BasePOM
    {
        ProductDetailsPageContent productDetailsContent = new ProductDetailsPageContent();

        public ProductDetailsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, productDetailsContent);
            WaitUntil(productDetailsContent.SignMeUpModal, (element) => element.Displayed && element.Enabled);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            productDetailsContent.CloseSignUpModalButton.Click();
        }

        public float GetProductDetailPrice()
        {
            return float.Parse(productDetailsContent.PriceTag.Text.Substring(1));
        }

        public CartPage ClickOnAddToCart()
        {
            //Needs to scroll because of an element interception
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
            productDetailsContent.AddToCartButton.Click();
            return new CartPage(Driver);
        }


    }
}
