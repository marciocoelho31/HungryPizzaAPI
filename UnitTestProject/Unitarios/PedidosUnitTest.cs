using HungryPizzaAPI.Controllers;
using HungryPizzaAPI.Data;
using HungryPizzaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizzaAPI_Testes
{
    public class PedidosUnitTest
    {
        public class PedidosControllerTests
        {
            [Fact]
            public async Task GetPedidos()
            {
                //Arrange
                var dbContext = await GetDatabaseContext();
                var userController = new PedidosController(dbContext);
                //Act
                var users = await userController.GetPedido();
                //Assert
                Assert.NotNull(users.Value);
            }

            private async Task<HungryPizzaAPIContext> GetDatabaseContext()
            {
                var options = new DbContextOptionsBuilder<HungryPizzaAPIContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;
                var databaseContext = new HungryPizzaAPIContext(options);
                databaseContext.Database.EnsureCreated();
                if (await databaseContext.Pedido.CountAsync() <= 0)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        databaseContext.Pedido.Add(new Pedido()
                        {
                            Id = i
                        });
                        await databaseContext.SaveChangesAsync();
                    }
                }
                return databaseContext;
            }
        }
    }
}
