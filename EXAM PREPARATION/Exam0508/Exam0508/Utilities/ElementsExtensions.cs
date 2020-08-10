namespace Exam0508.Utilities
{
	using OpenQA.Selenium;
	using OpenQA.Selenium.Interactions;

	public static class ElementsExtensions
    {
	    public static void Hover(this IWebElement element, IWebDriver driver)
	    {
		    var action = new Actions(driver);
			action.MoveToElement(element).Perform();
	    }
    }
}
