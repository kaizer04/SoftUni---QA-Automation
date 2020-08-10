using OpenQA.Selenium;

namespace ExamPreparation.Pages
{
    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public void NavigateTo(string url)
        {
            if(url.Contains(" ") || url.Contains("'"))
            {
                url = url.Replace(" ", "-");
                url = url.Replace("'", "-");
            }

            this.Driver.Url = url;
        }
    }
}
