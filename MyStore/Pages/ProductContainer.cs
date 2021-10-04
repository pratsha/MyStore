using MyStore.PageInterface;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;
using System.Linq;

namespace MyStore.Pages
{
    public class ProductContainer : IProductContainer
    {
        public ProductContainer(IWebElement centerColumn, IWebDriver driver, string gridLocator)
        {
            this.We_CenterColumn = centerColumn;
            this.Driver = driver;
            this.GridLocator = gridLocator;
        }

        public ProductContainer(IWebElement centerColumn, string gridLocator)
        {
            this.We_CenterColumn = centerColumn;
            this.GridLocator = gridLocator;
        }

        public string GridLocator { get; set; }
        public IWebDriver Driver { get; set; }
        public IWebElement We_CenterColumn { get; set; }
        public IWebElement We_ProductImageLink { get; set; }
        public IWebElement We_ProductTitle { get; set; }

        public IWebElement We_ProductGrid { get => GetProductGrid(); }
        public bool AddToCart()
        {
            throw new NotImplementedException();
        }

        public string DisplayMore()
        {
            throw new NotImplementedException();
        }

        public string GetProductName(int index)
        {
            return this.GetProductNames()[index];
        }
        public List<string> GetProductNames()
        {
            var products = this.GetProducts();
            var title = new List<string>();
            foreach (var item in products)
            {
                title.Add(item.GetAttribute("title"));
            }

            return title;
        }

        public bool IsImageDisplayed()
        {
            foreach (var item in this.GetProducts())
            {
                if(!item.Displayed)
                {
                    return false;
                }
                
            }
            return true;
        }

        public IWebElement GetProductGrid()
        {
            return We_CenterColumn.FindElement(By.CssSelector(GridLocator));
        }
        public IReadOnlyCollection<IWebElement> GetProducts()
        {
            return We_ProductGrid.FindElements(By.TagName("img")); ;
        }
        //class="product-container"

        public IReadOnlyCollection<IWebElement> GetProductContainers()
        {
            return We_ProductGrid.FindElements(By.CssSelector("div[class='product-container']")); ;
        }

        public IWebElement HoverOnProduct(int index)
        {
            var product =GetProductContainers();
            var a = product.ToList<IWebElement>();
            Actions act = new Actions(Driver);
            act.MoveToElement(a[index]).Build().Perform();
            return a[index].FindElement(By.CssSelector("[title='Add to cart']"));
        }
    }
}
