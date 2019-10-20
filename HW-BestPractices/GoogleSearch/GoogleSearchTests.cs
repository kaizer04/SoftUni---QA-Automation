using GoogleSearch.Pages;
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
        private IWebDriver driver;
        
        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }


        [Test]
        public void checkIfBrowserWillOpenSeleniumhqOrgSite()
        {
            var googleHomePage = new GoogleHomePage(driver);
            googleHomePage.Navigate();

            googleHomePage.SearchTextInput.SendKeys("Selenium");
            googleHomePage.SearchTextInput.SendKeys(Keys.Enter);
            
            var googleResultPage = new GoogleResultPage(driver);
            googleResultPage.SearchSiteLink.Click();
            
            Assert.AreEqual("Selenium - Web Browser Automation", driver.Title);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}