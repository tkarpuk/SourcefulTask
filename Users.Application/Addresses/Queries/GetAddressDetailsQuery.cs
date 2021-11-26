using System;
using MediatR;
using Users.Domain.Entities;

namespace Users.Application.Addresses.Queries
{
    public class GetAddressDetailsQuery : IRequest<Address>
    {
        public Guid Id { get; set; }
    }
}
