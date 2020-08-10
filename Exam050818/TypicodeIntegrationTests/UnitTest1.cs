using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace TypicodeIntegrationTests
{
    public class Tests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            var test = Guid.Empty.ToString();

            _client = new HttpClient();

            _client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        }

        [Test]
        public async Task GetUser()
        {
            var exprectedUser = new User
            {
                Name = "Leanne Graham",
                Username = "Bret",
                Email = "Sincere@apreil.biz"
            };

            var response = await _client.GetAsync("users/1");
            response.EnsureSuccessStatusCode();

            var responseAsString = response.Content.ReadAsStringAsync().Result;
            
            var actualUser = User.FromJson(responseAsString);

            Assert.AreEqual(exprectedUser.Name, actualUser.Name);
            
            Assert.AreEqual(exprectedUser.Username, actualUser.Username);

            Assert.AreEqual(exprectedUser.Email, actualUser.Email);
        }

        [Test]
        public async Task GetUserNegative()
        {
            var response = await _client.GetAsync("users/111");
            

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            
        }
    }
}