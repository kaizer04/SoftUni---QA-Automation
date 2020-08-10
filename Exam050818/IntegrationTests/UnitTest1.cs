using IntegrationTests.Models;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TypicodeIntegrationTests
{
    public class Tests
    {
        private HttpClient _client;
        private string _id;

        [OneTimeSetUp]
        public async Task oneTimeSetUp()
        {
            var author = new PostAuthor
            {
                FirstName = "Jens",
                LastName = "Lapidus",
                Genre = "Thriller"
            };
            

            var content = new StringContent(author.ToJson(), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/authors/", content);
            response.EnsureSuccessStatusCode();

            var responseAsString = response.Content.ReadAsStringAsync().Result;

            var actualAuthor = Author.FromJson(responseAsString);
            _id = actualAuthor.Id;
        }

        [SetUp]
        public async Task Setup()
        {
            var test = Guid.Empty.ToString();
            _client = new HttpClient();
            //{
            //    BaseAddress = new Uri("http://localhost:6058/")
            //};
            _client.BaseAddress = new Uri("http://localhost:6058/");
        }

        [Test]
        public async Task GetAuthor()
        {
            var expectedAuthor = new Author
            {
               // Id = "a1da1d8e-1988-4634-b538-a01709477b77",
                Name = "Jens Lapidus",
                Age = 44,
                Genre = "Thriller"
            };

            var response = await _client.GetAsync($"api/authors/{_id}");
            //var response = await _client.GetAsync("api/authors/a1da1d8e-1988-4634-b538-a01709477b77");
            response.EnsureSuccessStatusCode();

            var responseAsString = response.Content.ReadAsStringAsync().Result;
            var actualAuthor = Author.FromJson(responseAsString);

            Assert.AreEqual(expectedAuthor.Name, actualAuthor.Name);
            Assert.AreEqual(expectedAuthor.Age, actualAuthor.Age);
            Assert.AreEqual(expectedAuthor.Genre, actualAuthor.Genre);
        }

        [Test]
        public async Task GetAuthorNegative()
        {
            var response = await _client.GetAsync("api/authors/3");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        }


        [Test]
        public async Task PostAuthor()
        {
            var author = new PostAuthor
            {
                FirstName = "Jens",
                LastName = "Lapidus",
                Genre = "Thriller"
            };

            var expectedAuthor = new Author
            {

                Name = "Jens Lapidus",
                Age = 2019,
                Genre = "Thriller"
            };

            var content = new StringContent(author.ToJson(), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/authors/", content);
            response.EnsureSuccessStatusCode();

            var responseAsString = response.Content.ReadAsStringAsync().Result;

            var actualAuthor = Author.FromJson(responseAsString);

            Assert.AreEqual(expectedAuthor.Name, actualAuthor.Name);
            Assert.AreEqual(expectedAuthor.Age, actualAuthor.Age);
            Assert.AreEqual(expectedAuthor.Genre, actualAuthor.Genre);
            Assert.IsNotNull(actualAuthor.Id);
        }

        [Test]
        public async Task PostAuthorWithoutFirstName()
        {
            var author = new PostAuthor
            {
                FirstName = null,
                LastName = "Lapidus",
                Genre = "Thriller"
            };
            

            var content = new StringContent(author.ToJson(), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/authors/", content);

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);

            
        }


        [Test]
        public async Task PostAuthorEmpty()
        {
            

            var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/authors/", content);

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);


        }
    }
}