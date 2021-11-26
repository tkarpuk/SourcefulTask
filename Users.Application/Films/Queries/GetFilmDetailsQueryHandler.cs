using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Users.Application.Common.Exceptions;
using Users.Application.Interfaces;
using Users.Domain.Entities;

namespace Users.Application.Films.Queries
{
    public class GetFilmDetailsQueryHandler : IRequestHandler<GetFilmDetailsQuery, Film>
    {
        private readonly IUserDbContext _dbContext;
        public GetFilmDetailsQueryHandler(IUserDbContext dbContext) => _dbContext = dbContext;

        public async Task<Film> Handle(GetFilmDetailsQuery request, CancellationToken cancellationToken)
        {
            var film = await _dbContext.Films.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
            if (film == null)
            {
                throw new NotFoundException(nameof(film), request.Id);
            }

            return film;
        }
    }
}
