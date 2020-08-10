namespace Tests
{
    using FluentAssertions;
    using IntegrationTests.Models;
    using NUnit.Framework;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class GetTests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            var test = Guid.Empty.ToString();
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:6058")
            };
        }

        [Test]
        public async Task GetAuthor_WithValidId_ShouldReturnSuccess()
        {
            var expectedAuthor = new Author
            {
                Id = "a1da1d8e-1988-4634-b538-a01709477b77",
                Name = "Jens Lapidus",
                Age = 44,
                Genre = "Thriller"
            };

            var response = await _client.GetAsync($"/api/authors/{expectedAuthor.Id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var actualAuthor = Author.FromJson(content);

            actualAuthor.Should().BeEquivalentTo(expectedAuthor);
        }

        [Test]
        public async Task GetAuthor_WithInValidId_ShouldReturnNotFound()
        {
            var response = await _client.GetAsync($"/api/authors/{Guid.Empty}");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}