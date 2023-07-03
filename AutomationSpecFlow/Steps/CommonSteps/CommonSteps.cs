using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System.Globalization;
using TestFramework;

namespace AutomationSpecFlow.Steps.CommonSteps
{

    [Binding]
    public class CommonSteps : BaseSteps
    {

        private IConfiguration _configuration { get; set; }

        public CommonSteps(BrowserHost browserHost, FeatureContext featureContext, IConfiguration configuration) : base(browserHost, featureContext)
        {
            _configuration = configuration;
        }

        [Given(@"I login on sauce labs with user ""([^""]*)""")]
        public void GivenILoginOnSauceLabsWithUser(string user)
        {

            var password = _configuration[user + ":pw"];

            Driver.Navigate().GoToUrl(_configuration["BaseUrl"]);
            Driver.SendKeys(By.Id("user-name"), user);
            Driver.SendKeys(By.Id("password"), password);
            Driver.Click(By.Id("login-button"));

            Thread.Sleep(10000);
        }
    }
}
