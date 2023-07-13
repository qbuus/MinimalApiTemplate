using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Abstractions
{
    public interface IPostsRepository
    {
        Task<ICollection<Post>> GetAllPosts();
        Task<Post> GetPostById(int postId);
        Task<Post> CreatePost(Post toCreate);
        Task<Post> UpdatePost(string updatedContent, int postId);
        Task DeletePost(int postId);
    }
}
