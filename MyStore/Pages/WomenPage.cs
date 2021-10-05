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

        IReadOnlyCollection<IWebElement> We_ElementsInFirstList  => We_LeftColumnBlockContent.FindElements(By.XPath("//li[1]/ul/li[1]"));
        IReadOnlyCollection<IWebElement> We_ElementsInSecondList => We_LeftColumnBlockContent.FindElements(By.XPath("//li[1]/ul/li[2]"));
        public bool Expand_FirstTreeNode()
        {
            We_FirstLeftColumnExpandCollapse.Click();
          

            bool isDisplayed = false;

            foreach (var item in We_ElementsInFirstList)
            {
                isDisplayed = item.Displayed ? true : false;
                if(!isDisplayed)
                {
                    break;
                }
            }
            return isDisplayed;
        }
        public bool Expand_SecondTreeNode()
        {
            We_SecondLeftColumnExpandCollapse.Click();
            bool isDisplayed=false;
           //        Console.WriteLine(We_LeftColumnBlockContent.FindElements(By.CssSelector("[class='grower CLOSE']")).Count);
            foreach (var item in We_ElementsInSecondList)
            {
                isDisplayed=item.Displayed ? true : false;
                if (!isDisplayed)
                {
                    break;
                }
            }
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
