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
    public class EnderecoEntregaController : ControllerBase
    {
        private readonly HungryPizzaAPIContext _context;

        public EnderecoEntregaController(HungryPizzaAPIContext context)
        {
            _context = context;
        }

        // GET: api/EnderecoEntrega
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoEntrega>>> GetEnderecoEntrega()
        {
            return await _context.EnderecoEntrega.ToListAsync();
        }

        // GET: api/EnderecoEntrega/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoEntrega>> GetEnderecoEntrega(int id)
        {
            var enderecoEntrega = await _context.EnderecoEntrega.FindAsync(id);

            if (enderecoEntrega == null)
            {
                return NotFound();
            }

            return enderecoEntrega;
        }

        // PUT: api/EnderecoEntrega/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnderecoEntrega(int id, EnderecoEntrega enderecoEntrega)
        {
            if (id != enderecoEntrega.EnderecoEntregaId)
            {
                return BadRequest();
            }

            _context.Entry(enderecoEntrega).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoEntregaExists(id))
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

        // POST: api/EnderecoEntrega
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EnderecoEntrega>> PostEnderecoEntrega(EnderecoEntrega enderecoEntrega)
        {
            _context.EnderecoEntrega.Add(enderecoEntrega);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnderecoEntrega", new { id = enderecoEntrega.EnderecoEntregaId }, enderecoEntrega);
        }

        // DELETE: api/EnderecoEntrega/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EnderecoEntrega>> DeleteEnderecoEntrega(int id)
        {
            var enderecoEntrega = await _context.EnderecoEntrega.FindAsync(id);
            if (enderecoEntrega == null)
            {
                return NotFound();
            }

            _context.EnderecoEntrega.Remove(enderecoEntrega);
            await _context.SaveChangesAsync();

            return enderecoEntrega;
        }

        private bool EnderecoEntregaExists(int id)
        {
            return _context.EnderecoEntrega.Any(e => e.EnderecoEntregaId == id);
        }
    }
}
