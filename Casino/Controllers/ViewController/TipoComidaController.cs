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
    public class TipoComidaController : Controller
    {
        private readonly CasinoContext _context;

        public TipoComidaController(CasinoContext context)
        {
            _context = context;
        }

        // GET: TipoComida
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoComida.ToListAsync());
        }

        // GET: TipoComida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoComida = await _context.TipoComida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoComida == null)
            {
                return NotFound();
            }

            return View(tipoComida);
        }

        // GET: TipoComida/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoComida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Precio,Descripcion,TiempoInicial,TiempoFinal,Limite,Cronograma")] TipoComida tipoComida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoComida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoComida);
        }

        // GET: TipoComida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoComida = await _context.TipoComida.FindAsync(id);
            if (tipoComida == null)
            {
                return NotFound();
            }
            return View(tipoComida);
        }

        // POST: TipoComida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Precio,Descripcion,TiempoInicial,TiempoFinal,Limite,Cronograma")] TipoComida tipoComida)
        {
            if (id != tipoComida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoComida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoComidaExists(tipoComida.Id))
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
            return View(tipoComida);
        }

        // GET: TipoComida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoComida = await _context.TipoComida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoComida == null)
            {
                return NotFound();
            }

            return View(tipoComida);
        }

        // POST: TipoComida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoComida = await _context.TipoComida.FindAsync(id);
            _context.TipoComida.Remove(tipoComida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoComidaExists(int id)
        {
            return _context.TipoComida.Any(e => e.Id == id);
        }
    }
}
