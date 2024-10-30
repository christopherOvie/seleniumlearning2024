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
    public class Checkout

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
        }

        [Test]
        public void CheckoutTest()
        {
            String[] expectedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new string[2];

           driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).SendKeys("learning");
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            // .form-group>.text-info>span input
            driver.FindElement(By.Id("signInBtn")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));


            foreach (IWebElement product in products)
            {
                // Assert.IsNotNull(product);
               // TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
                if (expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                {

                    product.FindElement(By.CssSelector(".btn.btn-info")).Click();
                }
            }
            driver.FindElement(By.PartialLinkText("Checkout")).Click();

            IList<IWebElement> checkoutCard = driver.FindElements(By.CssSelector("h4 a"));

            for(int i = 0; i < checkoutCard.Count; i++)
            {
                actualProducts[i] = checkoutCard[i].Text;

            }
            Assert.AreEqual(actualProducts, expectedProducts);
            driver.FindElement(By.CssSelector("button.btn-success")).Click();

            driver.FindElement(By.Id("country")).SendKeys("ind");


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".input-field input")));
            driver.FindElement(By.LinkText("India")).Click();

            driver.FindElement(By.XPath("//label[@for='checkbox2']")).Click();

            driver.FindElement(By.CssSelector("[value='Purchase']")).Click();

              String confirmationText = driver.FindElement(By.CssSelector("div.alert-dismissible")).Text;

            StringAssert.Contains("Success", confirmationText,"mismatch");



        }
    }
}
