using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using TweetBookApi;
using TweetBookApi.Contracts.V1;

namespace ItegrationTests
{
    public class Tests
    {
        private readonly HttpClient _client;

        public Tests()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }
        [SetUp]
        public void Setup()
        {
  
        }

        [Test]
        public async Task Test1()
        {
         var response = await _client.GetAsync(ApiRoutes.Posts.Get.Replace("{postId}", "1"));
        }
    }
}