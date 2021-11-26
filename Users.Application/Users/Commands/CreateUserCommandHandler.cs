using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Users.Application.Interfaces;
using Users.Domain.Entities;

namespace Users.Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserDbContext _dbContext;
        public CreateUserCommandHandler(IUserDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userInfo = new UserInfo()
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
                Email = request.Email
            };

            await _dbContext.Users.AddAsync(userInfo, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return userInfo.Id;
        }
    }
}
