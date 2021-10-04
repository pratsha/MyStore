using MyStore.PageInterfaces;
using OpenQA.Selenium;
using System;

namespace MyStore.Pages
{
    public class TShirtNav : NavMenu, ITShirtNav
    {
        public TShirtNav(IWebElement element, IWebDriver driver) : base(element, driver)
        {
        }

    }
}
