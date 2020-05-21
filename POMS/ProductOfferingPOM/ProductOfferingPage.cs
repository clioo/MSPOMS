using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using UnosquareTest.Base;
using UnosquareTest.POMS.ProductDetailsPOM;

namespace UnosquareTest.POMS.ProductOfferingPOM
{
    public class ProductOfferingPage : BasePOM
    {
        private ProductOfferingContent productOfferingContent = new ProductOfferingContent();
        public ProductOfferingPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, productOfferingContent);
            WaitUntil(productOfferingContent.LanguageModal, (element) => element.Displayed);
            productOfferingContent.CloseModalButton.Click();
        }

        public void PrintPriceTags(int numberToPrint = 3)
        {
            Console.WriteLine("***Price tags***");
            if (numberToPrint > productOfferingContent.PriceTags.Count ||
                numberToPrint < 0) numberToPrint = 3;
            for (int i = 0; i < numberToPrint; i++)
            {
                Console.WriteLine(productOfferingContent.PriceTags[i].Text);
            }
        }

        public float GetPriceByIndex(int index = 0)
        {
            if (index > productOfferingContent.PriceTags.Count ||
                index < 0) index = 0;
            float price = float.Parse(productOfferingContent.PriceTags[index].Text.Substring(1));
            return price;
        }

        public ProductDetailsPage ClickOnPriceTagByIndex(int index = 0)
        {
            if (index > productOfferingContent.PriceTags.Count ||
                index < 0) index = 0;
            productOfferingContent.PriceTags[index].Click();
            return new ProductDetailsPage(Driver);
        }

    }
}
