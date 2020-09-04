using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HungryPizzaAPI.Models;

namespace HungryPizzaAPI.Data
{
    public class HungryPizzaAPIContext : DbContext
    {
        public HungryPizzaAPIContext (DbContextOptions<HungryPizzaAPIContext> options)
            : base(options)
        {
        }

        public DbSet<HungryPizzaAPI.Models.Cliente> Cliente { get; set; }

        public DbSet<HungryPizzaAPI.Models.Pizza> Pizza { get; set; }

        public DbSet<HungryPizzaAPI.Models.Pedido> Pedido { get; set; }

        public DbSet<HungryPizzaAPI.Models.EnderecoEntrega> EnderecoEntrega { get; set; }
    }
}
