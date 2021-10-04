using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

        //public IWebDriver GetFireFoxDriver()
        //{
        //    return NotImplementedException;
        //}
    }
}
