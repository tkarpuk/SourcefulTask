using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users.Application.Interfaces;
using Users.Domain.Entities;

namespace Users.Application.Addresses.Commands
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, Guid>
    {
        private readonly IUserDbContext _dbContext;
        public CreateAddressCommandHandler(IUserDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = new Address()
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                City = request.City,
                Street = request.Street,
                HouseNumber = request.HouseNumber
            };

            await _dbContext.Addresses.AddAsync(address, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return address.Id;
        }
    }
}
