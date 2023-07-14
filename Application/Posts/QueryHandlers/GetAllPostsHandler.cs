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
    public class GetAllPostsHandler : IRequestHandler<GetAllPosts, ICollection<Post>>
    {
        private readonly IPostsRepository _postsRepository;
        public GetAllPostsHandler(IPostsRepository postsRepository)
        {
            _postsRepository = postsRepository;
        }
        public async Task<ICollection<Post>> Handle(GetAllPosts request, CancellationToken cancellationToken)
        {
            var AllPosts = await _postsRepository.GetAllPosts();
            return AllPosts;
        }
    }
}
