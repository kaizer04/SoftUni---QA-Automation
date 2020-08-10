namespace ExamPreparation.Pages.IpHomePage
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Linq;

    public partial class IpHomePage
    {
        public List<IWebElement> Names => Driver
            .FindElement(By.XPath("/html/body/table/tbody"))
            .FindElements(By.TagName("a")).ToList();

        public IWebElement SearchBox => Driver.FindElement(By.Name("countrys"));

        public IWebElement RadioButton => Driver.FindElement(By.XPath("/html/body/form/input[3]"));

        public IWebElement Generate => Driver.FindElement(By.XPath("/html/body/form/input[5]"));

        public string Ips => Driver.FindElement(By.XPath("/html/body/pre")).Text;
    }
}
