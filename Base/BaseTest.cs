using OpenQA.Selenium;
using System;
using System.IO;
using System.Configuration;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace UnosquareTest.Base
{
    public abstract class BaseTest
    {
        protected IWebDriver Driver;
        protected string Url { get; set; }

        protected virtual IWebDriver GetDriverInstance(BrowsersEnum browser)
        {
            string dir = Directory.GetCurrentDirectory();
            bool isHeadLess = bool.Parse(ConfigurationManager.AppSettings
            .Get("IsBrowserHeadless"));
            switch (browser)
            {
                case BrowsersEnum.Chrome:
                    if (isHeadLess)
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("--headless");
                        options.AddArgument("-no-sandbox");
                        options.AddArgument("--start-maximized");
                        options.AddArgument("--window-size=1920x1080");
                        return new ChromeDriver(options);
                    }
                    return new ChromeDriver();
                default:
                    throw new ArgumentException("Browser is not supported -> " + browser);
            }
        }

        [SetUp]
        public virtual void InitTest()
        {
            //default browser is Chrome
            BrowsersEnum browser = BrowsersEnum.Chrome;
            Driver = GetDriverInstance(browser);
            Driver.Manage().Window.Maximize();
            Url = ConfigurationManager.AppSettings.Get("webUrl");
        }

        [TearDown]
        public virtual void EndTest()
        {
            if (Driver != null)
                Driver.Quit();
        }

    }
}
