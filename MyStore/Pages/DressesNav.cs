using MyStore.PageInterfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Pages
{
    public class DressesNav : NavMenu, IDressessNav
    {
        public DressesNav(IWebElement element, IWebDriver driver) : base(element, driver)
        {


        }
    }
}
