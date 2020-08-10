using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Task2SeleniumTests.Pages.UnitTestingWithNunitPage
{
    public partial class UnitTestingWithNunitPage : BasePage
    {
        public UnitTestingWithNunitPage(IWebDriver driver) : base(driver)
        {
        }
        ///html/body/div[3]/div/section/div/div[1]/main/nav/ol/li[1]/a
        public IWebElement PrerequisitesLink => Driver.FindElement(By.XPath(@"//*[@id=""side-doc-outline""]/ol/li[1]/a"));
        //public IWebElement PrerequisitesLink => Wait.Until(ExpectedConditions.ElementExists(By.XPath(@"/html/body/div[3]/div/section/div/div[1]/main/nav/ol/li[1]/a")));

        public IWebElement ArticleLink(string id)
        {
            string xpath = $@"//*[@id=""side-doc-outline""]/ol/li[{id}]/a";

            return Driver.FindElement(By.XPath(xpath));
        }
    }
}
