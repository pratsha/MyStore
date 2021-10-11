using MyStore.PageInterface;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Pages
{
    public class WomenPage : Page, IWomenPage
    {
        public WomenPage(IWebDriver driver) : base(driver)
        {
        }

        IWebElement We_LeftColumnContainer { get=> GetLeftColumnContaine(); }
        IWebElement We_LeftColumnTitleBlock { get => We_LeftColumnContainer.FindElement(By.ClassName("title_block")); }
        IWebElement We_LeftColumnBlockContent { get => We_LeftColumnContainer.FindElement(By.ClassName("block_content"));}

        IWebElement We_FirstLeftColumnExpandCollapse { get => We_LeftColumnBlockContent.FindElement(By.XPath("//li[1]/span")); }
        IWebElement We_SecondLeftColumnExpandCollapse { get => We_LeftColumnBlockContent.FindElement(By.XPath("//li[2]/span")); }

        IWebElement We_ElementsInFirstList  => We_LeftColumnBlockContent.FindElement(By.XPath("//li[1]/ul"));
        IWebElement We_ElementsInSecondList => We_LeftColumnBlockContent.FindElement(By.XPath("//li[2]/ul"));
        public bool Expand_FirstTreeNode()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            We_FirstLeftColumnExpandCollapse.Click();
            ////*[@id="categories_block_left"]/div/ul/li[1]/ul
        
            bool isDisplayed =  Driver.FindElement(By.XPath("//*[@id='categories_block_left']/div/ul/li[1]/ul")).Displayed; 


            //foreach (var item in Driver.FindElements(By.XPath("//li[1]/ul/li[1]/ul")))
            //{
            //    Console.WriteLine(item.GetAttribute("style"));

            //    isDisplayed = wait.Until(Driver => item.Displayed);
            //    if (!isDisplayed)
            //    {
            //        break;
            //    }
            //}
            return isDisplayed;
        }
        public bool Expand_SecondTreeNode()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            We_SecondLeftColumnExpandCollapse.Click();
            bool isDisplayed = Driver.FindElement(By.XPath("//*[@id='categories_block_left']/div/ul/li[2]/ul")).Displayed;
            ////        Console.WriteLine(We_LeftColumnBlockContent.FindElements(By.CssSelector("[class='grower CLOSE']")).Count);
            //foreach (var item in We_ElementsInSecondList)
            //{

            //    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(3));
            //    Console.WriteLine(item.GetAttribute("style"));
            //    isDisplayed = wait.Until(Driver => item.Displayed);
            //    if (!isDisplayed)
            //    {
            //        break;
            //    }
            //}
            return isDisplayed;
        }
        public IWebElement GetLeftColumnContaine()
        {
            WebDriverWait wait = new WebDriverWait(Driver,TimeSpan.FromSeconds(30));
            wait.Until(Driver => We_ColumnContainer.FindElement(By.Id("left_column")).Displayed);
            return We_ColumnContainer.FindElement(By.Id("left_column"));
        }
    }
}
