using MyStore.PageInterface;
using MyStore.PageInterfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MyStore.Pages
{
    public class Search :  Page, ISearch
    {

        public Search(IWebDriver driver) : base(driver)
        {
           
        }


        public IProductContainer ProductContainer { get => new ProductContainer(We_CenterColumn,Driver, "ul[class='product_list grid row']"); }
        

      

        public List<string> GetDisplayedProductNames()
        {
            return this.ProductContainer.GetProductNames();
        }

        public int GetDisplyedProductCount()
        {
            return this.ProductContainer.GetProducts().Count();
        }

        public int GetSearchResultCount()
        {
            string searchReturenText= We_ColumnContainer.FindElement(By.CssSelector("[class='heading-counter']")).Text;
            var search = searchReturenText.Split(' ');
            return Convert.ToInt32(search[0]);
        }

        public int GetSearchResults()
        {
            throw new NotImplementedException();
        }

       

        public bool IsImageDisplayed()
        {
            return ProductContainer.IsImageDisplayed();
        }

        public bool HoverOnProduct(int index)
        {
           return ProductContainer.HoverOnProduct(index).Displayed;
             
        }

        public bool Search_AddToCart(int index)
        {
            ProductContainer.HoverOnProduct(index).Click();
            return We_DialogLayerCart.Displayed;
        }

        public bool Search_ContinueShopping()
        {
            throw new NotImplementedException();
        }

    }
}
