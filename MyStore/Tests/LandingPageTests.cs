using OpenQA.Selenium;
using MyStore.Drivers;
using MyStore.PageInterfaces;
using MyStore.Pages;
using NUnit.Framework;
using MyStore.PageInterface;

namespace MyStore.Tests
{
 
    [TestFixture]
    public class LandingPageTests
    {
         IWebDriver driver;
         ILandingPage landingPage;
         ITestPageFactory testPageFactory;

        [OneTimeSetUp]
        public void TestSetup()
        {
            driver = DriverFactory.GetChromeDriver();
            testPageFactory = TestPageAccessor.GetTestPageFactory(driver);
            landingPage = testPageFactory.GetPageFactory<ILandingPage>();
          
            driver.Manage().Window.Maximize();
        }

        [Test, Order(1)]
        public void LandingPage_Navigate()
        {
            bool isLoaded = landingPage.LoadPage();
            Assert.IsTrue(isLoaded);
        }

        [Test, Order(2)]
        public void LandingPage_ContactUs_Navigate()
        {
            string title = landingPage.ContactUs();
            Assert.IsTrue(title.Contains("Contact"));
        }

        [Test, Order(3)]
        public void LandingPage_NavigateBack()
        {
            string title = landingPage.NavigateBack();
            Assert.IsTrue(title.Contains("Store"));
        }

        [Test, Order(4)]
        public void LandingPage_Hover_WomenNAV()
        {
            bool isMoved = landingPage.MoveToWomenNav();
            Assert.IsTrue(isMoved);
        }

        [Test, Order(5)]
        public void LandingPage_Hover_DressesNAV()
        {
            bool isMoved = landingPage.MoveToDressesNav();
            Assert.IsTrue(isMoved);
        }

        [Test, Order(6)]
        public void LandingPage_Hover_TShirtNav()
        {
            bool isMoved = landingPage.MoveToTShirtNav();
            Assert.IsTrue(isMoved);
        }

        [Test, Order(7)]
        public void LandingPage_Search_WithEnter_VerifyPage()
        {
            string title = landingPage.SearchWithEnterKey("Summer");
            Assert.IsTrue(title.Contains("Search"));
        }

        [Test, Order(9)]
        public void LandingPage_Search_VerifyPage()
        {
            string title = landingPage.SearchWithSearchButton("Summer");
            Assert.IsTrue(title.Contains("Search"));
        }

        [Test, Order(8)]
        public void LandingPage_ReturnHome()
        {
            bool isHome = landingPage.NavigateHome();
            Assert.IsTrue(isHome);
        }
        [Test, Order(10)]
        public void LandingPage_Hover()
        {
            landingPage.NavigateHome();
            Assert.IsTrue(landingPage.HoverOnProduct(2), "No Hover.");
        }
        [Test, Order(11)]
        public void LandingPage_AddToCart()
        {

            Assert.IsTrue(landingPage.LandingPage_AddToCart(3), "Not Added.");
        }

        [Test, Order(12)]
        public void LandingPage_ContinueShopping()
        {
            Assert.IsTrue(landingPage.ContinueShopping(), "Dialog Not Closed.");
        }
        [Test, Order(13)]
        public void LandingPage_VerifySliderImages()
        {
            landingPage.LoadPage();
            Assert.IsTrue(landingPage.LandingPage_VerifySliderImages(), "Not getting displayed");
        }

        [Test, Order(14)]
        public void LandingPage_VerifyHTMLDivImages()
        {
            Assert.IsTrue(landingPage.VerifyHTMLDiv_Images(), "Not getting displayed");
        }

        [Test, Order(15)]
        public void LandingPage_NavigateToWomenPage()
        {
            Assert.IsTrue(landingPage.Navigate_WomenPage().Contains("Women"), "Not navigated to Women page.");
        }
        [OneTimeTearDown]
        public void TearDown()
        {
           
        }
       
    }
}
