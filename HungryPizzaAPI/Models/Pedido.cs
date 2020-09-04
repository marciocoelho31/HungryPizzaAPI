using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzaAPI.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public int IdCliente { get; set; }

        public string NomeCliente { get; set; }

        public EnderecoEntrega IdEnderecoEntrega { get; set; }

    }
}
