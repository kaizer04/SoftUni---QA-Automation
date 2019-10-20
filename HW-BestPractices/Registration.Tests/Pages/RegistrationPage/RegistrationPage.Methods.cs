using NUnit.Framework;
using Registration.Tests.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Tests.Pages
{
    public partial class RegistrationPage
    {

        public void FillForm(RegistrationUser user)
        {
            CustomerFirstName.SendKeys(user.FirstName);
            RadioButtons[0].Click();
            CustomerLastName.SendKeys(user.LastName);
            Password.SendKeys(user.Password);
            Days.SelectByValue(user.Date);
            Months.SelectByValue(user.Month);
            Years.SelectByText(user.Year);
            FirstName.SendKeys(user.RealFirstName);
            LastName.SendKeys(user.RealLastName);
            Address.SendKeys(user.Address);
            City.SendKeys(user.City);
            State.SelectByText(user.State);
            PostCode.SendKeys(user.PostCode);
            Phone.SendKeys(user.Phone);
            ElementExtension.Type(Alias, user.Alias);
            RegisterButton.Click();
        }

        public void Navigate(LoginPage loginPage)
        {
            loginPage.Navigate("http://automationpractice.com/index.php?controller=my-account");

            loginPage.Email.SendKeys("kaizer4@gmail.com");
            loginPage.Submit.Click();
        }

        public void Quit()
        {
            Driver.Quit();
        }
    }
}
