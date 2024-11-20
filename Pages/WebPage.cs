using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Gmail.Pages
{
    public abstract class WebPage
    {
        protected readonly IWebDriver Driver;
        public static int ExplicitTimeoutInSeconds = 15;

        public WebPage(IWebDriver driver)
        {
            Driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        public virtual void ClickOnElement(By elementLocator)
        {
            var element = Driver.FindElement(elementLocator);
            WaitForElementClickable(element, Driver);
            element.Click();
        }

        internal static void WaitForElementClickable(IWebElement element, IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(ExplicitTimeoutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public virtual void EnterTextInField(By elementLocator, string text)
        {
            var byElement = elementLocator;
            WaitForElementVisible(byElement, Driver);
            var element = Driver.FindElement(elementLocator);
            element.SendKeys(text);
        }

        public string GetElementText(By elementLocator)
        {
            var element = Driver.FindElement(elementLocator);
            WaitForElementTextToBeVisible(element, Driver);
            return element.Text.Trim();
        }

        internal static void WaitForElementVisible(By pageLocator, IWebDriver driver)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.Until(ExpectedConditions.ElementIsVisible(pageLocator));
            }
            catch (WebDriverTimeoutException)
            {
                throw new ElementNotVisibleException($"Element defined by locator '{pageLocator}' is not visible!");
            }
        }

        internal static void WaitForElementTextToBeVisible(IWebElement element, IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(ExplicitTimeoutInSeconds));
            wait.Until(AnyTextToBePresentInElement(element));
        }

        internal static Func<IWebDriver, bool> AnyTextToBePresentInElement(IWebElement element)
        {
            return driver =>
            {
                try
                {
                    return element.Text != string.Empty;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            };
        }
    }
}
