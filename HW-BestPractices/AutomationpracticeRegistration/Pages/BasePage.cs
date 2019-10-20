using OpenQA.Selenium;

namespace AutomationpracticeRegistration.Pages
{
    public abstract class BasePage
    {
        private IWebDriver driver;

        public BasePage(IWebDriver webDriver)
        {
            this.driver = webDriver;
        }

        public IWebDriver Driver => this.driver;
    }
}
