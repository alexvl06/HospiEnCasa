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
    public class RepositorioEnfermera : Controller
    {
        private readonly HospitalContext _context;

        public RepositorioEnfermera(HospitalContext context)
        {
            _context = context;
        }

        // GET: Enfermera
        public async Task<IActionResult> Index()
        {
              return _context.enfermeras != null ? 
                          View(await _context.enfermeras.ToListAsync()) :
                          Problem("Entity set 'HospitalContext.enfermeras'  is null.");
        }

        // GET: Enfermera/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.enfermeras == null)
            {
                return NotFound();
            }

            var enfermera = await _context.enfermeras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enfermera == null)
            {
                return NotFound();
            }

            return View(enfermera);
        }

        // GET: Enfermera/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enfermera/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TarjetaProfesional,HorasLaborales,Id,Nombre,Apellidos,NumeroTelefono,Genero")] Enfermera enfermera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enfermera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enfermera);
        }

        // GET: Enfermera/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.enfermeras == null)
            {
                return NotFound();
            }

            var enfermera = await _context.enfermeras.FindAsync(id);
            if (enfermera == null)
            {
                return NotFound();
            }
            return View(enfermera);
        }

        // POST: Enfermera/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TarjetaProfesional,HorasLaborales,Id,Nombre,Apellidos,NumeroTelefono,Genero")] Enfermera enfermera)
        {
            if (id != enfermera.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enfermera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnfermeraExists(enfermera.Id))
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
            return View(enfermera);
        }

        // GET: Enfermera/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.enfermeras == null)
            {
                return NotFound();
            }

            var enfermera = await _context.enfermeras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enfermera == null)
            {
                return NotFound();
            }

            return View(enfermera);
        }

        // POST: Enfermera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.enfermeras == null)
            {
                return Problem("Entity set 'HospitalContext.enfermeras'  is null.");
            }
            var enfermera = await _context.enfermeras.FindAsync(id);
            if (enfermera != null)
            {
                _context.enfermeras.Remove(enfermera);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnfermeraExists(int id)
        {
          return (_context.enfermeras?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
