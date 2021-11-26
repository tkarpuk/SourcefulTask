using System;

namespace Users.WebApi.DTO
{
    public class AddressUpdateDto
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
    }
}
