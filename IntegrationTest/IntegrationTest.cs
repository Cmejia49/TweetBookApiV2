
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using TweetBookApi;
using TweetBookApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Threading.Tasks;
using TweetBookApi.Contracts.V1.Request;
using TweetBookApi.Contracts.V1.Response;
using System.Net.Http.Headers;
using TweetBookApi.Contracts.V1;

namespace IntegrationTest
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;

        protected IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
           .WithWebHostBuilder(builder =>
           {
               builder.ConfigureServices(services =>
               {
                   services.RemoveAll(typeof(DataContext));
                   services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("integration_test_db"));
               });
           });
            TestClient = appFactory.CreateClient();
        }

        protected async Task AuthenticateAsync()
        {
            TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }

        protected async Task<PostResponse> CreatePostAsync(CreatePostRequest request)
        {
            var response =await TestClient.PostAsJsonAsync(ApiRoutes.Posts.Create, request);

            return await response.Content.ReadAsAsync<PostResponse>();
        }
        private async Task<string> GetJwtAsync()
        {
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Identity.Login, new UserRegistrationRequest() { Email = "test@gmail.com", Password = "@Master_File$0" });
            var registrationResponse = await response.Content.ReadAsAsync<AuthSuccessResponse>();

            return registrationResponse.Token;
        }
    }
}
