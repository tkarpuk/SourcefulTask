using System;
using MediatR;

namespace Users.Application.Addresses.Commands
{
    public class DeleteAddressCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
