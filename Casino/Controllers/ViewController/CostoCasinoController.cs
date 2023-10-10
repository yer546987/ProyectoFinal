using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Casino.Data;
using Casino.Models.Parameters;

namespace Casino.Controllers.ViewController
{
    public class CostoCasinoController : Controller
    {
        private readonly CasinoContext _context;

        public CostoCasinoController(CasinoContext context)
        {
            _context = context;
        }

        // GET: CostoCasinoes
        public async Task<IActionResult> Index()
        {
            var casinoContext = _context.CostoCasino.Include(c => c.GrupoEmpleado).Include(c => c.TipoComida);
            return View(await casinoContext.ToListAsync());
        }

        // GET: CostoCasinoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costoCasino = await _context.CostoCasino
                .Include(c => c.GrupoEmpleado)
                .Include(c => c.TipoComida)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (costoCasino == null)
            {
                return NotFound();
            }

            return View(costoCasino);
        }

        // GET: CostoCasinoes/Create
        public IActionResult Create()
        {
            ViewData["IdGrupoEmpleado"] = new SelectList(_context.GrupoEmpleado, "Id", "Id");
            ViewData["IdTipoComida"] = new SelectList(_context.Set<TipoComida>(), "Id", "Id");
            return View();
        }

        // POST: CostoCasinoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Precio,IdTipoComida,IdGrupoEmpleado")] CostoCasino costoCasino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(costoCasino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGrupoEmpleado"] = new SelectList(_context.GrupoEmpleado, "Id", "Id", costoCasino.IdGrupoEmpleado);
            ViewData["IdTipoComida"] = new SelectList(_context.Set<TipoComida>(), "Id", "Id", costoCasino.IdTipoComida);
            return View(costoCasino);
        }

        // GET: CostoCasinoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costoCasino = await _context.CostoCasino.FindAsync(id);
            if (costoCasino == null)
            {
                return NotFound();
            }
            ViewData["IdGrupoEmpleado"] = new SelectList(_context.GrupoEmpleado, "Id", "Id", costoCasino.IdGrupoEmpleado);
            ViewData["IdTipoComida"] = new SelectList(_context.Set<TipoComida>(), "Id", "Id", costoCasino.IdTipoComida);
            return View(costoCasino);
        }

        // POST: CostoCasinoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Precio,IdTipoComida,IdGrupoEmpleado")] CostoCasino costoCasino)
        {
            if (id != costoCasino.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(costoCasino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostoCasinoExists(costoCasino.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGrupoEmpleado"] = new SelectList(_context.GrupoEmpleado, "Id", "Id", costoCasino.IdGrupoEmpleado);
            ViewData["IdTipoComida"] = new SelectList(_context.Set<TipoComida>(), "Id", "Id", costoCasino.IdTipoComida);
            return View(costoCasino);
        }

        // GET: CostoCasinoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costoCasino = await _context.CostoCasino
                .Include(c => c.GrupoEmpleado)
                .Include(c => c.TipoComida)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (costoCasino == null)
            {
                return NotFound();
            }

            return View(costoCasino);
        }

        // POST: CostoCasinoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var costoCasino = await _context.CostoCasino.FindAsync(id);
            _context.CostoCasino.Remove(costoCasino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CostoCasinoExists(int id)
        {
            return _context.CostoCasino.Any(e => e.Id == id);
        }
    }
}
