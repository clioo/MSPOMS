using NUnit.Framework;
using UnosquareTest.Base;
using UnosquareTest.POMS.CartPOM;
using UnosquareTest.POMS.IndexPOM;
using UnosquareTest.POMS.ProductDetailsPOM;
using UnosquareTest.POMS.ProductOfferingPOM;
using UnosquareTest.POMS.WindowsPOM;

namespace UnosquareTest.Tests
{
    public class UnosquareTests : BaseTest
    {
        [Test]
        public void ValidateMenuItems()
        {
            IndexPage indexPage = new IndexPage(Driver, Url);
            bool areMenuItemsPresent = indexPage.AreMenuItemsPresent();
            Assert.IsTrue(areMenuItemsPresent, "Not all menu items are present.");
            WindowsPage windowsPage = indexPage.ClickOnWindowsMenuItem();
            windowsPage.ClickOnWindows10Menu();
            windowsPage.PrintAllWindowsDropDownOptions();
            windowsPage.ClickOnSearchButton();
            ProductOfferingPage productOfferingPage = windowsPage.SearchQuery("Visual studio");
            productOfferingPage.PrintPriceTags();
            float offeringPrice = productOfferingPage.GetPriceByIndex(0);
            ProductDetailsPage productDetailsPage = productOfferingPage.ClickOnPriceTagByIndex(0);
            float productDetailPrice = productDetailsPage.GetProductDetailPrice();
            Assert.AreEqual(offeringPrice, productDetailPrice, "Offering price is not the same as detail price");
            CartPage cartPage = productDetailsPage.ClickOnAddToCart();
            int quantity = 20;
            cartPage.SetQuantityAmount(quantity);

            //Price assertions
            float totalPrice = cartPage.GetTotalPrice();
            float cartPageSinglePrice = totalPrice / quantity;
            float expectedTotalPrice = offeringPrice * quantity;
            Assert.AreEqual(cartPageSinglePrice, productDetailPrice, offeringPrice, "Prices does not match.");
            Assert.AreEqual(totalPrice, expectedTotalPrice, "Total prices does not match");

        }
    }
}
