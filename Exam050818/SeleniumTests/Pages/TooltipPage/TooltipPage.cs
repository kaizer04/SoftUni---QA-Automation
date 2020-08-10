namespace SeleniumTests.Pages
{
   
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public partial class TooltipPage : BasePage
    {
	    public TooltipPage(IWebDriver driver) : base(driver)
	    {
	    }

        public void Hover(IWebElement element)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(element).Perform();
        }
    }
}
