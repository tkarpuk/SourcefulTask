using System;
using System.Collections.Generic;
using MediatR;
using Users.Domain.Entities;

namespace Users.Application.Films.Queries
{
    public class GetFilmListQuery : IRequest<List<Film>>
    {
        public Guid UserId { get; set; }
        public int PageSize { get; set; }
        public int PageN { get; set; }
    }
}
