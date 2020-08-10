using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Task1SeleniumTests.Pages.AccordionPage
{
    public partial class AccordionPage : BasePage
    {
        
        //public IWebElement Section
        //{
        //    get
        //    {
        //        var id = Section2.GetAttribute("id");

        //        return Driver.FindElement(By.Id(id));

        //        //return Driver.FindElement(By.XPath($"//*[@id='{id}']"));
        //    }
        //}
        //"ui-id-3"
        public IWebElement Section(string id)
        {
            string idElement = "ui-id-" + id;

            return Driver.FindElement(By.Id(idElement));
        }

        public IWebElement Arrow(string id)
        {
            string idElement = "ui-id-" + id;

            return Driver.FindElement(By.XPath($@"//*[@id=""{idElement}""]/span"));
        }

        public IWebElement Content(string id)
        {
            string idElement = "ui-id-" + id;

            return Driver.FindElement(By.Id(idElement));
        }
    }
}
