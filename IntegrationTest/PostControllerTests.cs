using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TweetBookApi.Contracts.V1;
using TweetBookApi.Contracts.V1.Request;
using TweetBookApi.Domain;
using Xunit;

namespace IntegrationTest
{
    public class PostControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GeAll_WithoutAnyPosts_ReturnsEmptyResponse()
        {
            //Arrange
            await AuthenticateAsync();
            //Act
            var response = await TestClient.GetAsync(ApiRoutes.Posts.GetAll);
            //Assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<List<Post>>()).Should().NotBeEmpty();
        }


        [Fact]
        public async Task PostedPost_ReturnsNewlyCreatedPost()
        {
            //Arrange
            await AuthenticateAsync();
           var createdPost = await CreatePostAsync(new CreatePostRequest { Name = "Test Post" });

            //Act
            var response = await TestClient.GetAsync(ApiRoutes.Posts.Get.Replace("{postId}", createdPost.Id.ToString()));

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var returnedPost = await response.Content.ReadAsAsync<Post>();
            returnedPost.Id.Should().Be(createdPost.Id);
            returnedPost.Name.Should().Be("Test post");
        
        }
    }
}
