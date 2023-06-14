using Katalon.Automation.Tests.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalon.Automation.Tests.Pages
{
    public class Page_Cart
    {
        readonly DriverHelper _driver;
        By itemsInCart => By.CssSelector("[class='woocommerce-cart-form__cart-item cart_item']");
        By productName => By.CssSelector("[class='product-name']");
        List<IWebElement> productsPrice => _driver.FindElements(By.CssSelector("[class='woocommerce-Price-amount amount']"));
        List<IWebElement> productsRemove => _driver.FindElements(By.CssSelector("[class='remove']"));
        List<int> priceofItems = new List<int>();
        int lowestPriceItem;
        
        public Page_Cart(DriverHelper driver)
        {
            _driver = driver;
        }

        public bool NumberofItemsInCart(int ItemsShouldbeInCart) 
        {
            Thread.Sleep(3000);
            List<IWebElement> ItemsInCart = _driver.FindElements(itemsInCart);
            if (ItemsInCart.Count == ItemsShouldbeInCart)
                return true;
            else 
                return false;
        }

        public void LowestPriceItem() 
        {
            List<IWebElement> totalProducts = _driver.FindElements(productName);

            for (int i = 1; i < totalProducts.Count; i++)
            {
                
                string A = _driver.GetText(productsPrice[(i*2)-1]).Substring(1, 2);                
                int price = Convert.ToInt32(A);
                Console.WriteLine(price);   
                priceofItems.Add(price);
                
            }

            int lowestPrice = priceofItems.Min();
            lowestPriceItem = priceofItems.IndexOf(lowestPrice);
           
        }

        public void RemoveItem() 
        {
            _driver.Click(productsRemove[lowestPriceItem]);
        }
    }
}
