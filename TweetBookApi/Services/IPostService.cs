using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBookApi.Domain;

namespace TweetBookApi.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPostsAsync();
        Task<bool> CreatePostAsync(Post post);
        Task<Post> GetPostByIdAsync(Guid postId);

        Task<bool> UpdatePostAsync(Post postToUpdate);
        Task<bool> DeletePostAsync(Guid postId);
        Task<bool> UserOwnPostAsync(Guid postId, string userId);
    }
}
