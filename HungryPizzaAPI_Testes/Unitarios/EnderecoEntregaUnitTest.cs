using HungryPizzaAPI.Controllers;
using HungryPizzaAPI.Data;
using HungryPizzaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizzaAPI_Testes
{
    public class EnderecoEntregaUnitTest
    {
        public class EnderecoEntregaControllerTests
        {
            [Fact]
            public async Task GetEnderecosEntrega()
            {
                //Arrange
                var dbContext = await GetDatabaseContext();
                var userController = new EnderecoEntregaController(dbContext);
                //Act
                var users = await userController.GetEnderecoEntrega();
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
                if (await databaseContext.EnderecoEntrega.CountAsync() <= 0)
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        databaseContext.EnderecoEntrega.Add(new EnderecoEntrega()
                        {
                            Id = i,
                            Endereco = "Endereço " + i.ToString()
                        });
                        await databaseContext.SaveChangesAsync();
                    }
                }
                return databaseContext;
            }
        }
    }
}
