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
    public class TipoEmpleadoApiController : ControllerBase
    {
        private readonly CasinoContext _context;

        public TipoEmpleadoApiController(CasinoContext context)
        {
            _context = context;
        }

        // GET: api/TipoEmpleadoApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoEmpleado>>> GetTipoEmpleado()
        {
            return await _context.TipoEmpleado.ToListAsync();
        }

        // GET: api/TipoEmpleadoApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoEmpleado>> GetTipoEmpleado(int id)
        {
            var tipoEmpleado = await _context.TipoEmpleado.FindAsync(id);

            if (tipoEmpleado == null)
            {
                return NotFound();
            }

            return tipoEmpleado;
        }

        // PUT: api/TipoEmpleadoApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoEmpleado(int id, TipoEmpleado tipoEmpleado)
        {
            if (id != tipoEmpleado.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoEmpleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoEmpleadoExists(id))
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

        // POST: api/TipoEmpleadoApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoEmpleado>> PostTipoEmpleado(TipoEmpleado tipoEmpleado)
        {
            _context.TipoEmpleado.Add(tipoEmpleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoEmpleado", new { id = tipoEmpleado.Id }, tipoEmpleado);
        }

        // DELETE: api/TipoEmpleadoApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoEmpleado>> DeleteTipoEmpleado(int id)
        {
            var tipoEmpleado = await _context.TipoEmpleado.FindAsync(id);
            if (tipoEmpleado == null)
            {
                return NotFound();
            }

            _context.TipoEmpleado.Remove(tipoEmpleado);
            await _context.SaveChangesAsync();

            return tipoEmpleado;
        }

        private bool TipoEmpleadoExists(int id)
        {
            return _context.TipoEmpleado.Any(e => e.Id == id);
        }
    }
}
