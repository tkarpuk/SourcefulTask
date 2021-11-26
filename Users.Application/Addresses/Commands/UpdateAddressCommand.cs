using System;
using MediatR;

namespace Users.Application.Addresses.Commands
{
    public class UpdateAddressCommand : IRequest
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
    }
}
