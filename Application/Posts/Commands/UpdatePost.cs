using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Posts.Commands
{
    public class UpdatePost : IRequest<Post>
    {
        public int Id { get; set; }
        public string? Content { get; set; }
    }
}
