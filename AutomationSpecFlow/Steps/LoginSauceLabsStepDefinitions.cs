using AventStack.ExtentReports.Gherkin.Model;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestFramework;

namespace AutomationSpecFlow.Steps
{
    [Binding]
    public class LoginSauceLabsStepDefinitions : BaseSteps
    {
        private IConfiguration _configuration { get; set; }
        public LoginSauceLabsStepDefinitions(BrowserHost browserHost, FeatureContext featureContext, IConfiguration configuration):base(browserHost, featureContext)
        {
            _configuration = configuration;
        }

        [Given(@"I access the SauceLabs website")]
        public void GivenIAccessTheSauceLabsWebsite()
        {
            Driver.Navigate().GoToUrl(_configuration["BaseUrl"]);
        }

        [When(@"I input the (.*)")]
        public void WhenIInputTheUser(string user)
        {
            Driver.SendKeys(By.Id("user-name"), user);
        }

        [When(@"input (.*)")]
        public void WhenInputPassword(string password)
        {
            Driver.SendKeys(By.Id("password"),password);
            Driver.Click(By.Id("login-button"));
        }

        [Then(@"the home page will load")]
        public void ThenTheHomePageWillLoadValidation()
        {
            Driver.Click(By.Id("add-to-cart-sauce-labs-backpack"));
            Driver.Click(By.Id("add-to-cart-sauce-labs-bike-light"));
            Driver.Click(By.Id("shopping_cart_container"));
            Thread.Sleep(10000);
        }
    }
}
