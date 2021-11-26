using System;
using MediatR;

namespace Users.Application.Films.Commands
{
    public class DeleteFilmCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
