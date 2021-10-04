using MyStore.PageInterfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace MyStore.Pages
{
    public class Page : IPage
    {
        public Page(IWebDriver driver)
        {
            this.Driver = driver;
        }


        public IWebDriver Driver { get; set; }
        public IWebElement We_Footer { get => GetFooterContainer(); }
        public IWebElement We_ColumnContainer { get => GetColumnContainer(); }
        public IWebElement We_Header { get => GetHeaderContainer(); }

        public IWebElement We_WomenElement { get => Driver.FindElement(By.XPath(("//*[@id='block_top_menu']/ul/li[1]"))); }
        public IWebElement We_DressesElement { get => Driver.FindElement(By.XPath(("//*[@id='block_top_menu']/ul/li[2]"))); }
        public IWebElement We_BlockTopMenu { get => Driver.FindElement(By.CssSelector("[id='block_top_menu']")); }
        public IWebElement We_TShirtNavElement { get => Driver.FindElement(By.XPath(("//*[@id='block_top_menu']/ul/li[3]"))); }
        public NavMenu WomenNav { get => new WomanNav(We_WomenElement, Driver); }
        public NavMenu DressNav { get => new DressesNav(We_DressesElement, Driver); }
        public NavMenu TShirtNav { get => new TShirtNav(We_TShirtNavElement, Driver); }
        public string Url { get; set; }


        public IWebElement We_DialogLayerCart { get => GetDialogLayerCart(); }

        public IWebElement We_DialogLayerCartContinueShopping { get => GetDialogLayerCart_ContinueShopping(); }

        public IWebElement We_CenterColumn { get => GetCenterColumn(); }

        public IWebElement We_SignIn { get => We_Header.FindElement(By.ClassName("login")); }

        public IWebElement We_Cart { get => We_Header.FindElement(By.CssSelector("a[title='View my shopping cart']")); }
        public IWebElement GetColumnContainer()
        {
            return Driver.FindElement(By.CssSelector("[class='columns-container']")); 
        }

        public IWebElement GetFooterContainer()
        {
            return Driver.FindElement(By.CssSelector("[class='footer-container']"));
        }

        public IWebElement GetHeaderContainer()
        {
            return Driver.FindElement(By.CssSelector("[class='header-container']"));
        }

        public string GetTitle()
        {
            return Driver.Title;
        }

        public bool LoadPage()
        {
            Driver.Navigate().GoToUrl(Url);
            return We_Header.Displayed;
        }


        public string NavigateBack()
        {
            this.Driver.Navigate().Back();
            return Driver.Title;
        }

        public bool NavigateHome()
        {
            this.NavigationPipe().FindElements(By.TagName("a"))[0].Click();
            return Driver.Title.Contains("My Store");
        }

        public IWebElement NavigationPipe()
        {
            return Driver.FindElement(By.CssSelector(".breadcrumb.clearfix"));

        }


        public bool MoveToWomenNav()
        {
            return WomenNav.Hover();
        }

        public bool MoveToDressesNav()
        {
            return DressNav.Hover();
        }

        public bool MoveToTShirtNav()
        {
            return TShirtNav.Hover();
        }
        public IWebElement GetDialogLayerCart()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(Driver => Driver.FindElement(By.CssSelector("[id='layer_cart']")).Displayed);
            return Driver.FindElement(By.CssSelector("[id='layer_cart']"));

        }

        public IWebElement GetDialogLayerCart_ContinueShopping()
        {
            return We_DialogLayerCart.FindElement(By.CssSelector("span[title='Continue shopping']"));

        }
        public IWebElement GetCenterColumn()
        {
            return We_ColumnContainer.FindElement(By.XPath("//*[@id='center_column']"));
        }

     

        public bool ContinueShopping()
        {
            We_DialogLayerCartContinueShopping.Click();
            return We_DialogLayerCart.Displayed;
        }

        public string SingIn()
        {
            We_SignIn.Click();
            return Driver.Title;
        }

        public IWebElement GetCart()
        {
            return We_Cart;
        }
        public bool Hover_Cart()
        {
            Actions act = new Actions(Driver);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
            act.MoveToElement(We_Cart).Build().Perform();
            return wait.Until(Driver => We_Header.FindElement(By.CssSelector("[id='button_order_cart']")).Displayed);
        }

        public string Navigate_WomenPage()
        {
            We_WomenElement.Click();
            return Driver.Title;
        }

        public string Navigate_DressesPage()
        {
            We_DressesElement.Click();
            return Driver.Title;
        }


        public string Navigate_TShirtPage()
        {
            We_TShirtNavElement.Click();
            return Driver.Title;
        }
    }
}
