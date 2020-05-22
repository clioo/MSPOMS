using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using UnosquareTest.Base;

namespace UnosquareTest.POMS.CartPOM
{
    public class CartPage : BasePOM
    {
        WebDriverWait Wait;

        private CartPageContent cartPageContent = new CartPageContent();

        public CartPage(IWebDriver driver) : base(driver)
        {
            //need to wait for transition otherwise, pagefactory doesn't find elements
            PageFactory.InitElements(driver, cartPageContent);
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Wait.Until(ExpectedConditions.ElementToBeClickable(cartPageContent.PrimaryArea));
        }

        public void SetQuantityAmount(int amount)
        {
            if (amount > cartPageContent.AmountDropDownOptions.Count ||
                amount < 1) return;
            cartPageContent.AmountDropDown.Click();
            //Wait until dropdown is displayed
            WaitUntil(cartPageContent.AmountDropDownOptions[0], (element) => element.Displayed);
            float expectedPrice = GetTotalPrice() * amount;
            //Click not choosing sometimes and takes time to refresh totals, needed a while loop with timeout
            var watch = System.Diagnostics.Stopwatch.StartNew();
            while (watch.ElapsedMilliseconds < 30000)
            {
                cartPageContent.AmountDropDownOptions[amount - 1].Click();
                if (GetTotalPrice() == expectedPrice) break;
            }

        }


        public float GetTotalPrice()
        {
            float price = float.Parse(cartPageContent.TotalPriceTag.Text.Substring(1));
            return price;
        }

    }
}
