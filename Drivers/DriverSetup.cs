using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalon.Automation.Tests.Drivers
{
    public class DriverSetup : IDisposable
    {
        public IWebDriver Driver { get; } 
        public string HomePageURL {get;} = "https://cms.demo.katalon.com";
        public string CartPageURL { get; } = "";
        public DriverSetup() 
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(HomePageURL);
        }
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
