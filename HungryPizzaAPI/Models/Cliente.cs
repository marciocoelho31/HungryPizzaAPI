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

        [Required]
        [MaxLength(10, ErrorMessage = "A senha suporta até 10 caracteres")]
        public string Senha { get; set; }

        public virtual int? EnderecoEntregaId { get; set; }

    }
}
