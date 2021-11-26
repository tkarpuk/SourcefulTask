using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Users.Application.Common.Exceptions;
using Users.Application.Interfaces;

namespace Users.Application.Films.Commands
{
    public class DeleteFilmCommandHandler : IRequestHandler<DeleteFilmCommand, Unit>
    {
        private readonly IUserDbContext _dbContext;
        public DeleteFilmCommandHandler(IUserDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteFilmCommand request, CancellationToken cancellationToken)
        {
            var film = await _dbContext.Films.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
            if (film == null)
            {
                throw new NotFoundException(nameof(film), request.Id);
            }

            _dbContext.Films.Remove(film);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
