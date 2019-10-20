using AutoFixture;
using Homework.Extensions;
using Homework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace Homework
{
    [TestFixture]
    public class AutomationPractice
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;
        private LoginPage _loginPage;
        private RegistrationPage _regPage;
        private RegistrationUser _user;

        [SetUp]
        public void CalssInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();

            _loginPage = new LoginPage(_driver);
            _regPage = new RegistrationPage(_driver);

            _user = UserFactory.CreateValidUser();
        }

        [Test]
        public void DoubleTest()
        {
            double a = 444;
            double b = 448;

            Assert.AreEqual(a, b, 5);
        }
        [Test]
        public void SeleniumPageObjectModel()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.Navigate("http://automationpractice.com/index.php?controller=my-account");

            loginPage.Email.SendKeys("djburooooooooooooo@gmail.com");
            loginPage.Submit.Click();

            var registrationPage = new RegistrationPage(_driver);
            registrationPage.RadioButtons[0].Click();
        }

        [Test]
        public void FillRegistrationForm()
        {
            _user.FirstName = "";
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=my-account");

            var emailInput = _driver.FindElement(By.Id("email_create"));
            emailInput.SendKeys(_user.FirstName);

            var createAccountButton = _driver.FindElement(By.Id("SubmitCreate"));
            createAccountButton.Click();

            var radioButtons = _wait.Until(d => d.FindElements(By.XPath("//div[@class='radio']//input")));
            radioButtons[0].Click();

            var firstName = _driver.FindElement(By.Id("customer_firstname"));
            firstName.SendKeys(_user.FirstName);

            var lastName = _driver.FindElement(By.Id("customer_lastname"));
            lastName.SendKeys("Batman");

            var password = _driver.FindElement(By.Id("passwd"));
            password.SendKeys("pass123456");

            var dateDD = _wait.Until(d => d.FindElement(By.Id("days")));
            SelectElement date = new SelectElement(dateDD);
            date.SelectByValue("3");

            var monthDD = _driver.FindElement(By.Id("months"));
            SelectElement months = new SelectElement(monthDD);
            months.SelectByValue("3");

            var yearDD = _driver.FindElement(By.Id("years"));
            SelectElement years = new SelectElement(yearDD);
            years.SelectByValue("2016");

            var realFirstName = _driver.FindElement(By.Id("firstname"));
            realFirstName.SendKeys("Ventsi");

            var realLastName = _driver.FindElement(By.Id("lastname"));
            realLastName.SendKeys("Batman");

            var address = _driver.FindElement(By.Id("address1"));
            address.SendKeys("Neshto");

            var city = _driver.FindElement(By.Id("city"));
            city.SendKeys("Sofia");

            var stateDD = _driver.FindElement(By.Id("id_state"));
            SelectElement state = new SelectElement(stateDD);
            state.SelectByText("Arizona");

            var postcode = _driver.FindElement(By.Id("postcode"));
            postcode.SendKeys("85001");

            var phone = _driver.FindElement(By.Id("phone_mobile"));
            phone.SendKeys("85001");

            var alias = _driver.FindElement(By.Id("alias"));
            alias.Type("Ventsi");

            var registerButton = _driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();
        }

        [Test]
        public void FillRegistrationForm2()
        {
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=my-account");

            var emailInput = _driver.FindElement(By.Id("email_create"));
            emailInput.SendKeys("DJBuro1@gmail.com");

            var createAccountButton = _driver.FindElement(By.Id("SubmitCreate"));
            createAccountButton.Click();

            var radioButtons = _wait.Until(d => d.FindElements(By.XPath("//div[@class='radio']//input")));
            radioButtons[0].Click();

            var firstName = _driver.FindElement(By.Id("customer_firstname"));
            firstName.SendKeys("");

            var lastName = _driver.FindElement(By.Id("customer_lastname"));
            lastName.SendKeys("Batman");

            var password = _driver.FindElement(By.Id("passwd"));
            password.SendKeys("pass123456");

            var dateDD = _wait.Until(d => d.FindElement(By.Id("days")));
            SelectElement date = new SelectElement(dateDD);
            date.SelectByValue("3");

            var monthDD = _driver.FindElement(By.Id("months"));
            SelectElement months = new SelectElement(monthDD);
            months.SelectByValue("3");

            var yearDD = _driver.FindElement(By.Id("years"));
            SelectElement years = new SelectElement(yearDD);
            years.SelectByValue("2016");

            var realFirstName = _driver.FindElement(By.Id("firstname"));
            realFirstName.SendKeys("Ventsi");

            var realLastName = _driver.FindElement(By.Id("lastname"));
            realLastName.SendKeys("Batman");

            var address = _driver.FindElement(By.Id("address1"));
            address.SendKeys("Neshto");

            var city = _driver.FindElement(By.Id("city"));
            city.SendKeys("Sofia");

            var stateDD = _driver.FindElement(By.Id("id_state"));
            SelectElement state = new SelectElement(stateDD);
            state.SelectByText("Arizona");

            var postcode = _driver.FindElement(By.Id("postcode"));
            postcode.SendKeys("85001");

            var phone = _driver.FindElement(By.Id("phone_mobile"));
            phone.SendKeys("85001");

            var alias = _driver.FindElement(By.Id("alias"));
            //Type(alias, "Home");

            var registerButton = _driver.FindElement(By.Id("submitAccount"));
            registerButton.Click();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }


    }
}
