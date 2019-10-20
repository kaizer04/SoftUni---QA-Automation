using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace GoogleSearch
{
    [TestFixture]
    public class GoogleSearchTests
    {

        [Test]
        public void checkIfBrowserWillOpenSeleniumhqOrgSite()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            driver.Url = "https://www.google.com/?gws_rd=ssl";

            //if has reload button on page
            //if (driver.FindElement(By.Id("reload-button")).Displayed)
            //{
            //    var realoadButton = driver.FindElement(By.Id("reload-button"));
            //    realoadButton.Click();
            //}
     
            var searchTextInput = driver.FindElement(By.XPath(@"//*[@id=""tsf""]/div[2]/div[1]/div[1]/div/div[2]/input"));
            searchTextInput.SendKeys("Selenium");
            searchTextInput.SendKeys(Keys.Enter);

            //check first link href 
            //var searchHref = driver.FindElement(By.XPath(@"//*[@id=""rso""]/div[1]/div/div/div/div[1]/a[1]"));
            //Assert.AreEqual("https://www.seleniumhq.org/", searchHref.GetAttribute("href"));

            var searchSiteLink = driver.FindElement(By.XPath(@"//*[@id=""rso""]/div[1]/div/div/div/div[1]/a[1]/h3/div"));
            searchSiteLink.Click();

            driver.Quit();
            
            Assert.AreEqual("Selenium - Web Browser Automation", driver.Title);
        }
    }
}
