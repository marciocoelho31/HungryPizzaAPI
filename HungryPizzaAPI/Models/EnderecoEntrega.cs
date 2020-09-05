using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzaAPI.Models
{
    public class EnderecoEntrega
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="O endereço deve ser preenchido")]
        [MaxLength(100, ErrorMessage = "O endereço suporta até 100 caracteres")]
        public string Endereco { get; set; }

        [MaxLength(50, ErrorMessage = "O bairro suporta até 50 caracteres")]
        public string Bairro { get; set; }

        [MaxLength(50, ErrorMessage = "A cidade suporta até 50 caracteres")]
        public string Cidade { get; set; }

        [MaxLength(2, ErrorMessage = "O estado suporta até 2 caracteres")]
        public string Estado { get; set; }

        [MaxLength(9, ErrorMessage = "O CEP suporta até 9 caracteres")]
        [DisplayFormat(DataFormatString = "{0:#####-###}")]
        public string Cep { get; set; }

    }
}
