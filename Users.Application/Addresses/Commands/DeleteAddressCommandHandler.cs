using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Users.Application.Common.Exceptions;
using Users.Application.Interfaces;

namespace Users.Application.Addresses.Commands
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, Unit>
    {
        private readonly IUserDbContext _dbContext;
        public DeleteAddressCommandHandler(IUserDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _dbContext.Addresses.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
            if (address == null)
            {
                throw new NotFoundException(nameof(address), request.Id);
            }

            _dbContext.Addresses.Remove(address);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
