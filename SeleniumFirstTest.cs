using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace SeleniumLearning2024
{
    public class SeleniumFirstTest
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
         //   new WebDriverManager.DriverManager().SetUpDriver();
           driver =    new ChromeDriver();
            driver.Manage().Window.Maximize();
            //WebDriverManager
        }

        [Test]
        public void Test11()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            TestContext.Progress.WriteLine(driver.Title);

            TestContext.Progress.WriteLine(driver.Url);
           // driver.Close();
        }
    
    }
}
