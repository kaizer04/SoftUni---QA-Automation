using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using Task2SeleniumTests.Pages.UnitTestingWithNunitPage;

namespace Task2SeleniumTests
{
    public class ArticleTests : BaseTest
    {
        private UnitTestingWithNunitPage _unitTestingWithNunitPage;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Driver.Manage().Window.Maximize();
            Driver.Url = "https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit";

            _unitTestingWithNunitPage = new UnitTestingWithNunitPage(Driver);
        }

        [Test]
        public void PrerequisitesLinkTest()
        {
            _unitTestingWithNunitPage.PrerequisitesLink.Click();

            Assert.AreEqual("https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit#prerequisites", Driver.Url);
        }

        [TestCase("1", "https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit#prerequisites")]
        [TestCase("2", "https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit#creating-the-source-project")]
        [TestCase("3", "https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit#creating-the-test-project")]
        [TestCase("4", "https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit#creating-the-first-test")]
        [TestCase("5", "https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit#adding-more-features")]
        public void ArticleLinkTests(string id, string expectedResult)
        {
            _unitTestingWithNunitPage.ArticleLink(id).Click();

            Assert.AreEqual(expectedResult, Driver.Url);
        }

        [Test]
        public void PrerequisitesLinkVoteTest()
        {
            _unitTestingWithNunitPage.PrerequisitesLink.Click();
            var voteYes = Driver.FindElement(By.XPath(@"//*[@id=""affixed-right-container""]/div/div[1]/div/div/button[1]/span[2]"));
            voteYes.Click();

            var write = Driver.FindElement(By.Id("rating-feedback-mobile"));
            write.SendKeys("alabala");

            var btn = Driver.FindElement(By.XPath(@"//*[@id=""affixed-right-container""]/div/div[1]/form/div[2]/button[2]"));
            btn.Click();

            var thankYou = Driver.FindElement(By.XPath(@"//*[@id=""affixed-right-container""]/div/div[2]/p"));

            Assert.IsTrue(thankYou.Displayed);
            Assert.AreEqual("Thank you.", thankYou.Text);
        }
    }
}