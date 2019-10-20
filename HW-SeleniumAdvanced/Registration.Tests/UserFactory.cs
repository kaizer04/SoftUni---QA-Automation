namespace Registration.Tests
{
    public static class UserFactory
    {
        public static RegistrationUser CreateValidUser()
        {
            return new RegistrationUser
            {
                FirstName = "Ventsi",
                LastName = "Batman",
                Year = "1989",
                Month = "3",
                Date = "3",
                Password = "gdsjafgujdsw",
                Gender = Gender.Male,
                PostCode = "4324422"
            };
        }
    }
}
