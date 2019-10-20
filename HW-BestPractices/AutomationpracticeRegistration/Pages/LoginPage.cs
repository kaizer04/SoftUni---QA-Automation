using OpenQA.Selenium;

namespace AutomationpracticeRegistration.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public IWebElement EmailInput => Driver.FindElement(By.Id("email_create"));

        public IWebElement CreateAccountBtn => Driver.FindElement(By.Id(@"SubmitCreate"));
    }
}
