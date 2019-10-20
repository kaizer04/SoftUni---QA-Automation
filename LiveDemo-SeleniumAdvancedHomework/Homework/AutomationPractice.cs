using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Homework
{
    [TestFixture]
    public class AutomationPractice
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;

        [SetUp]
        public void CalssInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void FillRegistrationForm()
        {
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=my-account");

            var emailInput = _driver.FindElement(By.Id("email_create"));
            emailInput.SendKeys("DJBuro1@gmail.com");

            var createAccountButton = _driver.FindElement(By.Id("SubmitCreate"));
            createAccountButton.Click();

            var radioButtons = _wait.Until(d => d.FindElements(By.XPath("//div[@class='radio']//input")));
            radioButtons[(int)Gender.Male].Click();

            
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
