namespace SeleniumTests.Pages.AutomateThePlanetPage
{
	using System;
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;

	public partial class ATPPage : BasePage
	{
		public ATPPage(IWebDriver driver) : base(driver)
		{
		}

        public IWebElement QuickNavigation => Driver.FindElement(By.Id("tve_ct_title"));

        //id="tab-con-1"
        public IWebElement ScrollSection => Driver.FindElement(By.Id("tab-con-1"));

        public List<IWebElement> MainNavigationLinks => Driver.FindElements(By.XPath("//*[contains(@class, 'tve_ct_level0')]//a")).ToList();

        public List<IWebElement> SubNavigationLinks => Driver.FindElements(By.XPath("//*[contains(@class, 'tve_ct_level1')]//a")).ToList();

        public List<IWebElement> MainNavigationArticles => Driver.FindElements(By.TagName("h2")).ToList();

        public List<IWebElement> SubNavigationArticles => Driver.FindElements(By.TagName("h3")).ToList();


        public double Position
		{
			get
			{
				IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
				var value = Convert.ToDouble(executor.ExecuteScript("return window.pageYOffset;"));
				return value;
			}
		}

		public void ScrollTo(IWebElement element)
		{
			((IJavaScriptExecutor) Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
		}

		public void ScrollToTop()
		{
			((IJavaScriptExecutor) Driver).ExecuteScript("window.scrollTo(0, 0)");
		}

        public void ScrollBelowNavigation()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollBy(0, -100)");
        }
    }
}
