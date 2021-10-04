using MyStore.Drivers;
using NUnit.Framework;


namespace MyStore.Tests
{
    [SetUpFixture]
    public class TestSetupClean
    {
        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            var driver = DriverFactory.GetChromeDriver();
            driver.Close();
            driver.Quit();
        }
    }
}
