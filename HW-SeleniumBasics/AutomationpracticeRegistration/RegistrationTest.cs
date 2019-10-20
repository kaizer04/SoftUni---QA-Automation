using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace AutomationpracticeRegistration
{
    [TestFixture]
    public class RegistrationTest
    {
        [Test]
        public void IsEmailSetToEmailFieldInRegistrationForm()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            driver.Url = "http://automationpractice.com/index.php";

            var signInLink = driver.FindElement(By.XPath(@"//*[@id=""header""]/div[2]/div/div/nav/div[1]/a"));
            signInLink.Click();

            var emailInput = driver.FindElement(By.Id(@"email_create"));
            string emailReg = "kaizer@abv.bg";
            emailInput.SendKeys(emailReg);

            var createAccountBtn = driver.FindElement(By.Id(@"SubmitCreate"));
            createAccountBtn.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var emailForReg = wait.Until(ExpectedConditions.ElementExists(By.XPath("//form[@id='account-creation_form']//input[@id='email']")));



            //var emailForReg = driver.FindElement(By.Id(@"email"));

            Assert.AreEqual(emailReg, emailForReg.GetProperty("value"));

            driver.Quit();

        }
    }
}
