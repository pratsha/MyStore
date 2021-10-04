using MyStore.PageInterfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Pages
{
    public class SignIn :Page, ISignIn
    {
        public SignIn(IWebDriver driver) : base(driver)
        {
        }

    }
}
