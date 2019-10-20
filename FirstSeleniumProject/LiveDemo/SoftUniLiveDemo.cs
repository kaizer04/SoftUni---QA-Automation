using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace LiveDemo
{
    [TestFixture]
    public class SoftUniLiveDemo
    {
        [Test]
        public void LogoSrc()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            driver.Url = "https://softuni.bg/";

            var logo = driver.FindElement(By.XPath(@"//*[@id=""page-header""]/div[1]/div/div/div[1]/a/img[1]"));
            var actualImageSrc = logo.GetAttribute("src");

            driver.Quit();

            Assert.AreEqual("https://softuni.bg/content/images/svg-logos/software-university-logo.svg", actualImageSrc);
        }


        [Test]
        public void LoginWithValidCreadentials()
        {
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            driver.Url = "https://softuni.bg/";

            var loginButton = driver.FindElement(By.XPath(@"//*[@id=""header-nav""]/div[2]/ul/li[2]/span/a"));
            loginButton.Click();

            var userNameInput = driver.FindElement(By.Id(@"username"));
            userNameInput.SendKeys("kaizer");

            var passwordInput = driver.FindElement(By.Id(@"password"));
            passwordInput.SendKeys("levski");

            var loginBut = driver.FindElement(By.XPath(@"/html/body/main/div[2]/div/div[2]/div[1]/form/div[4]/input"));
            loginBut.Click();

            driver.Quit();
        }

    }
}
