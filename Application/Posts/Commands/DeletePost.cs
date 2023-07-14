using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Posts.Commands
{
    public class DeletePost : IRequest
    {
        public int Id { get; set; }
    }
}
