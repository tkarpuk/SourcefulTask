using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Users.Application.Common.Exceptions;

namespace Users.Application.Users.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserDbContext _dbContext;
        public UpdateUserCommandHandler(IUserDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userInfo = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
            if (userInfo == null)
            {
                throw new NotFoundException(nameof(userInfo), request.Id);
            }

            userInfo.FirstName = request.FirstName;
            userInfo.LastName = request.LastName;
            userInfo.Age = request.Age;
            userInfo.Email = request.Email;

            //_dbContext.Users.Update(userInfo);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
