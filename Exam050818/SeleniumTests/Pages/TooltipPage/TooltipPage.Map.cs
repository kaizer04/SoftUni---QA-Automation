namespace SeleniumTests.Pages
{
	using OpenQA.Selenium;
    using SeleniumTests.Pages;

    public partial class TooltipPage : BasePage
	{
        ////*[@id="sidebar"]/aside[2]/ul/li[1]/a
        //*[@id="sidebar"]/aside[2]/ul/li[6]/a
        public IWebElement TooltipButton => Driver.FindElement(By.XPath(@"//*[@id=""sidebar""]/aside[2]/ul/li[6]/a"));

		public IWebElement AgeInput => Wait.Until(d => Driver.FindElement(By.Id("age")));

        //Bonus 
        //public IWebElement Tooltip => Driver.FindElement(By.XPath("/html/body/div[5]/div[1]"));
        //public IWebElement TooltipLink => Driver.FindElement(By.XPath(@"//div[@role=""tooltip""]"));

        //public IWebElement Tooltip(string id)
        //{
        //	return Wait.Until(d => Driver.FindElement(By.Id(id)));
        //}

        public IWebElement Tooltip
        {
            get 
            {
                var id = AgeInput.GetAttribute("aria-describedby");

                return Driver.FindElement(By.Id(id));

                //return Driver.FindElement(By.XPath($"//*[@id='{id}']"));
            }
        }
    }
}
