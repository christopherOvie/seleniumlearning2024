using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace SeleniumLearning2024
{
    public class AutoSuggestiveDropdown
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        [Test]
        public void Dropdwntest122()
        {
            driver.FindElement(By.CssSelector("#autocomplete")).Click();
            driver.FindElement(By.CssSelector("#autocomplete")).SendKeys("Ind");

            Thread.Sleep(3000);
            IList<IWebElement> options = driver.FindElements(By.CssSelector("li.ui-menu-item div"));

            foreach(IWebElement option in options)
            {
                if (option.Text.Equals("India"))
                {
                    option.Click();
                }
            }
            TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));
        }

    }
}
