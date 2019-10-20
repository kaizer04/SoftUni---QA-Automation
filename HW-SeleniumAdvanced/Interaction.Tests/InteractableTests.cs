using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace Interaction.Tests
{
    [TestFixture]
    class InteractableTests
    {
        private ChromeDriver driver;
        private WebDriverWait wait;
        private RegistrationUser user;

        [SetUp]
        public void CalssInit()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void ResizeBox()
        {
            driver.Url = "https://demoqa.com/resizable/";

            var box = driver.FindElement(By.Id("resizable"));
            double expectedWidth = box.Size.Width + 84;
            double expectedHeight = box.Size.Height + 84;

            var resize = driver.FindElement(By.XPath("//*[@id='resizable']/div[3]"));

            var builder = new Actions(driver);
            builder.DragAndDropToOffset(resize, 100, 100).Perform();

            double actualWidth = box.Size.Width;
            double actualHeight = box.Size.Height;

            Assert.AreEqual(expectedWidth, actualWidth, 2);
            Assert.AreEqual(expectedHeight, actualHeight, 2);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
