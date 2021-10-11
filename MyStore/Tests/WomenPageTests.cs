using MyStore.Drivers;
using MyStore.PageInterface;
using MyStore.PageInterfaces;
using MyStore.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Tests
{
    [TestFixture]
    public class WomenPageTests
    {
        IWebDriver driver;
        ILandingPage landingPage;
        IWomenPage womenPage;
        ITestPageFactory testPageFactory;

        [OneTimeSetUp]
        public void TestSetup()
        {
            driver = DriverFactory.GetChromeDriver();
            driver.Manage().Window.Maximize();
            testPageFactory = TestPageAccessor.GetTestPageFactory(driver);
            landingPage = testPageFactory.GetPageFactory<ILandingPage>();
            womenPage = testPageFactory.GetPageFactory<IWomenPage>();
            landingPage.LoadPage();

        }
        [Test, Order(1)]
        public void WomenPage_Navigate()
        {
            var title=landingPage.Navigate_WomenPage();
            Assert.IsTrue(title.Contains("Women"));
        }

        [Test, Order(2)]
        public void WomenPage_ExpandFirst()
        {
           bool isExpanded= womenPage.Expand_FirstTreeNode();
            Assert.IsTrue(isExpanded);
        }

        [Test, Order(3)]
        public void WomenPage_ExpandSecond()
        {
            bool isExpanded = womenPage.Expand_SecondTreeNode();
            Assert.IsTrue(isExpanded);
        }
    }
}
