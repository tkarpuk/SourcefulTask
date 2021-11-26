using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users.Application.Interfaces;
using Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Users.Application.Users.Queries
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserInfo>>
    {
        private readonly IUserDbContext _dbContext;
        public GetUserListQueryHandler(IUserDbContext dbContext) => _dbContext = dbContext;

        public async Task<List<UserInfo>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var userList = await _dbContext.Users
                .Skip(request.PageSize * (request.PageN - 1))
                .Take(request.PageSize)
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .ToListAsync(cancellationToken);

            return userList;
        }
    }
}
