using MyStore.PageInterface;
using MyStore.PageInterfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace MyStore.Pages
{
    public class LandingPage : Page,ILandingPage
    {
        private readonly string langingPageURL = "http://automationpractice.com";
       
        public LandingPage(IWebDriver driver):base(driver)
        {
            base.Url = langingPageURL;
        }
        public IWebElement We_ContactUs { get => We_Header.FindElement(By.Id("contact-link"));  }

        public IWebElement We_SearchTextBox { get => We_Header.FindElement(By.Id("search_query_top")); }
  
        public IWebElement We_SearchIcon { get => We_Header.FindElement(By.Name("submit_search")); }

        public IProductContainer ProductContainer { get => new ProductContainer(We_CenterColumn, Driver, "ul[id='homefeatured']"); }


        public IWebElement We_HomepPageSlider { get => We_ColumnContainer.FindElement(By.Id("homepage-slider")); }

        public IWebElement We_HomeHtmlContent { get=> We_CenterColumn.FindElement(By.Id("htmlcontent_home")); }
        public string ContactUs()
        {
            We_ContactUs.Click();
            return Driver.Title;
        }
       

        public string SearchWithEnterKey(string text)
        {
            We_SearchTextBox.SendKeys(text);
            We_SearchTextBox.SendKeys(Keys.Enter);
            return Driver.Title;
        }

        public string SearchWithSearchButton(string text)
        {
            We_SearchTextBox.SendKeys(text);
            We_SearchIcon.Click();
            return Driver.Title;

        }

        public bool HoverOnProduct(int index)
        {
            return ProductContainer.HoverOnProduct(index).Displayed;

        }
        public bool LandingPage_AddToCart(int index)
        {
             ProductContainer.HoverOnProduct(index).Click();
             return We_DialogLayerCart.Displayed;
        }

        public bool LandingPage_VerifySliderImages()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var slidersImages = We_HomepPageSlider.FindElements(By.CssSelector("li[class='homeslider-container']"));
         
            int index = slidersImages.Count;
            //Console.WriteLine(index);
            while (index > 0)
            {

                if (!wait.Until(Driver => slidersImages[index - 1].Displayed))
                {
                    return false;
                }

                index--;
                
            }
            return true;
                
        }

        public bool VerifyHTMLDiv_Images()
        {
            var images = We_HomeHtmlContent.FindElements(By.TagName("img"));
            foreach (var image in images)
            {
                if(!image.Displayed)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
