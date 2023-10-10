using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Casino.Data;
using CasinoApp.Models.Parameters;

namespace Casino.Controllers.ViewController
{
    public class IngredientesController : Controller
    {
        private readonly CasinoContext _context;

        public IngredientesController(CasinoContext context)
        {
            _context = context;
        }

        // GET: Ingredientes
        public async Task<IActionResult> Index()
        {
            var casinoContext = _context.Ingredientes.Include(i => i.UnidadMedida);
            return View(await casinoContext.ToListAsync());
        }

        // GET: Ingredientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredientes = await _context.Ingredientes
                .Include(i => i.UnidadMedida)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingredientes == null)
            {
                return NotFound();
            }

            return View(ingredientes);
        }

        // GET: Ingredientes/Create
        public IActionResult Create()
        {
            ViewData["IdUnidadPesaje"] = new SelectList(_context.Set<UnidadMedida>(), "Id", "Id");
            return View();
        }

        // POST: Ingredientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUnidadPesaje,Cantidad,IdInventario")] Ingredientes ingredientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUnidadPesaje"] = new SelectList(_context.Set<UnidadMedida>(), "Id", "Id", ingredientes.IdUnidadPesaje);
            return View(ingredientes);
        }

        // GET: Ingredientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredientes = await _context.Ingredientes.FindAsync(id);
            if (ingredientes == null)
            {
                return NotFound();
            }
            ViewData["IdUnidadPesaje"] = new SelectList(_context.Set<UnidadMedida>(), "Id", "Id", ingredientes.IdUnidadPesaje);
            return View(ingredientes);
        }

        // POST: Ingredientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUnidadPesaje,Cantidad,IdInventario")] Ingredientes ingredientes)
        {
            if (id != ingredientes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientesExists(ingredientes.Id))
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
            ViewData["IdUnidadPesaje"] = new SelectList(_context.Set<UnidadMedida>(), "Id", "Id", ingredientes.IdUnidadPesaje);
            return View(ingredientes);
        }

        // GET: Ingredientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredientes = await _context.Ingredientes
                .Include(i => i.UnidadMedida)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingredientes == null)
            {
                return NotFound();
            }

            return View(ingredientes);
        }

        // POST: Ingredientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredientes = await _context.Ingredientes.FindAsync(id);
            _context.Ingredientes.Remove(ingredientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientesExists(int id)
        {
            return _context.Ingredientes.Any(e => e.Id == id);
        }
    }
}
