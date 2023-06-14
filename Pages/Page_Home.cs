using Katalon.Automation.Tests.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalon.Automation.Tests.Pages
{
    public class Page_Home
    {
        private readonly DriverHelper _driver;
        private IWebElement cartPage => _driver.FindElement(By.CssSelector("[class*='page_item page-item-8']"));
        private IWebElement shopPage => _driver.FindElement(By.CssSelector("[class*='page_item page-item-7']"));
   
        public Page_Home(DriverHelper driver)
        {
            _driver = driver;
        }
        public void NavigateToCart()
        {
            _driver.Click(cartPage);
        }
        public void NavigateToShop() 
        {
            _driver.Click(shopPage);
        }
    }
}
