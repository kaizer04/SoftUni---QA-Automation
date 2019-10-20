using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace QAAutomation
{
    [TestFixture]
    public class GoogleSearchTests
    {
        [Test]
        public void ThereAreHeadingTagH1()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            driver.Url = "https://softuni.bg/";

            var teachingNavBar = driver.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[1]/ul/li[2]/a/span"));
            teachingNavBar.Click();

            var qaAutomationCourseNavBar = driver.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[1]/ul/li[2]/div/div/div[2]/div[2]/div/div[1]/ul[2]/div[1]/ul/li/a"));
            qaAutomationCourseNavBar.Click();

            var h1Tag = driver.FindElement(By.XPath(@"/html/body/div[2]/header/h1"));

            Assert.AreEqual("QA Automation - септември 2019", h1Tag.Text);

            driver.Quit();
        }
    }
}
