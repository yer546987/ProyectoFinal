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
    public class CostoCasinoController : ControllerBase
    {
        private readonly CasinoContext _context;

        public CostoCasinoController(CasinoContext context)
        {
            _context = context;
        }

        // GET: api/CostoCasinoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CostoCasino>>> GetCostoCasino()
        {
            return await _context.CostoCasino.ToListAsync();
        }

        // GET: api/CostoCasinoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CostoCasino>> GetCostoCasino(int id)
        {
            var costoCasino = await _context.CostoCasino.FindAsync(id);

            if (costoCasino == null)
            {
                return NotFound();
            }

            return costoCasino;
        }

        // PUT: api/CostoCasinoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCostoCasino(int id, CostoCasino costoCasino)
        {
            if (id != costoCasino.Id)
            {
                return BadRequest();
            }

            _context.Entry(costoCasino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostoCasinoExists(id))
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

        // POST: api/CostoCasinoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CostoCasino>> PostCostoCasino(CostoCasino costoCasino)
        {
            _context.CostoCasino.Add(costoCasino);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCostoCasino", new { id = costoCasino.Id }, costoCasino);
        }

        // DELETE: api/CostoCasinoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CostoCasino>> DeleteCostoCasino(int id)
        {
            var costoCasino = await _context.CostoCasino.FindAsync(id);
            if (costoCasino == null)
            {
                return NotFound();
            }

            _context.CostoCasino.Remove(costoCasino);
            await _context.SaveChangesAsync();

            return costoCasino;
        }

        private bool CostoCasinoExists(int id)
        {
            return _context.CostoCasino.Any(e => e.Id == id);
        }
    }
}
