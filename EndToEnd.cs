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
    public class EndToEnd
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
        public void EndToEndFlow()
        {
            String[] expectedProducts = { "iphone X", "Blackberry" };

            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).SendKeys("learning");
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            // .form-group>.text-info>span input
            driver.FindElement(By.Id("signInBtn")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));

            TestContext.Progress.WriteLine("last product is "+products.Last().Text);
            foreach (IWebElement product in products)
            {
                // Assert.IsNotNull(product);
                TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
                if (expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                {

                    product.FindElement(By.CssSelector(".btn.btn-info")).Click();
                }
            }
            driver.FindElement(By.PartialLinkText("Checkout")).Click();
        }
    }
}
