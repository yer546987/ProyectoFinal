using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Casino.Data;
using Casino.Models.Parameters;
using CasinoApp.Models.Parameters;

namespace Casino.Controllers.ViewController
{
    public class InventarioController : Controller
    {
        private readonly CasinoContext _context;

        public InventarioController(CasinoContext context)
        {
            _context = context;
        }

        // GET: Inventario
        public async Task<IActionResult> Index()
        {
            var casinoContext = _context.Inventario.Include(i => i.Inventarios).Include(i => i.UnidadMedidas);
            return View(await casinoContext.ToListAsync());
        }

        // GET: Inventario/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario
                .Include(i => i.Inventarios)
                .Include(i => i.UnidadMedidas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // GET: Inventario/Create
        public IActionResult Create()
        {
            ViewData["IdInventario"] = new SelectList(_context.Inventario, "Id", "Id");
            ViewData["IdUnidadMedida"] = new SelectList(_context.Set<UnidadMedida>(), "Id", "Id");
            return View();
        }

        // POST: Inventario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Producto,FechaVencimiento,Stock,IdUnidadMedida,Cantidad,IdInventario")] Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                inventario.Id = Guid.NewGuid();
                _context.Add(inventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdInventario"] = new SelectList(_context.Inventario, "Id", "Id", inventario.IdInventario);
            ViewData["IdUnidadMedida"] = new SelectList(_context.Set<UnidadMedida>(), "Id", "Id", inventario.IdUnidadMedida);
            return View(inventario);
        }

        // GET: Inventario/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }
            ViewData["IdInventario"] = new SelectList(_context.Inventario, "Id", "Id", inventario.IdInventario);
            ViewData["IdUnidadMedida"] = new SelectList(_context.Set<UnidadMedida>(), "Id", "Id", inventario.IdUnidadMedida);
            return View(inventario);
        }

        // POST: Inventario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Producto,FechaVencimiento,Stock,IdUnidadMedida,Cantidad,IdInventario")] Inventario inventario)
        {
            if (id != inventario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioExists(inventario.Id))
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
            ViewData["IdInventario"] = new SelectList(_context.Inventario, "Id", "Id", inventario.IdInventario);
            ViewData["IdUnidadMedida"] = new SelectList(_context.Set<UnidadMedida>(), "Id", "Id", inventario.IdUnidadMedida);
            return View(inventario);
        }

        // GET: Inventario/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario
                .Include(i => i.Inventarios)
                .Include(i => i.UnidadMedidas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // POST: Inventario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var inventario = await _context.Inventario.FindAsync(id);
            _context.Inventario.Remove(inventario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioExists(Guid id)
        {
            return _context.Inventario.Any(e => e.Id == id);
        }
    }
}
