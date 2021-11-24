using System;
using System.Collections.Generic;

namespace Users.Domain.Entities
{
    public class UserInfo
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<Film> Films { get; set; }
    }
}
