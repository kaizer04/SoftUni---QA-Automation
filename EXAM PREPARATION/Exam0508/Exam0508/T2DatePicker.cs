using System;
using System.Collections.Generic;
using System.Text;

namespace Exam0508
{
	using System.IO;
	using System.Reflection;
	using Exam0508.Pages.DatePickerPage;
	using FluentAssertions;
	using NUnit.Framework;
	using NUnit.Framework.Interfaces;
	using OpenQA.Selenium;
	using OpenQA.Selenium.Chrome;

	[TestFixture]
	public class T2DatePicker : BaseTest
	{
		[SetUp]
		public void SetUp()
		{
			Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
			Driver.Manage().Window.Maximize();
			Driver.Url = "http://demoqa.com/";
		}

		[Test]
		[TestCase("Default – mm/dd/yy", "March 1, 2018")]
		[TestCase("ISO 8601 – yy-mm-dd", "2018-03-01")]
		[TestCase("Short – d M, y", "1 Mar, 18")]
		[TestCase("Medium – d MM, y", "1 March, 18")]
		[TestCase("Full – DD, d MM, yy", "Thursday, 1 March, 2018")]
		[TestCase("With text – ‘day’ d ‘of’ MM ‘in the year’ yy", "day 1 of March in the year 2018")]
		public void VerifyDateTimeFormat(string formatDate, string expectedDateFormat)
		{
			var datepickerPage = new DatepickerPage(Driver);
			
			datepickerPage.DatepickerButton.Click();
            DelayForVideo();
			datepickerPage.FormatDate.Click();
            DelayForVideo();
            datepickerPage.SelectDateFormat(formatDate);
            DelayForVideo();

            datepickerPage.PickDate
				.GetAttribute("value")
				.Should()
				.Be(expectedDateFormat);
		}
	}
}
