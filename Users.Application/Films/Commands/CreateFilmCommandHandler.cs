using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users.Application.Interfaces;
using Users.Domain.Entities;

namespace Users.Application.Films.Commands
{
    public class CreateFilmCommandHandler : IRequestHandler<CreateFilmCommand, Guid>
    {
        private readonly IUserDbContext _dbContext;
        public CreateFilmCommandHandler(IUserDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateFilmCommand request, CancellationToken cancellationToken)
        {
            var film = new Film()
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Name = request.Name,
                DateComeUp = request.DateComeUp
            };

            await _dbContext.Films.AddAsync(film, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return film.Id;
        }
    }
}
