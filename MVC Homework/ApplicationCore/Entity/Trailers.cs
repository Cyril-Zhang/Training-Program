﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entity
{
    public class Trailers
    {
        public int Id { get; set; }
        public int MovieId { get; set; }

        [Column(TypeName = "nvarchar(2084)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(2084)")]
        public string TrailerUrl { get; set; }

        public Movies Movie { get; set; }
    }
}
