using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Users.Application.Interfaces;
using Users.Domain.Entities;

namespace Users.Application.Addresses.Queries
{
    public class GetAddressListQueryHandler : IRequestHandler<GetAddressListQuery, List<Address>>
    {
        private readonly IUserDbContext _dbContext;
        public GetAddressListQueryHandler(IUserDbContext dbContext) => _dbContext = dbContext;

        public async Task<List<Address>> Handle(GetAddressListQuery request, CancellationToken cancellationToken)
        {
            var addressList = await _dbContext.Addresses
                .Skip(request.PageSize * (request.PageN - 1))
                .Take(request.PageSize)
                .OrderBy(u => u.City)
                .ThenBy(u => u.Street)
                .ThenBy(u => u.HouseNumber)
                .ToListAsync(cancellationToken);

            return addressList;
        }
    }
}
