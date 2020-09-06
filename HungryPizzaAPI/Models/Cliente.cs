using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzaAPI.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "O nome suporta até 50 caracteres")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "O login suporta até 15 caracteres")]
        public string Login { get; set; }

        public string Senha { get; set; }

        public virtual int? EnderecoEntregaId { get; set; }
        public virtual EnderecoEntrega EnderecoEntrega { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

    }
}
