using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Casino.Data;
using Casino.Models.Parameters;

namespace Casino.Controllers.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoComidaController : ControllerBase
    {
        private readonly CasinoContext _context;

        public TipoComidaController(CasinoContext context)
        {
            _context = context;
        }

        // GET: api/TipoComida
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoComida>>> GetTipoComida()
        {
            return await _context.TipoComida.ToListAsync();
        }

        // GET: api/TipoComida/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoComida>> GetTipoComida(int id)
        {
            var tipoComida = await _context.TipoComida.FindAsync(id);

            if (tipoComida == null)
            {
                return NotFound();
            }

            return tipoComida;
        }

        // PUT: api/TipoComida/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoComida(int id, TipoComida tipoComida)
        {
            if (id != tipoComida.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoComida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoComidaExists(id))
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

        // POST: api/TipoComida
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoComida>> PostTipoComida(TipoComida tipoComida)
        {
            _context.TipoComida.Add(tipoComida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoComida", new { id = tipoComida.Id }, tipoComida);
        }

        // DELETE: api/TipoComida/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoComida>> DeleteTipoComida(int id)
        {
            var tipoComida = await _context.TipoComida.FindAsync(id);
            if (tipoComida == null)
            {
                return NotFound();
            }

            _context.TipoComida.Remove(tipoComida);
            await _context.SaveChangesAsync();

            return tipoComida;
        }

        private bool TipoComidaExists(int id)
        {
            return _context.TipoComida.Any(e => e.Id == id);
        }
    }
}
