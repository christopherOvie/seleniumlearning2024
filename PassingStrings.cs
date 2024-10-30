using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace SeleniumLearning2024
{
    public class PassingStrings


    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            //   new WebDriverManager.DriverManager().SetUpDriver();
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            TestContext.Progress.WriteLine(driver.Url);
        }

        [Test]
        public void WindowHandleTest()

        {
            String email = "mentor@rahulshettyacademy.com";
            String parentWindow = driver.CurrentWindowHandle;

            driver.FindElement(By.ClassName("blinkingText")).Click();
            Assert.AreEqual(2, driver.WindowHandles.Count);

            String childWindow = driver.WindowHandles[1];

            driver.SwitchTo().Window(childWindow);
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".red")).Text);

            String text = driver.FindElement(By.CssSelector(".red")).Text;
            // Please email us at mentor@rahulshettyacademy.com with below template to receive response
            String[] splittedText = text.Split("at");
            // TestContext.Progress.WriteLine(splittedText);
            String[] trimEmail = splittedText[1].Trim().Split(' ');

            TestContext.Progress.WriteLine(trimEmail[0]);

            Assert.AreEqual(email,trimEmail[0]);

            driver.SwitchTo().Window(parentWindow);

            driver.FindElement(By.Id("username")).SendKeys(trimEmail[0]);

        }
    }

}