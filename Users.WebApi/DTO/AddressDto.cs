﻿using System;

namespace Users.WebApi.DTO
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
    }
}
