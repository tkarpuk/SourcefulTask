using System;

namespace Users.WebApi.DTO
{
    public class FilmCreateDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateComeUp { get; set; }
    }
}
