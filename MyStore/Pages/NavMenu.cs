using MyStore.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MyStore.PageInterfaces
{
    public class NavMenu:Page
    {
        Actions act;
        public NavMenu( IWebElement element, IWebDriver driver) :base(driver)
        {
            this.WE_Nav = element;
        }


        public IWebElement WE_Nav { get; set; }
        public Actions Act { get => new Actions(Driver); set => act = value; }
        public bool Hover()
        {

            Act.MoveToElement(WE_Nav).Build().Perform();

            var eleUl =
            WE_Nav.FindElements(By.XPath("ul"));
            if (eleUl.Count == 0 )
            {
                return WE_Nav.FindElement(By.TagName("a")).Displayed;
            }
            else
            {
                return eleUl[0].Displayed;
            }

        }
       

    }
}
