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
    public class MovimientoCasinoController : ControllerBase
    {
        private readonly CasinoContext _context;

        public MovimientoCasinoController(CasinoContext context)
        {
            _context = context;
        }

        // GET: api/MovimientoCasinoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimientoCasino>>> GetMovimientoCasino()
        {
            return await _context.MovimientoCasino.ToListAsync();
        }

        // GET: api/MovimientoCasinoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovimientoCasino>> GetMovimientoCasino(int id)
        {
            var movimientoCasino = await _context.MovimientoCasino.FindAsync(id);

            if (movimientoCasino == null)
            {
                return NotFound();
            }

            return movimientoCasino;
        }

        // PUT: api/MovimientoCasinoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovimientoCasino(int id, MovimientoCasino movimientoCasino)
        {
            if (id != movimientoCasino.Id)
            {
                return BadRequest();
            }

            _context.Entry(movimientoCasino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimientoCasinoExists(id))
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

        // POST: api/MovimientoCasinoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MovimientoCasino>> PostMovimientoCasino(MovimientoCasino movimientoCasino)
        {
            _context.MovimientoCasino.Add(movimientoCasino);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovimientoCasino", new { id = movimientoCasino.Id }, movimientoCasino);
        }

        // DELETE: api/MovimientoCasinoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovimientoCasino>> DeleteMovimientoCasino(int id)
        {
            var movimientoCasino = await _context.MovimientoCasino.FindAsync(id);
            if (movimientoCasino == null)
            {
                return NotFound();
            }

            _context.MovimientoCasino.Remove(movimientoCasino);
            await _context.SaveChangesAsync();

            return movimientoCasino;
        }

        private bool MovimientoCasinoExists(int id)
        {
            return _context.MovimientoCasino.Any(e => e.Id == id);
        }
    }
}
