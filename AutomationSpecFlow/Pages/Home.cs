using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSpecFlow.Pages
{
    internal class Home
    {
        private IWebDriver driver;
        
        public Home(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AccessSite(string url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }
    }
}
