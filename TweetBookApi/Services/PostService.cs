﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBookApi.Data;
using TweetBookApi.Domain;

namespace TweetBookApi.Services
{
    public class PostService : IPostService
    {
        private readonly DataContext _dataContext;

        public PostService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> DeletePostAsync(Guid postId)
        {
            var post = await GetPostByIdAsync(postId);
            _dataContext.Posts.Remove(post);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<bool> CreatePostAsync(Post post)
        {
            await _dataContext.Posts.AddAsync(post);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<Post> GetPostByIdAsync(Guid postId)
        {
            return await _dataContext.Posts.FirstOrDefaultAsync(x => x.Id == postId);
        }

        public async Task<List<Post>> GetPostsAsync() 
        {
            return await _dataContext.Posts
                .Include(x => x.Tags).ToListAsync();
        }

        public async Task<bool> UpdatePostAsync(Post postToUpdate)
        {
            _dataContext.Posts.Update(postToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool>  UserOwnPostAsync(Guid postId, string userId)
        {
            var post = await _dataContext.Posts.AsNoTracking().SingleOrDefaultAsync(x => x.Id == postId);

            if(post == null)
            {
                return false;
            }

            if(post.UserId != userId)
            {
                return false;
            }

            return true;
        }

        public async Task<List<Tag>> GetAllTagAsync()
        {
            return await _dataContext.Tags.ToListAsync();
        }

        public async Task<bool> CreateTagAsync(Tag tag)
        {
            await _dataContext.Tags.AddAsync(tag);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
    }
}
