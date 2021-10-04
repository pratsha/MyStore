using MyStore.PageInterfaces;
using OpenQA.Selenium;
using System;


namespace MyStore.Pages
{
    public class WomanNav : NavMenu, IWomenNav
    {
       
        public WomanNav(IWebElement element, IWebDriver driver):base(element,driver)
        {
            
        }

    }
}
