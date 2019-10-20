using Registration.Tests.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Registration.Tests
{
    [TestFixture]
    public class RegistrationTests
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
        public void NegotiationTestForFirstName()
        {
            _user.FirstName = "";

            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("firstname is required.");
        }

        [Test]
        public void NegotiationTestForLastName()
        {
            _user.LastName = "";

            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("lastname is required.");
        }
        
        [Test]
        public void NegotiationTestForAddress()
        {
            _user.Address = "";

            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("address1 is required.");
        }

        [Test]
        public void NegotiationTestForCity()
        {
            _user.City = "";

            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("city is required.");
        }

        [Test]
        public void NegotiationTestForAlias()
        {
            _user.Alias = "";

            _regPage.Navigate(_loginPage);
            _regPage.FillForm(_user);

            _regPage.AssertErrorMessage("alias is required.");
        }

        [TearDown]
        public void TearDown()
        {
            _regPage.Quit();
        }
    }
}
