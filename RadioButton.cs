using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace SeleniumLearning2024
{
    public class RadioButton
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
        
           driver =    new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void dropdown11()
        {
            
IWebElement dropdown =   driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement s = new SelectElement(dropdown);
            s.SelectByIndex(1);

            IList<IWebElement> rdio = driver.FindElements(By.CssSelector("input[type='radio']"));

           
            foreach(IWebElement radioButton in rdio)
            {
                // rdio[1].GetAttribute("value").Equals("user");
                if (radioButton.GetAttribute("value").Equals("user")) { }
                radioButton.Click();
            }
          
            By elementLocator = By.Id("okayBtn");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
            // Wait until the element is clickable
            //IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
            Boolean res= driver.FindElement(By.Id("usertype")).Selected;
            Assert.That(res, Is.True);
        }

    }
}
