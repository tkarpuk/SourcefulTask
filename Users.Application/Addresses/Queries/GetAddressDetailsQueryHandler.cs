using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Users.Application.Common.Exceptions;
using Users.Application.Interfaces;
using Users.Domain.Entities;

namespace Users.Application.Addresses.Queries
{
    public class GetAddressDetailsQueryHandler : IRequestHandler<GetAddressDetailsQuery, Address>
    {
        private readonly IUserDbContext _dbContext;
        public GetAddressDetailsQueryHandler(IUserDbContext dbContext) => _dbContext = dbContext;

        public async Task<Address> Handle(GetAddressDetailsQuery request, CancellationToken cancellationToken)
        {
            var address = await _dbContext.Addresses.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
            if (address == null)
            {
                throw new NotFoundException(nameof(address), request.Id);
            }

            return address;
        }
    }
}
