using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestFramework
{
    public class BaseSteps
    {
        public IWebDriver Driver { get; set; }
        public FeatureContext FeatureContext { get; set; }

        public BaseSteps(BrowserHost browserHost, FeatureContext featureContext) 
        {
            Driver = browserHost.WebDriver;
            FeatureContext = featureContext;
        }
    }
}
