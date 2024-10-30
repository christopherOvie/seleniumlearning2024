using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace SeleniumLearning2024
{
    public class Locator
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
         //   new WebDriverManager.DriverManager().SetUpDriver();
           driver =    new ChromeDriver();
            driver.Manage().Window.Maximize();
           // driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
            //WebDriverManager
        }

        [Test]
        public void Test11()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            TestContext.Progress.WriteLine(driver.Title);

            TestContext.Progress.WriteLine(driver.Url);
            driver.FindElement(By.Id("username")).SendKeys("rahulshetty");
            driver.FindElement(By.Id("password")).SendKeys("123456");
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            // .form-group>.text-info>span input
            driver.FindElement(By.Id("signInBtn")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

          

            String errorMessage =driver.FindElement(By.CssSelector(".alert.alert-danger")).Text;
            TestContext.Progress.WriteLine(errorMessage);
            // driver.Close();  password    signInBtn
           
            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            String hrefAttribute =link.GetAttribute("href");
            String expectdURL = "https://rahulshettyacademy.com/documents-request";
            Assert.AreEqual(hrefAttribute, expectdURL);
        }
        
    }
}
