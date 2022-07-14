using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospiEnCasa.App.Dominio;
using HospiEnCasaMVC.Models;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioSugerenciaCuidado : Controller
    {
        private readonly HospitalContext _context;

        public SugerenciaCuidadoController(HospitalContext context)
        {
            _context = context;
        }

        // GET: SugerenciaCuidado
        public async Task<IActionResult> Index()
        {
              return _context.sugerenciasCuidados != null ? 
                          View(await _context.sugerenciasCuidados.ToListAsync()) :
                          Problem("Entity set 'HospitalContext.sugerenciasCuidados'  is null.");
        }

        // GET: SugerenciaCuidado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sugerenciasCuidados == null)
            {
                return NotFound();
            }

            var sugerenciaCuidado = await _context.sugerenciasCuidados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sugerenciaCuidado == null)
            {
                return NotFound();
            }

            return View(sugerenciaCuidado);
        }

        // GET: SugerenciaCuidado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SugerenciaCuidado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaHora,Descripcion")] SugerenciaCuidado sugerenciaCuidado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sugerenciaCuidado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sugerenciaCuidado);
        }

        // GET: SugerenciaCuidado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.sugerenciasCuidados == null)
            {
                return NotFound();
            }

            var sugerenciaCuidado = await _context.sugerenciasCuidados.FindAsync(id);
            if (sugerenciaCuidado == null)
            {
                return NotFound();
            }
            return View(sugerenciaCuidado);
        }

        // POST: SugerenciaCuidado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaHora,Descripcion")] SugerenciaCuidado sugerenciaCuidado)
        {
            if (id != sugerenciaCuidado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sugerenciaCuidado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SugerenciaCuidadoExists(sugerenciaCuidado.Id))
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
            return View(sugerenciaCuidado);
        }

        // GET: SugerenciaCuidado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sugerenciasCuidados == null)
            {
                return NotFound();
            }

            var sugerenciaCuidado = await _context.sugerenciasCuidados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sugerenciaCuidado == null)
            {
                return NotFound();
            }

            return View(sugerenciaCuidado);
        }

        // POST: SugerenciaCuidado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sugerenciasCuidados == null)
            {
                return Problem("Entity set 'HospitalContext.sugerenciasCuidados'  is null.");
            }
            var sugerenciaCuidado = await _context.sugerenciasCuidados.FindAsync(id);
            if (sugerenciaCuidado != null)
            {
                _context.sugerenciasCuidados.Remove(sugerenciaCuidado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SugerenciaCuidadoExists(int id)
        {
          return (_context.sugerenciasCuidados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
