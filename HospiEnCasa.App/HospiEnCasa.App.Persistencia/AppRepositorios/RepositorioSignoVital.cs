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
    public class RepositorioSignoVital : Controller
    {
        private readonly HospitalContext _context;

        public RepositorioSignoVital(HospitalContext context)
        {
            _context = context;
        }

        // GET: SignoVital
        public async Task<IActionResult> Index()
        {
            var hospitalContext = _context.signosVitales.Include(s => s.paciente);
            return View(await hospitalContext.ToListAsync());
        }

        // GET: SignoVital/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.signosVitales == null)
            {
                return NotFound();
            }

            var signoVital = await _context.signosVitales
                .Include(s => s.paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signoVital == null)
            {
                return NotFound();
            }

            return View(signoVital);
        }

        // GET: SignoVital/Create
        public IActionResult Create()
        {
            ViewData["pacienteId"] = new SelectList(_context.pacientes, "Id", "Apellidos");
            return View();
        }

        // POST: SignoVital/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaHora,Valor,Signo,pacienteId")] SignoVital signoVital)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signoVital);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["pacienteId"] = new SelectList(_context.pacientes, "Id", "Apellidos", signoVital.pacienteId);
            return View(signoVital);
        }

        // GET: SignoVital/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.signosVitales == null)
            {
                return NotFound();
            }

            var signoVital = await _context.signosVitales.FindAsync(id);
            if (signoVital == null)
            {
                return NotFound();
            }
            ViewData["pacienteId"] = new SelectList(_context.pacientes, "Id", "Apellidos", signoVital.pacienteId);
            return View(signoVital);
        }

        // POST: SignoVital/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaHora,Valor,Signo,pacienteId")] SignoVital signoVital)
        {
            if (id != signoVital.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signoVital);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignoVitalExists(signoVital.Id))
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
            ViewData["pacienteId"] = new SelectList(_context.pacientes, "Id", "Apellidos", signoVital.pacienteId);
            return View(signoVital);
        }

        // GET: SignoVital/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.signosVitales == null)
            {
                return NotFound();
            }

            var signoVital = await _context.signosVitales
                .Include(s => s.paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (signoVital == null)
            {
                return NotFound();
            }

            return View(signoVital);
        }

        // POST: SignoVital/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.signosVitales == null)
            {
                return Problem("Entity set 'HospitalContext.signosVitales'  is null.");
            }
            var signoVital = await _context.signosVitales.FindAsync(id);
            if (signoVital != null)
            {
                _context.signosVitales.Remove(signoVital);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignoVitalExists(int id)
        {
          return (_context.signosVitales?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
