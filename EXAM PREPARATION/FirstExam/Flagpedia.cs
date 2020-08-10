namespace ExamPreparation
{
    using ExamPreparation.Pages.CountryPage;
    using ExamPreparation.Pages.IndexPage;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public class Flagpedia
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void ExtractAllFlagsInTheWorld()
        {
            var indexPage = new IndexPage(_driver);
            var countryPage = new CountryPage(_driver);
            indexPage.NavigateTo("http://flagpedia.net/index");

            var countryNames = indexPage.GetNames();
            foreach (var element in countryNames)
            {
                string url = "http://flagpedia.net/" + element;
                countryPage.NavigateTo(url);
                ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");

                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                screenshot.SaveAsFile(Path.GetFullPath(@"../../../Screenshots/") + BuildName(countryPage) + ".png", ScreenshotImageFormat.Png);
            }
        }

        private string BuildName(CountryPage page)
        {
            return $"{page.Name.Text}-{page.Capital.Text}-{page.Code.Text}";
        }

    }
}
