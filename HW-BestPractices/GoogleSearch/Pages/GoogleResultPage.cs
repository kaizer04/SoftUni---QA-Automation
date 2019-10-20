using OpenQA.Selenium;

namespace GoogleSearch.Pages
{
    public class GoogleResultPage : BasePage
    {
        public GoogleResultPage(IWebDriver webDriver) : base(webDriver)
        {
        }
        
        public IWebElement SearchSiteLink => Driver.FindElement(By.XPath(@"//*[@id=""rso""]/div[1]/div/div/div/div[1]/a[1]/h3"));
    }
}
