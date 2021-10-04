using MyStore.Drivers;
using MyStore.PageInterface;
using MyStore.PageInterfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Pages
{
    public class PageLoader : CommonPageLoader
    {
        
        public PageLoader(IWebDriver driver)
        {
            this.map.Add(typeof(IPage), new Lazy<object>(() => new Page(driver)));
            this.map.Add(typeof(ILandingPage), new Lazy<object>(() => new LandingPage(driver)));
            this.map.Add(typeof(ISearch), new Lazy<object>(() => new Search(driver)));
            this.map.Add(typeof(IContactUS), new Lazy<object>(() => new ContactUs(driver)));
            this.map.Add(typeof(ISignIn), new Lazy<object>(() => new SignIn(driver)));
        }
        public PageLoader(IWebDriver driver, IWebElement element)
        {
            this.map.Add(typeof(IWomenNav), new Lazy<object>(() => new WomanNav( element, driver)));
            this.map.Add(typeof(ITShirtNav), new Lazy<object>(() => new TShirtNav(element, driver)));
            this.map.Add(typeof(IDressessNav), new Lazy<object>(() => new DressesNav(element, driver)));
        }

    }
}
