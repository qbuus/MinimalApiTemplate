using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Posts.Commands
{
    public class CreatePost : IRequest<Post>
    {
        public string? PostContent { get; set; }
    }
}
