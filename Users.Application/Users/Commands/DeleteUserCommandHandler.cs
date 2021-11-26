using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Users.Application.Common.Exceptions;
using Users.Application.Interfaces;

namespace Users.Application.Users.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserDbContext _dbContext;
        public DeleteUserCommandHandler(IUserDbContext dbContext) => _dbContext = dbContext;
        
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userInfo = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
            if (userInfo == null)
            {
                throw new NotFoundException(nameof(userInfo), request.Id);
            }

            _dbContext.Users.Remove(userInfo);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
