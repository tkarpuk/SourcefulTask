using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Users.Application.Common.Exceptions;
using Users.Application.Interfaces;

namespace Users.Application.Addresses.Commands
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, Unit>
    {
        private readonly IUserDbContext _dbContext;
        public UpdateAddressCommandHandler(IUserDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _dbContext.Addresses.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
            if (address == null)
            {
                throw new NotFoundException(nameof(address), request.Id);
            }

            address.City = request.City;
            address.Street = request.Street;
            address.HouseNumber = request.HouseNumber;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
