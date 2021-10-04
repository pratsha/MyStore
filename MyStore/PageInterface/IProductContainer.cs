using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyStore.PageInterface
{
    public interface IProductContainer
    {
        bool AddToCart();
        string DisplayMore();
        bool IsImageDisplayed();
        string GetProductName(int index);
        IReadOnlyCollection<IWebElement> GetProducts();
        List<string> GetProductNames();
        IReadOnlyCollection<IWebElement> GetProductContainers();
        IWebElement HoverOnProduct(int index);
    }
}
