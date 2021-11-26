using System;
using MediatR;

namespace Users.Application.Addresses.Commands
{
    public class CreateAddressCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
    }
}
