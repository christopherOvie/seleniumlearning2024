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
    public class Frames

    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
         
           driver =    new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);

        }

        [Test]
        public void FrameTest()
        {
            //scroll
           IWebElement framescroll =  driver.FindElement(By.Id("courses-iframe"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", framescroll);


            //id,name,index

            driver.SwitchTo().Frame("courses-iframe");
           

            //driver.FindElement(By.LinkText("Learning paths")).Click();  //not working
            driver.FindElement(By.CssSelector("a[href*='learning']:nth-child(1)")).Click();

            Thread.Sleep(3000);
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);

            driver.SwitchTo().DefaultContent();

            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);


            //interview get header and title of both frame and browser

        }
        
    }
}
