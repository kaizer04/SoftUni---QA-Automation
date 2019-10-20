using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationpracticeRegistration.Pages
{
    public class RegisterPage : BasePage
    {
        private WebDriverWait wait;

        public RegisterPage(IWebDriver webDriver) : base(webDriver)
        {
            this.wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        public WebDriverWait Wait => this.wait;

        public IWebElement EmailForRegistration => Wait.Until(ExpectedConditions.ElementExists(By.XPath("//form[@id='account-creation_form']//input[@id='email']")));
    }
}
