﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities.Videogame.Dtos
{
    public class LoadGameDto
    {
        public string VideogameName { get; set; }
        public double Price { get; set; }
        public double? OldPrice { get; set; }
        public int PublicsherId { get; set; }
        public int PublisherName { get; set; }
        public string Description { get; set; }
        public string? ThumbnailUrl { get; set; }
    }
}
