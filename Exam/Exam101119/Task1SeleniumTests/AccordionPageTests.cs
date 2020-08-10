using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Task1SeleniumTests.Pages.AccordionPage;

namespace Task1SeleniumTests
{
    public class AccordionPageTests : BaseTest
    {
        private AccordionPage _accordionPage;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Driver.Manage().Window.Maximize();
            Driver.Url = "http://demoqa.com/";

            _accordionPage = new AccordionPage(Driver);
        }

        [Test]
        public void SectionOneHaveArrow()
        {
            string id = "1";
            _accordionPage.NavigateToSection(id);

            Assert.IsTrue(_accordionPage.Arrow(id).Displayed);
        }

        [Test]
        public void SectionTwoHaveArrow()
        {
            string id = "3";
            _accordionPage.NavigateToSection(id);

            //*[@id="ui-id-3"]/text()
            //IList<IWebElement> webElementsSection = Driver.FindElements(By.Id("ui-id-3"));
            //var count = webElementsSection.Count;

            Assert.IsTrue(_accordionPage.Arrow(id).Displayed);
        }

        [Test]
        public void SectionThreeHaveArrow()
        {
            string id = "5";
            _accordionPage.NavigateToSection(id);

            Assert.IsTrue(_accordionPage.Arrow(id).Displayed);
        }

        [Test]
        public void SectionFourHaveArrow()
        {
            string id = "7";
            _accordionPage.NavigateToSection(id);

            Assert.IsTrue(_accordionPage.Arrow(id).Displayed);
        }

        [TestCase(1, new[] { "8", "4", "6" })]
        [TestCase(3, new[] { "2", "8", "6" })]
        [TestCase(5, new[] { "2", "4", "8" })]
        [TestCase(7, new[] { "2", "4", "6" })]
        public void OnlyOneSectionIsOpen(int sectionId, string[] notDispleyedIds)
        {
            string id = sectionId.ToString();
            _accordionPage.NavigateToSection(id);

            int contentId = sectionId + 1;

            Assert.IsTrue(_accordionPage.Content(contentId.ToString()).Displayed);
            
            Assert.IsFalse(_accordionPage.Content(notDispleyedIds[1]).Displayed);
            Assert.IsFalse(_accordionPage.Content(notDispleyedIds[2]).Displayed);
            Assert.IsFalse(_accordionPage.Content(notDispleyedIds[0]).Displayed);
        }
    }
}