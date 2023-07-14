using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Entities;
using MediatR;

namespace Application.Posts.CommandHandlers
{
    public class UpdatePostHandler : IRequestHandler<UpdatePost, Post>
    {
        private readonly IPostsRepository _postsRepository;
        public UpdatePostHandler (IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }

        public async Task<Post> Handle(UpdatePost request, CancellationToken cancellationToken)
        {
            var updatedPost = await _postsRepository.UpdatePost(request.Content, request.Id);
            return updatedPost;
        }
    }
}
