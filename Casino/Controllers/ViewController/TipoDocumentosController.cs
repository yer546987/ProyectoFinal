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
    public class TipoDocumentosController : Controller
    {
        private readonly CasinoContext _context;

        public TipoDocumentosController(CasinoContext context)
        {
            _context = context;
        }

        // GET: TipoDocumentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDocumentos.ToListAsync());
        }

        // GET: TipoDocumentos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocumentos = await _context.TipoDocumentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDocumentos == null)
            {
                return NotFound();
            }

            return View(tipoDocumentos);
        }

        // GET: TipoDocumentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDocumentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoIdentificacion")] TipoDocumentos tipoDocumentos)
        {
            if (ModelState.IsValid)
            {
                tipoDocumentos.Id = Guid.NewGuid();
                _context.Add(tipoDocumentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDocumentos);
        }

        // GET: TipoDocumentos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocumentos = await _context.TipoDocumentos.FindAsync(id);
            if (tipoDocumentos == null)
            {
                return NotFound();
            }
            return View(tipoDocumentos);
        }

        // POST: TipoDocumentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TipoIdentificacion")] TipoDocumentos tipoDocumentos)
        {
            if (id != tipoDocumentos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDocumentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDocumentosExists(tipoDocumentos.Id))
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
            return View(tipoDocumentos);
        }

        // GET: TipoDocumentos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocumentos = await _context.TipoDocumentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDocumentos == null)
            {
                return NotFound();
            }

            return View(tipoDocumentos);
        }

        // POST: TipoDocumentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tipoDocumentos = await _context.TipoDocumentos.FindAsync(id);
            _context.TipoDocumentos.Remove(tipoDocumentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDocumentosExists(Guid id)
        {
            return _context.TipoDocumentos.Any(e => e.Id == id);
        }
    }
}
