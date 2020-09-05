using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HungryPizzaAPI.Data;
using HungryPizzaAPI.Models;

namespace HungryPizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly HungryPizzaAPIContext _context;

        public PedidosController(HungryPizzaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedido()
        {
            return await _context.Pedido
                .Include(endereco => endereco.EnderecoEntrega)
                .Include(item => item.PedidoItens)
                    .ThenInclude(pizza => pizza.Pizza1)
                .Include(item => item.PedidoItens)
                    .ThenInclude(pizza => pizza.Pizza2)
                .ToListAsync();
        }

        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedido
                .Include(endereco => endereco.EnderecoEntrega)
                .Include(item => item.PedidoItens)
                    .ThenInclude(pizza => pizza.Pizza1)
                .Include(item => item.PedidoItens)
                    .ThenInclude(pizza => pizza.Pizza2)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        // PUT: api/Pedidos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pedidos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("CriarPedido")]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
            if (string.IsNullOrEmpty(pedido.NomeCliente))
            {
                throw new ArgumentException(
                    $"Informe o nome do cliente.");
            }

            if (pedido.EnderecoEntrega == null)
            {
                throw new ArgumentException(
                    $"Endereço de entrega não informado para o cliente {pedido.NomeCliente}.");
            }

            _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedido", new { id = pedido.Id }, pedido);
        }

        [HttpPost]
        [Route("CriarPedido/{login}")]
        public async Task<ActionResult<Pedido>> PostPedidoClienteCadastrado(Pedido pedido, string login)
        {
            var nome_cliente = _context.Cliente
                .Where(x => x.Login == login).FirstOrDefault().Nome;
            var id_cliente = _context.Cliente
                .Where(x => x.Login == login).FirstOrDefault().Id;
            var id_endereco_entrega = _context.Cliente
                .Where(x => x.Login == login).FirstOrDefault().EnderecoEntregaId;

            pedido.NomeCliente = nome_cliente;

            pedido.ClienteId = id_cliente;

            pedido.EnderecoEntregaId = id_endereco_entrega;

            pedido.EnderecoEntrega = _context.EnderecoEntrega
                .Where(x => x.Id == id_endereco_entrega).FirstOrDefault();

            _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedido", new { id = pedido.Id }, pedido);
        }

        // DELETE: api/Pedidos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pedido>> DeletePedido(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.Id == id);
        }

        [HttpPost]
        [Route("InserirPizza/{id}")]
        public async Task<ActionResult<PedidoItem>> PostInserirPizza(string id)
        {
            int id_pedido = _context.Pedido.Max(item => item.Id);

            Pedido pedido = await _context.Pedido
                .Where(p => p.Id == Convert.ToInt32(id_pedido))
                .FirstOrDefaultAsync();
            if (pedido.PedidoFinalizado == 1)
            {
                throw new ArgumentException(
                    $"Pedido {pedido.Id} já finalizado. Não é possível incluir novos itens.");
            }

            int ct_PedidoItems = await _context.PedidoItem
                .Where(p => p.PedidoId == Convert.ToInt32(id_pedido)).CountAsync();
            if (ct_PedidoItems > 10)
            {
                throw new ArgumentException(
                    $"Pedido {pedido.Id} não permite a inclusão de mais do que 10 itens.");
            }

            decimal preco = _context.Pizza
                .FirstOrDefault(p => p.Id == Convert.ToInt32(id))
                .PrecoSabor;

            PedidoItem pedidoItem = new PedidoItem();
            pedidoItem.Pizza1Id = Convert.ToInt32(id);
            pedidoItem.PedidoId = id_pedido;
            pedidoItem.PrecoPizza = preco;

            _context.PedidoItem.Add(pedidoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidoItem", new { id = pedidoItem.PedidoId }, pedidoItem);
        }

        [HttpPost]
        [Route("InserirPizza/{id1}-{id2}")]
        public async Task<ActionResult<PedidoItem>> PostInserirPizza2Sabores(string id1, string id2)
        {
            int id_pedido = _context.Pedido.Max(item => item.Id);

            Pedido pedido = await _context.Pedido
                .Where(p => p.Id == Convert.ToInt32(id_pedido))
                .FirstOrDefaultAsync();
            if (pedido.PedidoFinalizado == 1)
            {
                throw new ArgumentException(
                    $"Pedido {pedido.Id} já finalizado. Não é possível incluir novos itens.");
            }

            int ct_PedidoItems = await _context.PedidoItem
                .Where(p => p.PedidoId == Convert.ToInt32(id_pedido)).CountAsync();
            if (ct_PedidoItems > 10)
            {
                throw new ArgumentException(
                    $"Pedido {pedido.Id} não permite a inclusão de mais do que 10 itens.");
            }

            decimal preco1 = _context.Pizza
                .FirstOrDefault(p => p.Id == Convert.ToInt32(id1))
                .PrecoSabor / 2;
            decimal preco2 = _context.Pizza
                .FirstOrDefault(p => p.Id == Convert.ToInt32(id2))
                .PrecoSabor / 2;

            PedidoItem pedidoItem = new PedidoItem();
            pedidoItem.Pizza1Id = Convert.ToInt32(id1);
            pedidoItem.Pizza2Id = Convert.ToInt32(id2);
            pedidoItem.PedidoId = id_pedido;
            pedidoItem.PrecoPizza = preco1 + preco2;

            _context.PedidoItem.Add(pedidoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidoItem", new { id = pedidoItem.PedidoId }, pedidoItem);
        }

        // GET: api/PedidoItem/5
        [HttpGet("Item/{id}")]
        public async Task<ActionResult<PedidoItem>> GetPedidoItem(int id)
        {
            var pedidoItem = await _context.PedidoItem.FindAsync(id);

            if (pedidoItem == null)
            {
                return NotFound();
            }

            return pedidoItem;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchPedido(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

    }
}
