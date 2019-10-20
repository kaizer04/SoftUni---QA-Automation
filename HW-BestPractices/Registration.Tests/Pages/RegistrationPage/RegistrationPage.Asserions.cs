using NUnit.Framework;

namespace Registration.Tests.Pages
{
    public partial class RegistrationPage
    {
        public void AssertErrorMessage(string expected)
        {
            Assert.AreEqual(expected, ErrorMessage.Text);
        }
    }
}
