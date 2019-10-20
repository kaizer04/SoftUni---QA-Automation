using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Pages
{
    public partial class RegistrationPage
    {

        public void FillForm(RegistrationUser user)
        {
            RadioButtons[0].Click();
            CustomerFirstName.SendKeys(user.FirstName);
            CustomerLastName.SendKeys(user.LastName);
            Password.SendKeys(user.Password);
            Days.SelectByText(user.Date);
            Months.SelectByText(user.Month);
            Years.SelectByText(user.Year);
            FirstName.SendKeys(user.RealFirstName);
            LastName.SendKeys(user.RealLastName);
            Address.SendKeys(user.Address);
            City.SendKeys(user.City);
            State.SelectByText(user.State);
            PostCode.SendKeys(user.PostCode);
            Phone.SendKeys(user.Phone);
            Alias.SendKeys(user.Alias);
            RegisterButton.Click();
        }

        public void Navigate(LoginPage loginPage)
        {
            loginPage.Navigate("http://automationpractice.com/index.php?controller=my-account");

            loginPage.Email.SendKeys("djburooooooooooooo@gmail.com");
            loginPage.Submit.Click();
        }
    }
}
