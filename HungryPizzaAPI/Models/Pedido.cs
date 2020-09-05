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

        public int? ClienteId { get; set; }
        [Required(ErrorMessage ="A data do pedido deve ser preenchida")]
        public DateTime? DataPedido { get; set; }

        public string NomeCliente { get; set; }

        public virtual int? EnderecoEntregaId { get; set; }

        public EnderecoEntrega EnderecoEntrega { get; set; }

        public virtual ICollection<PedidoItem> PedidoItens { get; set; }

        public int PedidoFinalizado { get; set; }

    }
}
