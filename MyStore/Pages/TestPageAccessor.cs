using MyStore.PageInterface;
using OpenQA.Selenium;

namespace MyStore.Pages
{
    public static class TestPageAccessor
    {
        private static ITestPageFactory testPageFactory;
        public static ITestPageFactory GetTestPageFactory(IWebDriver driver)
        {
            return testPageFactory ?? (testPageFactory = new PageLoader(driver));
        }
        public static ITestPageFactory GetTestPageFactory(IWebDriver driver,IWebElement element)
        {
            return testPageFactory ?? (testPageFactory = new PageLoader(driver,element));
        }
    }
}
