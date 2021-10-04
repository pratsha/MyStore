using MyStore.Drivers;
using MyStore.PageInterface;
using MyStore.PageInterfaces;
using MyStore.Pages;
using NUnit.Framework;
using OpenQA.Selenium;


namespace MyStore.Tests
{
    [TestFixture]
    public class ContactUSTests
    {
        IWebDriver driver;
        IContactUS contactUS;
        ILandingPage landingPage;
        ITestPageFactory testPageFactory;

        [OneTimeSetUp]
        public void TestSetup()
        {
            driver = DriverFactory.GetChromeDriver();
            driver.Manage().Window.Maximize();
            testPageFactory = TestPageAccessor.GetTestPageFactory(driver);
            landingPage=testPageFactory.GetPageFactory<ILandingPage>();
            contactUS = testPageFactory.GetPageFactory<IContactUS>();
            
        }

        [Test, Order(1)]
        public void ContactUS_Navigate()
        {
            landingPage.LoadPage();
            landingPage.ContactUs();
            string title=contactUS.GetTitle();

            Assert.IsTrue(title.Contains("Contact us"));           
        }

        [Test, Order(2)]
        public void ContactUs_ReturnHome()
        {
            bool isHome = contactUS.NavigateHome();
            Assert.IsTrue(isHome);
            landingPage.ContactUs();
        }

        [Test, Order(3)]
        public void ContactUs_Hover_WomenNAV()
        {
            bool isMoved = contactUS.MoveToWomenNav();
            Assert.IsTrue(isMoved);
        }

        [Test, Order(4)]
        public void ContactUs_Hover_DressesNAV()
        {
            bool isMoved = contactUS.MoveToDressesNav();
            Assert.IsTrue(isMoved);
        }

        [Test, Order(5)]
        public void ContactUs_Hover_TShirtNav()
        {
            bool isMoved = contactUS.MoveToTShirtNav();
            Assert.IsTrue(isMoved);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
           
        }
    }
}
