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
    public class AutomationExercise
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            //   new WebDriverManager.DriverManager().SetUpDriver();
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://automationexercise.com/";
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//p[text()='Consent']")).Click();
            Thread.Sleep(3000);
        }

        [Test]
        public void EndToEndFlow()
        {
            String[] expectedProducts = { "Blue Top" };
            /*
                        driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
                        driver.FindElement(By.Id("password")).SendKeys("learning");
                        driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
                        // .form-group>.text-info>span input
                        driver.FindElement(By.Id("signInBtn")).Click();

                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));*/

            IList<IWebElement> products = driver.FindElements(By.CssSelector("div.productinfo"));


            foreach (IWebElement product in products)
            {
                // Assert.IsNotNull(product);
                TestContext.Progress.WriteLine(product.FindElement(By.CssSelector("div.product-overlay div.overlay-content  p")).Text);
                if (expectedProducts.Contains(product.FindElement(By.CssSelector("div.product-overlay div.overlay-content  p")).Text))
                {
                    product.Click();
                }
                //driver.FindElement(By.PartialLinkText("Cart")).Click();
            }
        }
    }
}
