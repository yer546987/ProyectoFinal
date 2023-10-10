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
    public class EmpleadoController : Controller
    {
        private readonly CasinoContext _context;

        public EmpleadoController(CasinoContext context)
        {
            _context = context;
        }

        // GET: Empleadoes
        public async Task<IActionResult> Index()
        {
            var casinoContext = _context.Empleado.Include(e => e.GrupoEmpleado).Include(e => e.TipoDocumentos).Include(e => e.TipoEmpleado);
            return View(await casinoContext.ToListAsync());
        }

        // GET: Empleadoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .Include(e => e.GrupoEmpleado)
                .Include(e => e.TipoDocumentos)
                .Include(e => e.TipoEmpleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleadoes/Create
        public IActionResult Create()
        {
            ViewData["IdGrupoEmpleado"] = new SelectList(_context.GrupoEmpleado, "Id", "Id");
            ViewData["IdTipoIdentificacion"] = new SelectList(_context.TipoDocumentos, "Id", "Id");
            ViewData["IdTipoEmpleado"] = new SelectList(_context.TipoEmpleado, "Id", "Id");
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Identification,IdTipoIdentificacion,IdTipoEmpleado,IdGrupoEmpleado,Interno")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                empleado.Id = Guid.NewGuid();
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGrupoEmpleado"] = new SelectList(_context.GrupoEmpleado, "Id", "Id", empleado.IdGrupoE);
            ViewData["IdTipoIdentificacion"] = new SelectList(_context.TipoDocumentos, "Id", "Id", empleado.IdTipoIdentificacion);
            ViewData["IdTipoEmpleado"] = new SelectList(_context.TipoEmpleado, "Id", "Id", empleado.IdTipoEmpleado);
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["IdGrupoEmpleado"] = new SelectList(_context.GrupoEmpleado, "Id", "Id", empleado.IdGrupoE);
            ViewData["IdTipoIdentificacion"] = new SelectList(_context.TipoDocumentos, "Id", "Id", empleado.IdTipoIdentificacion);
            ViewData["IdTipoEmpleado"] = new SelectList(_context.TipoEmpleado, "Id", "Id", empleado.IdTipoEmpleado);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nombre,Apellido,Identification,IdTipoIdentificacion,IdTipoEmpleado,IdGrupoEmpleado,Interno")] Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.Id))
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
            ViewData["IdGrupoEmpleado"] = new SelectList(_context.GrupoEmpleado, "Id", "Id", empleado.IdGrupoE);
            ViewData["IdTipoIdentificacion"] = new SelectList(_context.TipoDocumentos, "Id", "Id", empleado.IdTipoIdentificacion);
            ViewData["IdTipoEmpleado"] = new SelectList(_context.TipoEmpleado, "Id", "Id", empleado.IdTipoEmpleado);
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .Include(e => e.GrupoEmpleado)
                .Include(e => e.TipoDocumentos)
                .Include(e => e.TipoEmpleado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var empleado = await _context.Empleado.FindAsync(id);
            _context.Empleado.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(Guid id)
        {
            return _context.Empleado.Any(e => e.Id == id);
        }
    }
}
