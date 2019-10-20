using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace Homework
{
    [TestFixture]
    public class ActionsFirstTouch
    {
        private ChromeDriver _driver;
        private WebDriverWait _wait;

        [SetUp]
        public void CalssInit()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Navigate().GoToUrl("https://demoqa.com/droppable/");
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void EnterKey()
        {
            var draggable = _driver.FindElement(By.Id("draggable"));
            var target = _driver.FindElement(By.Id("droppable"));

            var dragX = draggable.Location.X;
            var dragY = draggable.Location.Y;

            var targetColor = target.GetCssValue("color");

            Actions builder = new Actions(_driver);
            builder
                .MoveToElement(draggable)
                .ClickAndHold()
                .MoveByOffset(145, 25)
                .Release();

            Assert.AreEqual(692, draggable.Location.X, "X coordinates are wrong");
            Assert.AreEqual(355, draggable.Location.Y, "Y coordinates are wrong");

            var afterX = draggable.Location.X;
            var afterY = draggable.Location.Y;

            var afterColor = target.GetCssValue("color");

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
