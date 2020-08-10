namespace Exam0508.Pages.DatePickerPage
{
	using OpenQA.Selenium;

	public partial class DatepickerPage : BasePage
    {
        public DatepickerPage(IWebDriver driver) : base(driver)
        {
        }

        public void SelectDateFormat(string formatDate)
        {
            PickDate.Click();
            while (!CurrentMonth.Text.Equals("March"))
            {
                PreviousMonth.Click();
            }
            DaysOfMonth[0].Click();
            FormatOption.SelectByText(formatDate);
        }
    }
}
