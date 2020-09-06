using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzaAPI.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public int? ClienteId { get; set; }
        public DateTime DataPedido { get; set; }

        public string NomeCliente { get; set; }

        public virtual int? EnderecoEntregaId { get; set; }

        public EnderecoEntrega EnderecoEntrega { get; set; }

        public virtual ICollection<PedidoItem> PedidoItens { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorTotal { get; set; }

        public int PedidoFinalizado { get; set; }

    }
}
