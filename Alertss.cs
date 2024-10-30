using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace SeleniumLearning2024
{
    public class Alerts
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
         
           driver =    new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/";
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);

        }

        [Test]
        public void AlertTest()
        {
        
        }

    }
}
