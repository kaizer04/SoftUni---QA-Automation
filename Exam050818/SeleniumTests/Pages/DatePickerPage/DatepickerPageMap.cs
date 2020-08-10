namespace SeleniumTests.Pages.DatePickerPage
{
	using System.Collections.Generic;
	using System.Linq;
	using OpenQA.Selenium;
	using OpenQA.Selenium.Support.UI;

	public partial class DatepickerPage
    {
	    public IWebElement DatepickerButton => Driver.FindElement(By.Id("menu-item-146"));

        public IWebElement FormatDate => Driver.FindElement(By.Id("ui-id-4"));

        public IWebElement PickDate => Driver.FindElement(By.Id("datepicker4"));

        public IWebElement CurrentMonth => Driver.FindElement(By.ClassName("ui-datepicker-month"));

        public IWebElement PreviousMonth => Driver.FindElement(By.CssSelector("#ui-datepicker-div div a:nth-child(1)"));

        public IWebElement NextMonth => Driver.FindElement(By.CssSelector("#ui-datepicker-div div a:nth-child(2)"));

        public List<IWebElement> DaysOfWeek => Driver.FindElements(By.CssSelector("#ui-datepicker-div th")).ToList();

        public List<IWebElement> DaysOfMonth => Driver.FindElements(By.XPath(@"//td[@data-handler=""selectDay""]")).ToList();

        public IWebElement Format => Driver.FindElement(By.Id("format"));

        public SelectElement FormatOption => new SelectElement(Format);
    }
}
