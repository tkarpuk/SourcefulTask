using System;

namespace Users.Domain.Entities
{
    public class Address
    {        
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
    }
}
