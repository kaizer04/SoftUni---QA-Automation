using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace Registration.Tests
{
    [TestFixture]
    public class RegistrationTests
    {
        private const string url = "http://automationpractice.com/index.php";
        private const string email = "kaizer2@abv.bg";

        private ChromeDriver driver;
        private WebDriverWait wait;
        private RegistrationUser user;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            user = UserFactory.CreateValidUser();

            driver.Manage().Window.Maximize();
            driver.Url = url;

            var signInLink = driver.FindElement(By.XPath(@"//*[@id=""header""]/div[2]/div/div/nav/div[1]/a"));
            signInLink.Click();

            var emailInput = wait.Until(ExpectedConditions.ElementExists(By.Id(@"email_create")));
            emailInput.SendKeys(email);

            var createAccountBtn = driver.FindElement(By.Id(@"SubmitCreate"));
            createAccountBtn.Click();

            var emailForReg = wait.Until(ExpectedConditions.ElementExists(By.XPath("//form[@id='account-creation_form']//input[@id='email']")));
            
            var radioButtons = driver.FindElements(By.Name("id_gender"));
            radioButtons[(int)user.Gender].Click();

        }

        [Test]
        public void NegTestForFirstName()
        {
            user.FirstName = "";

            var registerButton = driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();

            //*[@id="center_column"]/div/ol/li[3]
            var firstnameRequiredMessage = driver.FindElement(By.XPath(@"//*[@id=""center_column""]/div/ol/li[3]"));
            
            //Assert
            Assert.AreEqual("firstname is required.", firstnameRequiredMessage.Text);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}