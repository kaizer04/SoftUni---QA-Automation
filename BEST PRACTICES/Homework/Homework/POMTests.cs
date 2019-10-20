using Homework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Homework
{
    [TestFixture]
    public class POMTests
    {
        private LoginPage _loginPage;
        private RegistrationPage _regPage;
        private RegistrationUser _user;

        [SetUp]
        public void CalssInit()
        {
            var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();

            _loginPage = new LoginPage(driver);
            _regPage = new RegistrationPage(driver);

            _user = UserFactory.CreateValidUser();
        }

        [Test]
        public void FillRegistrationForm()
        {
            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("You must register at least one phone number.");
        }

        [Test]
        public void FillRegistrationFormWithoutFirstName()
        {
            _user.FirstName = "";

            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("You must register at least one phone number.");
        }
    }
}
