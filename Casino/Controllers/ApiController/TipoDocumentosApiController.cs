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
    public class TipoDocumentosApiController : ControllerBase
    {
        private readonly CasinoContext _context;

        public TipoDocumentosApiController(CasinoContext context)
        {
            _context = context;
        }

        // GET: api/TipoDocumentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDocumentos>>> GetTipoDocumentos()
        {
            return await _context.TipoDocumentos.ToListAsync();
        }

        // GET: api/TipoDocumentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDocumentos>> GetTipoDocumentos(Guid id)
        {
            var tipoDocumentos = await _context.TipoDocumentos.FindAsync(id);

            if (tipoDocumentos == null)
            {
                return NotFound();
            }

            return tipoDocumentos;
        }

        // PUT: api/TipoDocumentos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoDocumentos(Guid id, TipoDocumentos tipoDocumentos)
        {
            if (id != tipoDocumentos.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoDocumentos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDocumentosExists(id))
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

        // POST: api/TipoDocumentos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoDocumentos>> PostTipoDocumentos(TipoDocumentos tipoDocumentos)
        {
            _context.TipoDocumentos.Add(tipoDocumentos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoDocumentos", new { id = tipoDocumentos.Id }, tipoDocumentos);
        }

        // DELETE: api/TipoDocumentos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoDocumentos>> DeleteTipoDocumentos(Guid id)
        {
            var tipoDocumentos = await _context.TipoDocumentos.FindAsync(id);
            if (tipoDocumentos == null)
            {
                return NotFound();
            }

            _context.TipoDocumentos.Remove(tipoDocumentos);
            await _context.SaveChangesAsync();

            return tipoDocumentos;
        }

        private bool TipoDocumentosExists(Guid id)
        {
            return _context.TipoDocumentos.Any(e => e.Id == id);
        }
    }
}
