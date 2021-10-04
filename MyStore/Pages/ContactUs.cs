using MyStore.PageInterfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Pages
{
    class ContactUs : Page, IContactUS
    {
        private readonly string contactUsPageURL = "http://automationpractice.com/index.php?controller=contact";
        public ContactUs(IWebDriver driver):base(driver)
        {
            base.Url = contactUsPageURL;
        }


        public IWebElement We_SubjectHeadingddl { get => GetSubjectHeadingddl(); }


        public IWebElement GetSubjectHeadingddl()
        {            
            return Driver.FindElement(By.Id("id_contact"));
        }

        public IWebElement GetSubjectHeadingDdl()
        {
            throw new NotImplementedException();
        }
    }
}
