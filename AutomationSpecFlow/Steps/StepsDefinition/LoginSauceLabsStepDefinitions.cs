
using AventStack.ExtentReports.Gherkin.Model;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestFramework;

namespace AutomationSpecFlow.Steps.StepsDefinition
{
    [Binding]
    public class LoginSauceLabsStepDefinitions : BaseSteps
    {
        private IConfiguration _configuration { get; set; }
        
        public LoginSauceLabsStepDefinitions(BrowserHost browserHost, FeatureContext featureContext, IConfiguration configuration) : base(browserHost, featureContext)
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
            Driver.SendKeys(By.Id("password"), password);
            Driver.Click(By.Id("login-button"));
        }

        
        [Then(@"the home page will load if the user have access")]
        public void ThenTheHomePageWillLoadIfTheUserHaveAccess()
        {
            
            if (Driver.IsElementPresent(By.Id("react-burger-menu-btn")).Equals(true))
            {
                // Assert.Pass("User have access");
                Assert.IsTrue(true);
            }
            else if (Driver.IsElementPresent(By.XPath("//h3[@data-test='error']")).Equals(true))
            {
                //Assert.Pass("Locked user, don't have access");
                Assert.IsTrue(true);

            }
            else { Assert.Fail("Error user not found"); }
        }

    }
}
