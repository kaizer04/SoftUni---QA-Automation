using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SeleniumTests.Pages;
using System.IO;
using System.Reflection;

namespace Tests
{
    public class Tests
    {
        private ChromeDriver _driver;
        private TooltipPage _tooltipPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            _driver.Url = "http://demoqa.com/";

            _tooltipPage = new TooltipPage(_driver);
        }

        [Test]
        public void Test1()
        {
            _tooltipPage.TooltipButton.Click();

            _tooltipPage.Hover(_tooltipPage.AgeInput);

            Assert.IsTrue(_tooltipPage.Tooltip.Displayed);
            Assert.AreEqual("We ask for your age only for statistical purposes.", _tooltipPage.Tooltip.Text);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}