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
    public class GrupoEmpleadoController : ControllerBase
    {
        private readonly CasinoContext _context;

        public GrupoEmpleadoController(CasinoContext context)
        {
            _context = context;
        }

        // GET: api/GrupoEmpleadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoEmpleado>>> GetGrupoEmpleado()
        {
            return await _context.GrupoEmpleado.ToListAsync();
        }

        // GET: api/GrupoEmpleadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoEmpleado>> GetGrupoEmpleado(int id)
        {
            var grupoEmpleado = await _context.GrupoEmpleado.FindAsync(id);

            if (grupoEmpleado == null)
            {
                return NotFound();
            }

            return grupoEmpleado;
        }

        // PUT: api/GrupoEmpleadoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupoEmpleado(int id, GrupoEmpleado grupoEmpleado)
        {
            if (id != grupoEmpleado.Id)
            {
                return BadRequest();
            }

            _context.Entry(grupoEmpleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoEmpleadoExists(id))
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

        // POST: api/GrupoEmpleadoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GrupoEmpleado>> PostGrupoEmpleado(GrupoEmpleado grupoEmpleado)
        {
            _context.GrupoEmpleado.Add(grupoEmpleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrupoEmpleado", new { id = grupoEmpleado.Id }, grupoEmpleado);
        }

        // DELETE: api/GrupoEmpleadoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GrupoEmpleado>> DeleteGrupoEmpleado(int id)
        {
            var grupoEmpleado = await _context.GrupoEmpleado.FindAsync(id);
            if (grupoEmpleado == null)
            {
                return NotFound();
            }

            _context.GrupoEmpleado.Remove(grupoEmpleado);
            await _context.SaveChangesAsync();

            return grupoEmpleado;
        }

        private bool GrupoEmpleadoExists(int id)
        {
            return _context.GrupoEmpleado.Any(e => e.Id == id);
        }
    }
}
