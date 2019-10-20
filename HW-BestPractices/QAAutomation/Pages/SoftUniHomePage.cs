using OpenQA.Selenium;

namespace QAAutomation.Pages
{
    public class SoftUniHomePage : BasePage
    {
        private const string softUniWebSite = "https://softuni.bg/";

        public SoftUniHomePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public IWebElement TeachingNavBar => Driver.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[1]/ul/li[2]/a/span"));

        public IWebElement QaAutomationCourseNavBar => Driver.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[1]/ul/li[2]/div/div/div[2]/div[2]/div/div[1]/ul[2]/div[1]/ul/li/a"));

        public void Navigate()
        {
            Driver.Url = softUniWebSite;
        }
    }
}
