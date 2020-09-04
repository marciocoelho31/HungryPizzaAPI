using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzaAPI.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(30, ErrorMessage = "O sabor suporta até 30 caracteres")]
        public string Sabor { get; set; }

        [Display(Name = "Descrição da pizza")]
        [StringLength(255)]
        public string Descricao { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Preço unitário")]
        public decimal Preco { get; set; }
    }
}
