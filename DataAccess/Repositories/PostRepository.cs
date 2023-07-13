using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class PostRepository : IPostsRepository
    {
        private readonly SocialDbContext _ctx;
        public PostRepository(SocialDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Post> CreatePost(Post toCreate)
        {
            toCreate.DateCreated = DateTime.Now;    
            toCreate.LastModified = DateTime.Now;
            _ctx.Posts.Add(toCreate);
            await _ctx.SaveChangesAsync();
            return toCreate;
        }

        public async Task DeletePost(int postId)
        {
            var post = await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            if (post is null) return;
            _ctx.Posts.Remove(post);
            await _ctx.SaveChangesAsync();
        }

        public async Task<ICollection<Post>> GetAllPosts()
        {
            var AllPosts = await _ctx.Posts.ToListAsync();
            return AllPosts;
        }

        public async Task<Post> GetPostById(int postId)
        {
            var post = await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            return post;
        }

        public async Task<Post> UpdatePost(string updatedContent, int postId)
        {
            var post = await _ctx.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            post.LastModified = DateTime.Now;
            post.Content = updatedContent;
            await _ctx.SaveChangesAsync();
            return post;
        }
    }
}
