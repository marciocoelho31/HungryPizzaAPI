using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzaAPI.Models
{
    public class PedidoItem
    {
        [Key]
        public int Id { get; set; }

        public int PedidoId { get; set; }

        public virtual int? Pizza1Id { get; set; }
        public virtual Pizza Pizza1 { get; set; }

        public virtual int? Pizza2Id { get; set; }
        public virtual Pizza Pizza2 { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoPizza { get; set; }

    }
}
