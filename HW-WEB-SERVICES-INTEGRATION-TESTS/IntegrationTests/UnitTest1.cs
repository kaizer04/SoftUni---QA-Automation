
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class Tests
    {
        private long _householdId;
        private List<long> _wishlistIds;
        private HttpClient _client;
        private List<Book> _listOfBooks = new List<Book>();
        private Random random = new Random();

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:3000/");

            _client.DefaultRequestHeaders.Add("G-Token", "ROM831ESV");
        }

        [Test]
        [Order(1)]
        public async Task PostHousehold()
        {
            var household = new Household() { Name = "vanio" };
            var request = new HttpRequestMessage(HttpMethod.Post, "household");

            request.Content =  new StringContent(household.ToJson(), Encoding.UTF8, "application/json");
            
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            var householdObject = Household.FromJson(responseAsString);
            _householdId = household.Id;
        }

        [Test]
        [Order(2)]
        public async Task AddUser()
        {
            var path = Path.GetFullPath(Directory.GetCurrentDirectory() + "/../../../datafiles/households.json");
            var users = User.ListFromJson(File.ReadAllText(path));
            users.ForEach(u => u.HouseholdId = _householdId);

            for (int i = 0; i < 2; i++)
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "users");
                request.Content = new StringContent(users[random.Next(0, 3)].ToJson(), Encoding.UTF8, "application/json");

                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var respondAsString = await response.Content.ReadAsStringAsync();

                var responseUser = User.FromJson(respondAsString);
                _wishlistIds.Add(responseUser.WishlistId);
            }
        }
        
        [Test]
        [Order(3)]
        public async Task GetBooks()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "books");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();

            _listOfBooks = Book.ListFromJson(responseAsString);
        }

        [Test]
        [Order(4)]
        public async Task AddBookToWishlist()
        {
            foreach (var wishlistId in _wishlistIds)
            {
                var bookId = _listOfBooks[random.Next(0, _listOfBooks.Count)].Id;
                var request = new HttpRequestMessage(HttpMethod.Post, $"wishlists/{wishlistId}/book/{bookId}");
                request.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json");

                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
        }

        [Test]
        [Order(5)]
        public async Task GetHoueholdBooks()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"households/{_householdId}/wishlistBooks");

            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var resAsString = await response.Content.ReadAsStringAsync();
            
        }
    }
}