using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using Microsoft.Edge.SeleniumTools;

namespace MyStore.Drivers
{
    public class DriverFactory
    {
       //static string outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Drivers";

        public static string OutputDirectory { get => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Drivers"; }
        private static IWebDriver driver;
        public static IWebDriver GetFireFoxDriver()
        {
            throw new NotImplementedException();
        }

        public static IWebDriver GetChromeDriver()
        {
            return driver ?? (driver = new ChromeDriver(OutputDirectory));
            
        }
        
        public static IWebDriver GetEdgeDriver()
        {
            var options = new EdgeOptions();
            options.UseChromium = true;
          
            return driver ?? (driver = new EdgeDriver(OutputDirectory, options));
        }

        //public IWebDriver GetFireFoxDriver()
        //{
        //    return NotImplementedException;
        //}
    }
}
