﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entity
{
    public class MovieGenres
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public Movies Movie { get; set; }
        public Genres Genre { get; set; }
    }
}
