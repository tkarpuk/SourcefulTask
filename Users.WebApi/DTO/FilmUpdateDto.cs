using System;

namespace Users.WebApi.DTO
{
    public class FilmUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateComeUp { get; set; }
    }
}
