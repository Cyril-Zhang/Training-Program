using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entity
{
    public class Purchases
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public DateTime PurchaseDateTime { get; set; }
        [Column(TypeName = "uniqueidentifier")]
        public Guid PurchaseNumber { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal TotalPrice { get; set; }
        public Movies Movie { get; set; }
        public Users User { get; set; }
    }
}
