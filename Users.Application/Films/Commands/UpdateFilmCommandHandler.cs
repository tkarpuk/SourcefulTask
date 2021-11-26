using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Users.Application.Common.Exceptions;
using Users.Application.Interfaces;

namespace Users.Application.Films.Commands
{
    public class UpdateFilmCommandHandler : IRequestHandler<UpdateFilmCommand, Unit>
    {
        private readonly IUserDbContext _dbContext;
        public UpdateFilmCommandHandler(IUserDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateFilmCommand request, CancellationToken cancellationToken)
        {
            var film = await _dbContext.Films.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
            if (film == null)
            {
                throw new NotFoundException(nameof(film), request.Id);
            }

            film.Name = request.Name;
            film.DateComeUp = request.DateComeUp;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
