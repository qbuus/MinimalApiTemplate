using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.Posts.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Posts.QueryHandlers
{
    public class GetPostByIdHandler : IRequestHandler<GetPostById, Post>
    {
        private readonly IPostsRepository _postsRepository;
        public GetPostByIdHandler (IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }

        public async Task<Post> Handle(GetPostById request, CancellationToken cancellationToken)
        {
            var postToDisplayById = await _postsRepository.GetPostById(request.Id);
            return postToDisplayById;
        }
    }
}
