using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QAAutomation.Pages;
using System.IO;
using System.Reflection;

namespace QAAutomation
{
    [TestFixture]
    public class SoftUniCoursePageTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [Test]
        public void ThereAreHeadingTagH1()
        {
            var softUniHomePage = new SoftUniHomePage(driver);
            softUniHomePage.Navigate();
            
            softUniHomePage.TeachingNavBar.Click();

            softUniHomePage.QaAutomationCourseNavBar.Click();

            var qaAutomationCoursePage = new QAAutomationCoursePage(driver);

            Assert.AreEqual("QA Automation - септември 2019", qaAutomationCoursePage.H1Tag.Text);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();

        }
    }
}
