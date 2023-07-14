using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.Posts.Commands;
using MediatR;

namespace Application.Posts.CommandHandlers
{
    public class DeletePostHandler: IRequestHandler<DeletePost>
    {
        private readonly IPostsRepository _postsRepository;
        public DeletePostHandler(IPostsRepository postsRepository) 
        {
            _postsRepository = postsRepository;
        }
        public async Task Handle(DeletePost request, CancellationToken cancellationToken)
        {
            await _postsRepository.DeletePost(request.Id);        
        }
    }
}
