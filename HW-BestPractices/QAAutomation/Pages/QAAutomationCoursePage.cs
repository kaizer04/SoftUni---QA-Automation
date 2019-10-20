using OpenQA.Selenium;

namespace QAAutomation.Pages
{
    public class QAAutomationCoursePage : BasePage
    {
        public QAAutomationCoursePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public IWebElement H1Tag => Driver.FindElement(By.XPath(@"/html/body/div[2]/header/h1"));
    }
}
