using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework
{
    public class BrowserHost
    {
        public IWebDriver? WebDriver { get; set; }

        public void InitializeWebDriver()
        {
            try
            {
                WebDriver = new ChromeDriver();
                //WebDriver.Manage().Window.Maximize();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Exception] {ex.Message}");
            }
        }

        public void DisposeWebDriver()
        {
            WebDriver.Quit();
            WebDriver.Dispose();
        }
    }
}
