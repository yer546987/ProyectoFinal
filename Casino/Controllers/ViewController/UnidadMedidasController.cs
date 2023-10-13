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
    public class UnidadMedidasController : Controller
    {
        private readonly CasinoContext _context;

        public UnidadMedidasController(CasinoContext context)
        {
            _context = context;
        }

        // GET: UnidadMedidas
        public async Task<IActionResult> Index()
        {
            return View(await _context.UnidadMedida.ToListAsync());
        }

        // GET: UnidadMedidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadMedida = await _context.UnidadMedida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidadMedida == null)
            {
                return NotFound();
            }

            return View(unidadMedida);
        }

        // GET: UnidadMedidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnidadMedidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] UnidadMedida unidadMedida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadMedida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidadMedida);
        }

        // GET: UnidadMedidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadMedida = await _context.UnidadMedida.FindAsync(id);
            if (unidadMedida == null)
            {
                return NotFound();
            }
            return View(unidadMedida);
        }

        // POST: UnidadMedidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] UnidadMedida unidadMedida)
        {
            if (id != unidadMedida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadMedida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadMedidaExists(unidadMedida.Id))
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
            return View(unidadMedida);
        }

        // GET: UnidadMedidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadMedida = await _context.UnidadMedida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidadMedida == null)
            {
                return NotFound();
            }

            return View(unidadMedida);
        }

        // POST: UnidadMedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidadMedida = await _context.UnidadMedida.FindAsync(id);
            _context.UnidadMedida.Remove(unidadMedida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadMedidaExists(int id)
        {
            return _context.UnidadMedida.Any(e => e.Id == id);
        }
    }
}
