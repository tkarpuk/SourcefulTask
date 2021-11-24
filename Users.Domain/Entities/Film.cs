using System;

namespace Users.Domain.Entities
{
    public class Film
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
