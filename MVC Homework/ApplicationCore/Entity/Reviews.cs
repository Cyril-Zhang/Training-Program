using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entity
{
    public class Reviews
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "decimal(3, 2)")]
        public decimal Rating { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string ReviewText { get; set; }

        public Movies Movie { get; set; }
        public Users User { get; set; }
    }
}
