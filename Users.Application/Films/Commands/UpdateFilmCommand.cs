using System;
using MediatR;

namespace Users.Application.Films.Commands
{
    public class UpdateFilmCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateComeUp { get; set; }
    }
}
