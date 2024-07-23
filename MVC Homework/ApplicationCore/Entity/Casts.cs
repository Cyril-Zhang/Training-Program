using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entity
{
    public class Casts
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Gender { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(2084)")]
        public string ProfilePath { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string TmdbUrl { get; set; }
        public ICollection<MovieCasts> MovieCasts { get; set; }
    }
}
