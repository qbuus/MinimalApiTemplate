using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Posts.Commands;
using MediatR;
using Domain.Entities;
using Application.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Application.Posts.CommandHandlers
{
    public class CreatePostHandler : IRequestHandler<CreatePost, Post>
    {
        private readonly IPostsRepository _postsRepository;

        public CreatePostHandler(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }

        public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
        {
            var newPost = new Post
            {
                Content = request.PostContent,
            };
            return await _postsRepository.CreatePost(newPost); 
        }
    }
}
