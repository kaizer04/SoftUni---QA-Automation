using OpenQA.Selenium;

namespace GoogleSearch.Pages
{
    public class GoogleHomePage : BasePage
    {
        private const string googleWebSite = "https://www.google.com/?gws_rd=ssl";
        
        public GoogleHomePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public IWebElement SearchTextInput => Driver.FindElement(By.XPath(@"//*[@id=""tsf""]/div[2]/div[1]/div[1]/div/div[2]/input"));

        public void Navigate()
        {
            Driver.Url = googleWebSite;
        }
    }
}
