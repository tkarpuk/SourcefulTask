using System;
using MediatR;

namespace Users.Application.Films.Commands
{
    public class CreateFilmCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateComeUp { get; set; }
    }
}
