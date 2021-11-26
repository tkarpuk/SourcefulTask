﻿using System;

namespace Users.WebApi.DTO
{
    public class FilmDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateComeUp { get; set; }
    }
}
