using System;
using MediatR;
using Users.Domain.Entities;

namespace Users.Application.Films.Queries
{
    public class GetFilmDetailsQuery : IRequest<Film>
    {
        public Guid Id { get; set; }
    }
}
