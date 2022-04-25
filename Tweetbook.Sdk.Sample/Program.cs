using Refit;
using System;
using System.Threading.Tasks;
using TweetBookApi.Contracts.V1.Request;

namespace Tweetbook.Sdk.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var identityApi = RestService.For<IIdentityApi>("https://localhost:5001");

            var registerResponse = await identityApi.RegisterAsync(new UserRegistrationRequest
            {
                Email = "sdkaccount@gmail.com",
                Password = "Test1234!"
            });

            var loginResponse = await identityApi.LoginAsync(new UserLoginRequest
            {
                Email = "sdkaccount@gmail.com",
                Password = "Test1234!"
            });

    
        }
    }
}
