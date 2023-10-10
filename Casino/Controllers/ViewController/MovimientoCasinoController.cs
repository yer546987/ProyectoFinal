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
    public class MovimientoCasinoController : Controller
    {
        private readonly CasinoContext _context;

        public MovimientoCasinoController(CasinoContext context)
        {
            _context = context;
        }

        // GET: MovimientoCasino
        public async Task<IActionResult> Index()
        {
            var casinoContext = _context.MovimientoCasino.Include(m => m.Empleado).Include(m => m.GrupoEmpleado).Include(m => m.TipoComida);
            return View(await casinoContext.ToListAsync());
        }

        // GET: MovimientoCasino/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientoCasino = await _context.MovimientoCasino
                .Include(m => m.Empleado)
                .Include(m => m.GrupoEmpleado)
                .Include(m => m.TipoComida)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimientoCasino == null)
            {
                return NotFound();
            }

            return View(movimientoCasino);
        }

        // GET: MovimientoCasino/Create
        public IActionResult Create()
        {
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "Id", "Id");
            ViewData["IdGrupoEmpleado"] = new SelectList(_context.GrupoEmpleado, "Id", "Id");
            ViewData["IdTipoComida"] = new SelectList(_context.TipoComida, "Id", "Id");
            return View();
        }

        // POST: MovimientoCasino/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Costo,IdTipoComida,IdGrupoEmpleado,IdEmpleado,HoraRegistro")] MovimientoCasino movimientoCasino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimientoCasino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "Id", "Id", movimientoCasino.IdEmpleado);
            ViewData["IdGrupoEmpleado"] = new SelectList(_context.GrupoEmpleado, "Id", "Id", movimientoCasino.IdGrupoEmpleado);
            ViewData["IdTipoComida"] = new SelectList(_context.TipoComida, "Id", "Id", movimientoCasino.IdTipoComida);
            return View(movimientoCasino);
        }

        // GET: MovimientoCasino/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientoCasino = await _context.MovimientoCasino.FindAsync(id);
            if (movimientoCasino == null)
            {
                return NotFound();
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "Id", "Id", movimientoCasino.IdEmpleado);
            ViewData["IdGrupoEmpleado"] = new SelectList(_context.GrupoEmpleado, "Id", "Id", movimientoCasino.IdGrupoEmpleado);
            ViewData["IdTipoComida"] = new SelectList(_context.TipoComida, "Id", "Id", movimientoCasino.IdTipoComida);
            return View(movimientoCasino);
        }

        // POST: MovimientoCasino/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Costo,IdTipoComida,IdGrupoEmpleado,IdEmpleado,HoraRegistro")] MovimientoCasino movimientoCasino)
        {
            if (id != movimientoCasino.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimientoCasino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientoCasinoExists(movimientoCasino.Id))
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
            ViewData["IdEmpleado"] = new SelectList(_context.Empleado, "Id", "Id", movimientoCasino.IdEmpleado);
            ViewData["IdGrupoEmpleado"] = new SelectList(_context.GrupoEmpleado, "Id", "Id", movimientoCasino.IdGrupoEmpleado);
            ViewData["IdTipoComida"] = new SelectList(_context.TipoComida, "Id", "Id", movimientoCasino.IdTipoComida);
            return View(movimientoCasino);
        }

        // GET: MovimientoCasino/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientoCasino = await _context.MovimientoCasino
                .Include(m => m.Empleado)
                .Include(m => m.GrupoEmpleado)
                .Include(m => m.TipoComida)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimientoCasino == null)
            {
                return NotFound();
            }

            return View(movimientoCasino);
        }

        // POST: MovimientoCasino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimientoCasino = await _context.MovimientoCasino.FindAsync(id);
            _context.MovimientoCasino.Remove(movimientoCasino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimientoCasinoExists(int id)
        {
            return _context.MovimientoCasino.Any(e => e.Id == id);
        }
    }
}
