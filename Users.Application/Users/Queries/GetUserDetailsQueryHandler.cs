using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Users.Application.Common.Exceptions;
using Users.Domain.Entities;

namespace Users.Application.Users.Queries
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserInfo>
    {
        private readonly IUserDbContext _dbContext;
        public GetUserDetailsQueryHandler(IUserDbContext dbContext) => _dbContext = dbContext;

        public async Task<UserInfo> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException(nameof(user), request.Id);
            }

            return user;
        }
    }
}
