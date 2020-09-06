using HungryPizzaAPI.Controllers;
using HungryPizzaAPI.Data;
using HungryPizzaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizzaAPI_Testes
{
    public class ClientesUnitTest
    {
        public class ClientesControllerTests
        {
            [Fact]
            public async Task GetClientes()
            {
                //Arrange
                var dbContext = await GetDatabaseContext();
                var userController = new ClientesController(dbContext);
                //Act
                var users = await userController.GetCliente();
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
                if (await databaseContext.Cliente.CountAsync() <= 0)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        databaseContext.Cliente.Add(new Cliente()
                        {
                            Id = i,
                            Nome = "Cliente " + i.ToString(),
                            Login = "login" + i.ToString()
                        });
                        await databaseContext.SaveChangesAsync();
                    }
                }
                return databaseContext;
            }
        }
    }
}
