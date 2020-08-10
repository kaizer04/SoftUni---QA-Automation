using NUnit.Framework;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IntegrationTests.Models;
using System.Net;

namespace IntegrationTests
{
    public class Tests
    {
        private HttpClient _client;
        private string _id;

        //[OneTimeSetUp]
        //public async Task oneTimeSetUp()
        //{
            
        //}

        [SetUp]
        public async Task Setup()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://libexam2.azurewebsites.net/");
        }

        //[Test]
        //public async Task TestGetAuthor()
        //{
        //    var response = await _client.GetAsync("api/authors/76053df4-6687-4353-8937-b45556748abe");
        //    response.EnsureSuccessStatusCode();

        //    var responseAsString = response.Content.ReadAsStringAsync().Result;
        //    var expectedAuthor = Author.FromJson(responseAsString);

            
        //}

        [Test]
        public async Task GetAuthor()
        {
            var author = new PostAuthor
            {
                FirstName = "Jens",
                LastName = "Lapidus",
                Genre = "Thriller"
            };

            var content = new StringContent(author.ToJson(), Encoding.UTF8, "application/json");

            var postResponse = await _client.PostAsync("api/authors/", content);
            postResponse.EnsureSuccessStatusCode();

            var postResponseAsString = postResponse.Content.ReadAsStringAsync().Result;

            var actualAuthor = Author.FromJson(postResponseAsString);
            _id = actualAuthor.Id;

            var response = await _client.GetAsync($"api/authors/{_id}");
            response.EnsureSuccessStatusCode();

            var responseAsString = response.Content.ReadAsStringAsync().Result;
            var expectedAuthor = Author.FromJson(responseAsString);

            Assert.AreEqual(expectedAuthor.Name, actualAuthor.Name);
            Assert.AreEqual(expectedAuthor.Age, actualAuthor.Age);
            Assert.AreEqual(expectedAuthor.Genre, actualAuthor.Genre);
        }

        [Test]
        public async Task PostAuthor_WithValidData_ShouldReturnSuccess()
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
                Age = 2018,
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
        public async Task DeleteAuthor_ShouldReturnNoContentStatusCode()
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
            var id = actualAuthor.Id;

            var deleteResponse = await _client.DeleteAsync($"api/authors/{id}");

            Assert.AreEqual(HttpStatusCode.NoContent, deleteResponse.StatusCode);
        }
    }
}