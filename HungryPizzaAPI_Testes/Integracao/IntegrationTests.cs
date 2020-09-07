using HungryPizzaAPI;
using HungryPizzaAPI.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizzaAPI_Testes
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public IntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/API/Clientes")]
        [InlineData("/API/Clientes/Historico/teste")]
        [InlineData("/API/EnderecoEntrega")]
        [InlineData("/API/Pedidos")]
        [InlineData("/API/Pizzas")]
        public async Task BaseTest(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestPostClienteAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/API/Clientes",
                Body = new
                {
                    Nome = "Teste",
                    Login = "LoginTeste",
                    EnderecoEntregaId = 2
                }
            };
            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPostEnderecoEntregaAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/API/EnderecoEntrega",
                Body = new
                {
                    Endereco = "Rua A",
                    Bairro = "Centro",
                    Cidade = "Rio de Janeiro",
                    Estado = "RJ",
                    Cep = "20000-000"
                }
            };
            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPostCriarPedidoSemCadastroAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/API/Pedidos/CriarPedido",
                Body = new
                {
                    NomeCliente = "Joao",
                    EnderecoEntrega = new {
                        Endereco = "Rua XYZ",
                        Bairro = "Vila Nova",
                        Cidade = "São Paulo",
                        Estado = "SP",
                        Cep = "01000-001"
                    }
                }
            };
            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPostCriarPedidoClienteCadastradoAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/API/Pedidos/CriarPedido/loginteste"
            };
            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsync(request.Url, ContentHelper.GetStringContent(null));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPostInserirPizza1SaborEmPedidoAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/API/Pedidos/InserirPizza/6"
            };
            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsync(request.Url, ContentHelper.GetStringContent(null));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPostInserirPizza2SaboresEmPedidoAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/API/Pedidos/InserirPizza/6-7"
            };
            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsync(request.Url, ContentHelper.GetStringContent(null));
            var value = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPatchFinalizarPedidoAsync()
        {
            // Arrange
            var requestCriaPedido = new
            {
                Url = "/API/Pedidos/CriarPedido",
                Body = new
                {
                    NomeCliente = "Joao",
                    EnderecoEntrega = new
                    {
                        Endereco = "Rua XYZ",
                        Bairro = "Vila Nova",
                        Cidade = "São Paulo",
                        Estado = "SP",
                        Cep = "01000-001"
                    }
                }
            };

            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsync(requestCriaPedido.Url, ContentHelper.GetStringContent(requestCriaPedido.Body));
            var valuePedidoCriado = await response.Content.ReadAsStringAsync();

            Pedido resultado = JsonConvert.DeserializeObject<Pedido>(valuePedidoCriado);
            var requestFinalizaPedido = new
            {
                Url = "/API/Pedidos/" + resultado.Id
            };

            var responseFinalizaPedido = await client.PatchAsync(requestFinalizaPedido.Url, 
                ContentHelper.GetStringContent(null));
            var value = await responseFinalizaPedido.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }

    }

}
