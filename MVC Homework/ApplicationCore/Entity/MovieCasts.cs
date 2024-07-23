using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entity
{
    public class MovieCasts
    {
        public int MovieId { get; set; }
        public int CastId { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        public string Character { get; set; }

        public Movies Movie { get; set; }
        public Casts Cast { get; set; }
    }
}
