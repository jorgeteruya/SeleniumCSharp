using AutomationSpecFlow.Suport;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using TechTalk.SpecFlow.Assist;
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

        [When(@"I select a <Product>")]
        public void WhenISelectAProduct(Table table)
        {

            Driver.Click(By.Id("add-to-cart-sauce-labs-backpack"));
            Driver.Click(By.Id("add-to-cart-sauce-labs-bike-light"));
            Driver.Click(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));
        }


        [Then(@"go to checkout page and complete the fields below")]
        public void ThenGoToCheckoutPageAndCompleteTheFieldsBelow(Table table)
        {
            var data = table.CreateInstance<Context>();

            string firstName = data.firstName;
            string lastName = data.lastName;
            string zipCode = data.zipCode;

            Driver.Click(By.XPath("//div[@id='shopping_cart_container']//a[1]"));
            Driver.Click(By.Id("checkout"));

            Driver.SendKeys(By.Id("first-name"), firstName);
            Driver.SendKeys(By.Id("last-name"), lastName);
            Driver.SendKeys(By.Id("postal-code"), zipCode);
            Thread.Sleep(2000);
        }

    }
}
