using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Polly;


namespace Katalon.Automation.Tests.Drivers
{
    public class DriverHelper
    {
        readonly DriverSetup _driverSetup;
        WebDriverWait webdriverWait;
        List<TimeSpan> _timeouts;

        public DriverHelper(DriverSetup driverSetup)
        {
            _driverSetup = driverSetup;
            webdriverWait = new WebDriverWait(_driverSetup.Driver, TimeSpan.FromSeconds(5));

            _timeouts = new List<TimeSpan>();
            for (int retryAttempt = 0; retryAttempt < 3; retryAttempt++) 
            {
                _timeouts.Add(TimeSpan.FromSeconds(2));
            }
        }

        public List<IWebElement> FindElements(By elementLocator)
        {
            List<IWebElement> Action()
            {
                webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(elementLocator));
                return _driverSetup.Driver.FindElements(elementLocator).ToList();
            }
            return RetryOnException(Action);
        }

        public IWebElement FindElement(By elementLocator)
        {
            IWebElement Action()
            {
                webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(elementLocator));
                return _driverSetup.Driver.FindElement(elementLocator);
            }

            return RetryOnException(Action);
        }

      
        public string GetTitle()
        {
            string Action()
            {
                return _driverSetup.Driver.Title;
            }
            return RetryOnException(Action);

        }

        public string GetText(IWebElement elementLocator)
        {
            ScrollElementIntoView(elementLocator);
            return elementLocator.Text;
        }
        public string GetText(By elementLocator)
        {

            webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(elementLocator));
            var element = FindElement(elementLocator);
            return GetText(element);
        }

        public string GetTexts(IWebElement elementLocator)
        {
            string Action()
            {
                ScrollElementIntoView(elementLocator);
                return elementLocator.GetAttribute("value");
            }
            return RetryOnException(Action);
        }

        public void Click(IWebElement elementLocator)
        {
            webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
            void Action()
            {
                try
                {
                    elementLocator.Click();
                }
                catch (Exception)
                {
                    ScrollElementIntoView(elementLocator);
                    elementLocator.Click();
                }
            }
            RetryOnException(Action);
        }

        public void Click(By elementLocator)
        {
            IWebElement elementToCLick = FindElement(elementLocator);
            Click(elementToCLick);
        }

        private void RetryOnException(Action action)
        {
            Policy.Handle<Exception>().WaitAndRetry(_timeouts).Execute(action);
        }
        private T RetryOnException<T>(Func<T> action)
        {
            return Policy.Handle<Exception>().WaitAndRetry(_timeouts).Execute(action);
        }

        private void ScrollElementIntoView(IWebElement elementLocator)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driverSetup.Driver;

            string scrollElementIntoMiddle = "var viewPortHeight = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);"
             + "var elementTop = arguments[0].getBoundingClientRect().top;"
             + "window.scrollBy(0, elementTop-(viewPortHeight/2));";

            executor.ExecuteScript(scrollElementIntoMiddle, elementLocator);

        }
    }
}

