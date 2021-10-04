using MyStore.Drivers;
using MyStore.PageInterface;
using MyStore.PageInterfaces;
using MyStore.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;


namespace MyStore.Tests
{
    [TestFixture]
    public class SearchTests
    {
         IWebDriver driver;
         ILandingPage landingPage;
         ISearch search;
         ITestPageFactory testPageFactory;

        [OneTimeSetUp]
        public void TestSetup()
        {
            driver = DriverFactory.GetChromeDriver();
            driver.Manage().Window.Maximize();
            testPageFactory = TestPageAccessor.GetTestPageFactory(driver);
            landingPage = testPageFactory.GetPageFactory<ILandingPage>();
            search = testPageFactory.GetPageFactory<ISearch>();
            landingPage.LoadPage();
        }
        [Test, Order(1)]
        public void Search_SearchText_VerifyResults()
        {
            landingPage.SearchWithEnterKey("Summer");
            int count=search.GetSearchResultCount();
          
            Assert.AreEqual(4, count, "Results are not matching.");
            
        }

        [Test, Order(2)]
        public void Search_SearchText_VerifyDisplyedProductCount()
        {
            int count = search.GetDisplyedProductCount();
            Assert.AreEqual(4, count, "Results are not matching.");

        }

        [Test, Order(3)]
        public void Search_SearchText_VerifyProductsNames()
        {
            List<string> summerProductName =new  List<string>();
            bool isAvailable=false;
            summerProductName.Add("Printed Summer Dress");
            summerProductName.Add("Printed Summer Dress");
            summerProductName.Add("Printed Chiffon Dress");
            summerProductName.Add("Faded Short Sleeve T - shirts");


            var productNames = search.GetDisplayedProductNames();
           
            foreach (var item in productNames)
            {
                isAvailable= summerProductName.Contains(item) ? true : false;
                if(!isAvailable)
                {
                    break;
                }
            }

        }

        [Test, Order(4)]
        public void Search_VerifyImage()
        {
            Assert.IsTrue(search.IsImageDisplayed(), "Image is missing.");
        }

        [Test, Order(5)]
        public void Search_Hover_ToElement_VeriyHover()
        {
            Assert.IsTrue(search.HoverOnProduct(2), "No Hover.");
        }

        [Test, Order(5)]
        public void Search_AddToCart_VerifyAdded()
        {
            Assert.IsTrue(search.Search_AddToCart(3), "Not Added.");
        }

        [Test, Order(6)]
        public void Search_ContinueShopping()
        {
            Assert.IsTrue(search.ContinueShopping(), "Dialog Not Closed.");
        }
        [OneTimeTearDown]
        public void TearDown()
        {
           
        }
    }
}
