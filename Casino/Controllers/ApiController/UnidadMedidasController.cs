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
    public class UnidadMedidasController : ControllerBase
    {
        private readonly CasinoContext _context;

        public UnidadMedidasController(CasinoContext context)
        {
            _context = context;
        }

        // GET: api/UnidadMedidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadMedida>>> GetUnidadMedida()
        {
            return await _context.UnidadMedida.ToListAsync();
        }

        // GET: api/UnidadMedidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadMedida>> GetUnidadMedida(int id)
        {
            var unidadMedida = await _context.UnidadMedida.FindAsync(id);

            if (unidadMedida == null)
            {
                return NotFound();
            }

            return unidadMedida;
        }

        // PUT: api/UnidadMedidas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidadMedida(int id, UnidadMedida unidadMedida)
        {
            if (id != unidadMedida.Id)
            {
                return BadRequest();
            }

            _context.Entry(unidadMedida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadMedidaExists(id))
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

        // POST: api/UnidadMedidas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UnidadMedida>> PostUnidadMedida(UnidadMedida unidadMedida)
        {
            _context.UnidadMedida.Add(unidadMedida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnidadMedida", new { id = unidadMedida.Id }, unidadMedida);
        }

        // DELETE: api/UnidadMedidas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UnidadMedida>> DeleteUnidadMedida(int id)
        {
            var unidadMedida = await _context.UnidadMedida.FindAsync(id);
            if (unidadMedida == null)
            {
                return NotFound();
            }

            _context.UnidadMedida.Remove(unidadMedida);
            await _context.SaveChangesAsync();

            return unidadMedida;
        }

        private bool UnidadMedidaExists(int id)
        {
            return _context.UnidadMedida.Any(e => e.Id == id);
        }
    }
}
