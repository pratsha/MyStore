using MyStore.Drivers;
using MyStore.PageInterface;
using MyStore.PageInterfaces;
using MyStore.Pages;
using NUnit.Framework;
using OpenQA.Selenium;


namespace MyStore.Tests
{
    [TestFixture]
    public class SignInTests
    {
        IWebDriver driver;
        ILandingPage landingPage;
        ISignIn signIn;
        ITestPageFactory testPageFactory;

        [OneTimeSetUp]
        public void TestSetup()
        {
            driver = DriverFactory.GetChromeDriver();
            driver.Manage().Window.Maximize();
            testPageFactory = TestPageAccessor.GetTestPageFactory(driver);
            landingPage = testPageFactory.GetPageFactory<ILandingPage>();
            signIn = testPageFactory.GetPageFactory<ISignIn>();
            landingPage.LoadPage();

        }
        [Test, Order(1)]
        public void SignIn_FromLandingPage_VerifyPage()
        {
            landingPage.LandingPage_AddToCart(2);
            landingPage.ContinueShopping();
            string title=landingPage.SingIn();
            Assert.IsTrue(title.Contains("Login"));
        }

        [Test, Order(2)]
        public void SignIn_Hover_WomenNAV()
        {
            bool isMoved = signIn.MoveToWomenNav();
            Assert.IsTrue(isMoved);
        }

        [Test, Order(3)]
        public void SignIn_Hover_DressesNAV()
        {
            bool isMoved = signIn.MoveToDressesNav();
            Assert.IsTrue(isMoved);
        }

        [Test, Order(4)]
        public void SignIn_Hover_TShirtNav()
        {
            bool isMoved = signIn.MoveToTShirtNav();
            Assert.IsTrue(isMoved);
        }

       
        [Test, Order(5)]
        public void SignIn_Hover_Cart()
        {
            bool isMoved = signIn.Hover_Cart();
            Assert.IsTrue(isMoved);
        }
    }
}
