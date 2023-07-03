using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReportPortal.Client.Models;
using System;
using TechTalk.SpecFlow;
using TestFramework;

namespace AutomationSpecFlow.Steps.StepsDefinition
{
    [Binding]
    public class CheckOutStepDefinitions : BaseSteps
    {
        private IConfiguration _configuration { get; set; }

        public CheckOutStepDefinitions(BrowserHost browserHost, FeatureContext featureContext, IConfiguration configuration) : base(browserHost, featureContext)
        {
            _configuration = configuration;

        }

        [When(@"I select a product")]
        public void WhenISelectAProduct()
        {
            Driver.Click(By.Id("add-to-cart-sauce-labs-backpack"));
            Driver.Click(By.Id("add-to-cart-sauce-labs-bike-light"));
            Driver.Click(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));
        }

        [Then(@"go to checkout page and complete the fields")]
        public void ThenGoToCheckoutPageAndCompleteTheFields(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                foreach (string value in row.Values)
                {
                    Driver.SendKeys(By.Id("first-name"),value);
                    Driver.SendKeys(By.Id("last-name"),value);
                    Driver.SendKeys(By.Id("postal-code"),value);
                }
            }
        }
    }
}
