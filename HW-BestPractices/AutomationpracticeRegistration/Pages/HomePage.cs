using OpenQA.Selenium;

namespace AutomationpracticeRegistration.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public IWebElement SignInLink => Driver.FindElement(By.XPath(@"//*[@id=""header""]/div[2]/div/div/nav/div[1]/a"));

        public void Navigate(string webPage)
        {
            Driver.Url = webPage;
        }
    }
}
