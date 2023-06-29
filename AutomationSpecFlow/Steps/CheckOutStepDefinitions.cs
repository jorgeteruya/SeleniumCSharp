using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReportPortal.Client.Models;
using System;
using TechTalk.SpecFlow;

namespace AutomationSpecFlow.Steps
{
    [Binding]
    public class CheckOutStepDefinitions
    {
        private readonly IWebDriver driver = new ChromeDriver();

        [Given(@"I logon on the (.*) and (.*)")]
        public void GivenILogonOnTheSystemStandard_UserAndSecret_Sauce(string user, string password)
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.FindElement(By.Id("user-name")).SendKeys(user);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();
        }

        [When(@"I select a product")]
        public void WhenISelectAProduct()
        {
            driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            driver.FindElement(By.Id("checkout")).Click();
        }

        [Then(@"go to checkout page and complete the fields")]
        public void ThenGoToCheckoutPageAndCompleteTheFields(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                foreach (string value in row.Values)
                {
                    driver.FindElement(By.Id("first-name")).SendKeys(value);
                    driver.FindElement(By.Id("last-name")).SendKeys(value);
                    driver.FindElement(By.Id("postal-code")).SendKeys(value);
                }
            }
            
        }
    }
}
