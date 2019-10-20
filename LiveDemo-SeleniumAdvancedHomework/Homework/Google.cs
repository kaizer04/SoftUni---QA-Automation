using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Reflection;

namespace Homework
{
    [TestFixture]
    public class Google
    {
        [Test]
        public void SeleniumSearch()
        {

            var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://www.google.com/");

            var searchInput = driver.FindElement(By.XPath(@"//input[@class='gLFyf gsfi']"));
            searchInput.SendKeys("Selenium");

            var logo = driver.FindElement(By.Id("hplogo"));
            logo.Click();

            Actions builder = new Actions(driver);
            builder
                .ClickAndHold(logo)
                .MoveByOffset(100, 200)
                .Release()
                .Perform();

            //var searchButton = driver.FindElement(By.XPath(@"//*[@id='tsf']/div[2]/div[1]/div[3]/center/input[1]"));
            //searchButton.Click();

            var seleniumResult = driver.FindElement(By.ClassName("iUh30"));
            seleniumResult.Click();

            var actualTitle = driver.Title;
            driver.Quit();

            Assert.AreEqual("Selenium - Web Browser Automation", actualTitle);
        }
    }
}
