using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace AutomationpracticeRegistration
{
    [TestFixture]
    public class AutomationpracticeRegistrationTests
    {
        private const string url = "http://automationpractice.com/index.php";
        private const string email = "kaizer@abv.bg";

        private ChromeDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void CalssInit()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

            driver.Manage().Window.Maximize();
            driver.Url = url;

            var signInLink = driver.FindElement(By.XPath(@"//*[@id=""header""]/div[2]/div/div/nav/div[1]/a"));
            signInLink.Click();

            var emailInput = driver.FindElement(By.Id(@"email_create"));
            emailInput.SendKeys(email);

            var createAccountBtn = driver.FindElement(By.Id(@"SubmitCreate"));
            createAccountBtn.Click();


        }

        [Test]
        public void NegTest()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

            driver.Manage().Window.Maximize();
            driver.Url = url;

            var signInLink = driver.FindElement(By.XPath(@"//*[@id=""header""]/div[2]/div/div/nav/div[1]/a"));
            signInLink.Click();

            var emailInput = driver.FindElement(By.Id(@"email_create"));
            emailInput.SendKeys(email);

            var createAccountBtn = driver.FindElement(By.Id(@"SubmitCreate"));
            createAccountBtn.Click();
        }

        //[TearDown]
        //public void TearDown()
        //{
        //    driver.Quit();
        //}

        //private void Type(IWebElement element, string text)
        //{
        //    element.Clear();
        //    element.SendKeys(text);
        //}
    }
}
