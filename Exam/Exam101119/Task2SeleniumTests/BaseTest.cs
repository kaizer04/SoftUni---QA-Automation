namespace Task2SeleniumTests
{
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using System;
    using System.IO;
    using System.Threading;

    public class BaseTest
    {
        public IWebDriver Driver { get; protected set; }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}

