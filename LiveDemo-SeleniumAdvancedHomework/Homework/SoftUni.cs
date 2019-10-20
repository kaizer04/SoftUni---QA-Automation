using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace Homework
{
    [TestFixture]
    public class SoftUni
    {
        [Test]
        public void QACourse()
        {

            var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://softuni.bg/");

            var courses = driver.FindElement(By.XPath(@"//*[@id='header-nav']/div[1]/ul/li[2]/a/span"));
            courses.Click();

            var qaCourseLink = driver.FindElement(By.LinkText("QA Automation - септември 2019"));
            qaCourseLink.Click();

            var header = driver.FindElement(By.XPath(@"/html/body/div[2]/header/h1"));

            var actualHeader = header.Text;
            driver.Quit();

            Assert.AreEqual("QA Automation - септември 2019", actualHeader);
        }
    }
}