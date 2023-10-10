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
    public class GrupoEmpleadoController : Controller
    {
        private readonly CasinoContext _context;

        public GrupoEmpleadoController(CasinoContext context)
        {
            _context = context;
        }

        // GET: GrupoEmpleadoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GrupoEmpleado.ToListAsync());
        }

        // GET: GrupoEmpleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoEmpleado = await _context.GrupoEmpleado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupoEmpleado == null)
            {
                return NotFound();
            }

            return View(grupoEmpleado);
        }

        // GET: GrupoEmpleadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GrupoEmpleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreGrupo")] GrupoEmpleado grupoEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupoEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupoEmpleado);
        }

        // GET: GrupoEmpleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoEmpleado = await _context.GrupoEmpleado.FindAsync(id);
            if (grupoEmpleado == null)
            {
                return NotFound();
            }
            return View(grupoEmpleado);
        }

        // POST: GrupoEmpleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreGrupo")] GrupoEmpleado grupoEmpleado)
        {
            if (id != grupoEmpleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupoEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoEmpleadoExists(grupoEmpleado.Id))
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
            return View(grupoEmpleado);
        }

        // GET: GrupoEmpleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoEmpleado = await _context.GrupoEmpleado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupoEmpleado == null)
            {
                return NotFound();
            }

            return View(grupoEmpleado);
        }

        // POST: GrupoEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupoEmpleado = await _context.GrupoEmpleado.FindAsync(id);
            _context.GrupoEmpleado.Remove(grupoEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoEmpleadoExists(int id)
        {
            return _context.GrupoEmpleado.Any(e => e.Id == id);
        }
    }
}
