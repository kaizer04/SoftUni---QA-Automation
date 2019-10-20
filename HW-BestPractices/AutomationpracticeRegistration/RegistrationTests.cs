using AutomationpracticeRegistration.Pages;
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
    public class RegistrationTests
    {
        private IWebDriver driver;
        private HomePage homePage;
        private LoginPage loginPage;
        private RegisterPage registerPage;


        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
            registerPage = new RegisterPage(driver);
        }


        [Test]
        public void IsEmailSetToEmailFieldInRegistrationForm()
        {
            homePage.Navigate("http://automationpractice.com/index.php");

            homePage.SignInLink.Click();

            loginPage.EmailInput.SendKeys("kaizer2@abv.bg");

            loginPage.CreateAccountBtn.Click();
            
            Assert.AreEqual("kaizer2@abv.bg", registerPage.EmailForRegistration.GetProperty("value"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();

        }
    }
}
