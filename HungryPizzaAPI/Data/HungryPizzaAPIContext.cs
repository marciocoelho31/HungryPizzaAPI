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

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Pizza> Pizza { get; set; }

        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<EnderecoEntrega> EnderecoEntrega { get; set; }
    }
}
