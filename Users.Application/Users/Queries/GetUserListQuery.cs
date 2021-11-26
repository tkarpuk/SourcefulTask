using System.Collections.Generic;
using MediatR;
using Users.Domain.Entities;

namespace Users.Application.Users.Queries
{
    public class GetUserListQuery : IRequest<List<UserInfo>>
    {
        public int PageSize { get; set; }
        public int PageN { get; set; }
    }
}
