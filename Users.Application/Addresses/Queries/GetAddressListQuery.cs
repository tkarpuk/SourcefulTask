using System;
using System.Collections.Generic;
using MediatR;
using Users.Domain.Entities;

namespace Users.Application.Addresses.Queries
{
    public class GetAddressListQuery : IRequest<List<Address>>
    {
        public Guid UserId { get; set; }
        public int PageSize { get; set; }
        public int PageN { get; set; }
    }
}
