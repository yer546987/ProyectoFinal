using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Casino.Data;
using CasinoApp.Models.Parameters;

namespace Casino.Controllers.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientesController : ControllerBase
    {
        private readonly CasinoContext _context;

        public IngredientesController(CasinoContext context)
        {
            _context = context;
        }

        // GET: api/Ingredientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingredientes>>> GetIngredientes()
        {
            return await _context.Ingredientes.ToListAsync();
        }

        // GET: api/Ingredientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredientes>> GetIngredientes(int id)
        {
            var ingredientes = await _context.Ingredientes.FindAsync(id);

            if (ingredientes == null)
            {
                return NotFound();
            }

            return ingredientes;
        }

        // PUT: api/Ingredientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredientes(int id, Ingredientes ingredientes)
        {
            if (id != ingredientes.Id)
            {
                return BadRequest();
            }

            _context.Entry(ingredientes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientesExists(id))
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

        // POST: api/Ingredientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ingredientes>> PostIngredientes(Ingredientes ingredientes)
        {
            _context.Ingredientes.Add(ingredientes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngredientes", new { id = ingredientes.Id }, ingredientes);
        }

        // DELETE: api/Ingredientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ingredientes>> DeleteIngredientes(int id)
        {
            var ingredientes = await _context.Ingredientes.FindAsync(id);
            if (ingredientes == null)
            {
                return NotFound();
            }

            _context.Ingredientes.Remove(ingredientes);
            await _context.SaveChangesAsync();

            return ingredientes;
        }

        private bool IngredientesExists(int id)
        {
            return _context.Ingredientes.Any(e => e.Id == id);
        }
    }
}
