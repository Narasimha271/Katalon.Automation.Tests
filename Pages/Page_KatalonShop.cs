using Katalon.Automation.Tests.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalon.Automation.Tests.Pages
{
    public class Page_KatalonShop
    {
        private readonly DriverHelper _driver;
        private IWebElement cartPage => _driver.FindElement(By.CssSelector("[class*='page_item page-item-7']"));
        private IWebElement button_AddToCart => _driver.FindElement(By.CssSelector("[class='single_add_to_cart_button button alt']"));
        private List<IWebElement> itemsList => _driver.FindElements(By.CssSelector("[class='woocommerce-LoopProduct-link woocommerce-loop-product__link']"));
        public Page_KatalonShop(DriverHelper driver)
        {
            _driver = driver;
        }

        public void AddItemToCart() 
        {
            _driver.Click(button_AddToCart);
        }

        public void SelectItem(int ItemNumber) 
        {
            _driver.Click(itemsList[ItemNumber*2 - 1]);
        }

      
    }
}
