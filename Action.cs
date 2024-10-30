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
    public class Action
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
        public void ActionTest()
        {
         IWebElement dropDwEle=   driver.FindElement(By.CssSelector("a.dropdown-toggle"));
            Thread.Sleep(3000);

            Actions act = new Actions(driver);

            act.MoveToElement(dropDwEle).Perform();
            Thread.Sleep(3000);

            IWebElement dropDwEle2 = driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]"));


            act.MoveToElement(dropDwEle2).Click().Perform();

            Thread.Sleep(3000);

        }

    }
}
