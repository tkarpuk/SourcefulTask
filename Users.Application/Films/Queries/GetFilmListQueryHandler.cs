using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Users.Application.Interfaces;
using Users.Domain.Entities;

namespace Users.Application.Films.Queries
{
    public class GetFilmListQueryHandler : IRequestHandler<GetFilmListQuery, List<Film>>
    {
        private readonly IUserDbContext _dbContext;
        public GetFilmListQueryHandler(IUserDbContext dbContext) => _dbContext = dbContext;

        public async Task<List<Film>> Handle(GetFilmListQuery request, CancellationToken cancellationToken)
        {
            var filmList = await _dbContext.Films
                .Skip(request.PageSize * (request.PageN - 1))
                .Take(request.PageSize)
                .OrderBy(u => u.Name)
                .ToListAsync(cancellationToken);

            return filmList;
        }
    }
}
