using HungryPizzaAPI.Controllers;
using HungryPizzaAPI.Data;
using HungryPizzaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizzaAPI_Testes
{
    public class PizzasUnitTest
    {
        public class PizzasControllerTests
        {
            [Fact]
            public async Task GetPizzas()
            {
                //Arrange
                var dbContext = await GetDatabaseContext();
                var userController = new PizzasController(dbContext);
                //Act
                var users = await userController.GetPizza();
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
                if (await databaseContext.Pizza.CountAsync() <= 0)
                {
                    databaseContext.Pizza.Add(new Pizza()
                    {
                        Id = 1,
                        Sabor = "Sabor teste",
                        Descricao = "Descrição teste"
                    });
                    await databaseContext.SaveChangesAsync();
                }
                return databaseContext;
            }
        }
    }
}
