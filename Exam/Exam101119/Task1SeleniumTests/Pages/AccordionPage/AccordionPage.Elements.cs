using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Task1SeleniumTests.Pages.AccordionPage
{
    public partial class AccordionPage : BasePage
    {
        public AccordionPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement AccordionButton => Driver.FindElement(By.XPath(@"//*[@id=""sidebar""]/aside[2]/ul/li[19]/a"));

        //*[@id="ui-id-1"]/
        //*[@id="ui-id-3"]/span //*[@id="ui-id-3"]/span
        //*[@id="ui-id-5"]/span
        //*[@id="ui-id-7"]/span
        //*[@id="ui-id-3"]/span
        public IWebElement Arrow2 => Driver.FindElement(By.XPath(@"//*[@id=""ui-id-3""]/span"));

        public IWebElement Section2 => Driver.FindElement(By.Id("ui-id-3"));
    }
}
