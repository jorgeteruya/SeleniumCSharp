using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;


namespace TestFramework
{
    public static class ExtensionMethods
    {
        public const int DEFAULT_TIMEOUT = 120;

        public static IWebElement SendKeys(this IWebDriver webDriver ,By by, string sendKeys, int seconds = DEFAULT_TIMEOUT)
        {
            try
            {
                WebElement send = (WebElement)new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).
                    Until(ExpectedConditions.ElementToBeClickable(by));


                send.SendKeys(sendKeys);

                return send;
            }
            catch (Exception ex)
            {
                WebElement exception = (WebElement)new WebDriverWait(webDriver, TimeSpan.FromSeconds(1)).
                    Until(ExpectedConditions.AlertIsPresent());

                Console.WriteLine("Element with locator: " + by + " was not foud.");
                throw;
            }
        }

        public static WebElement Click(this IWebDriver webDriver, By by, int seconds = DEFAULT_TIMEOUT)
        {
            try
            {
                WebElement element = (WebElement)new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).
                    Until(ExpectedConditions.ElementToBeClickable(by));


                element.Click();

                return element;
            }
            catch (Exception ex)
            {
                WebElement exception = (WebElement)new WebDriverWait(webDriver, TimeSpan.FromSeconds(1)).
                    Until(ExpectedConditions.AlertIsPresent());

                Console.WriteLine("Element with locator: " + by + " was not foud.");
                throw;
            }
        }

        public static void RightClick(this IWebDriver webDriver, By by, int seconds = DEFAULT_TIMEOUT)
        {
            Actions actions = new Actions(webDriver);

            WebElement element = (WebElement)new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).
                Until(ExpectedConditions.ElementToBeClickable(by));

            actions.ContextClick(element).Perform();
        }

        public static bool IsElementPresent(this IWebDriver webDriver, By by)
        {
            try
            {
                webDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: " + by + " was not foud.");
                return false;

            }
        }

        public static string GetValue(this IWebDriver webDriver, By by)
        {
            string value = webDriver.FindElement(by).GetAttribute("value");
            return value;
        }

        public static void ClearInputTxt(this IWebElement webDriver, By by)
        {
            try
            {
                webDriver.FindElement(by).SendKeys(Keys.Control + "a");
                webDriver.FindElement(by).SendKeys(Keys.Backspace);
            }
            catch(NoSuchElementException)
            {
                Console.WriteLine("Element with locator: " + by + " was not foud.");
                throw;
            }   
        }
    }
}

