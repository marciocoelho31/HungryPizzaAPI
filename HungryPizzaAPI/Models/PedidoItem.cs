using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzaAPI.Models
{
    public class PedidoItem
    {
        [Key]
        public int Id { get; set; }

        public int IdPedido { get; set; }

        public int IdPizza1 { get; set; }

        public int IdPizza2 { get; set; }

    }
}
