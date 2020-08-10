using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task1SeleniumTests.Pages.AccordionPage
{
    public partial class AccordionPage
    {
        public void NavigateToSection(string id)
        {
            AccordionButton.Click();
            Section(id).Click();

            Thread.Sleep(1000);
        }
    }
}
