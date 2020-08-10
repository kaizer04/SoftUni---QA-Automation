using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SeleniumTests.Pages.AutomateThePlanetPage;
using System.IO;
using System.Reflection;

namespace SeleniumTests
{
    [TestFixture]
    public class ATPTests : BaseTest
    {
        private ChromeDriver _driver;
        private ATPPage _atpPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();

            _atpPage = new ATPPage(_driver);
        }

        [Test]
        public void Test()
        {
            _driver.Navigate().GoToUrl("https://www.automatetheplanet.com/hybrid-test-framework-advanced-element-find-extensions/");

            

            //Actions actions = new Actions(_driver);
            //actions.MoveToElement(_atpPage.ScrollSection);
            //actions.Perform();

            

            for (int i = 0; i < _atpPage.MainNavigationLinks.Count; i++)
            {
                _driver.ExecuteScript("arguments[0].scrollIntoView(true)", _atpPage.QuickNavigation);
                _driver.ExecuteScript("arguments[0].scrollBy(0, -100);");

                var beforeClick = (double)_driver.ExecuteScript("return window.pageYOffset;");

                _atpPage.SubNavigationLinks[i].Click();

                var afterClick = (double)_driver.ExecuteScript("return window.pageYOffset;");

                Assert.IsTrue(afterClick > beforeClick);
            }

            



        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
