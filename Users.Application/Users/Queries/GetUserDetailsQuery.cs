using System;
using MediatR;
using Users.Domain.Entities;

namespace Users.Application.Users.Queries
{
    public class GetUserDetailsQuery : IRequest<UserInfo>
    {
        public Guid Id { get; set; }
    }
}
