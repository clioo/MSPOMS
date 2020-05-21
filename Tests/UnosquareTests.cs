using NUnit.Framework;
using System.Threading;
using UnosquareTest.Base;
using UnosquareTest.PageObjects;

namespace UnosquareTest.Tests
{
    public class UnosquareTests : BaseTest
    {
        [Test]
        public void ValidateMenuItems()
        {
            IndexPage indexPage = new IndexPage(Driver, Url);
            Thread.Sleep(4000);
        }
    }
}
