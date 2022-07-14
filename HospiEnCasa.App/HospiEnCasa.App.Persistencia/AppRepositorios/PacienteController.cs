using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospiEnCasa.App.Models;
using HospiEnCasaMVC.Models;

namespace HospiEnCasa.App.Persistencia
{
    public class PacienteController : Controller
    {
        private readonly HospitalContext _context;

        public PacienteController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Paciente
        public async Task<IActionResult> Index()
        {
            var hospitalContext = _context.pacientes.Include(p => p.Enfermera).Include(p => p.FamiliarDesignado).Include(p => p.Historia).Include(p => p.Medico);
            return View(await hospitalContext.ToListAsync());
        }

        // GET: Paciente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.pacientes == null)
            {
                return NotFound();
            }

            var paciente = await _context.pacientes
                .Include(p => p.Enfermera)
                .Include(p => p.FamiliarDesignado)
                .Include(p => p.Historia)
                .Include(p => p.Medico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Paciente/Create
        public IActionResult Create()
        {
            ViewData["EnfermeraId"] = new SelectList(_context.enfermeras, "Id", "Apellidos");
            ViewData["FamiliarDesignadoId"] = new SelectList(_context.familiaresDesignados, "Id", "Apellidos");
            ViewData["HistoriaId"] = new SelectList(_context.historias, "Id", "Diagnostico");
            ViewData["MedicoId"] = new SelectList(_context.medicos, "Id", "Apellidos");
            return View();
        }

        // POST: Paciente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Direccion,Latitud,Longitud,Ciudad,FechaNacimiento,FamiliarDesignadoId,EnfermeraId,MedicoId,HistoriaId,Id,Nombre,Apellidos,NumeroTelefono,Genero")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnfermeraId"] = new SelectList(_context.enfermeras, "Id", "Apellidos", paciente.EnfermeraId);
            ViewData["FamiliarDesignadoId"] = new SelectList(_context.familiaresDesignados, "Id", "Apellidos", paciente.FamiliarDesignadoId);
            ViewData["HistoriaId"] = new SelectList(_context.historias, "Id", "Diagnostico", paciente.HistoriaId);
            ViewData["MedicoId"] = new SelectList(_context.medicos, "Id", "Apellidos", paciente.MedicoId);
            return View(paciente);
        }

        // GET: Paciente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.pacientes == null)
            {
                return NotFound();
            }

            var paciente = await _context.pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            ViewData["EnfermeraId"] = new SelectList(_context.enfermeras, "Id", "Apellidos", paciente.EnfermeraId);
            ViewData["FamiliarDesignadoId"] = new SelectList(_context.familiaresDesignados, "Id", "Apellidos", paciente.FamiliarDesignadoId);
            ViewData["HistoriaId"] = new SelectList(_context.historias, "Id", "Diagnostico", paciente.HistoriaId);
            ViewData["MedicoId"] = new SelectList(_context.medicos, "Id", "Apellidos", paciente.MedicoId);
            return View(paciente);
        }

        // POST: Paciente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Direccion,Latitud,Longitud,Ciudad,FechaNacimiento,FamiliarDesignadoId,EnfermeraId,MedicoId,HistoriaId,Id,Nombre,Apellidos,NumeroTelefono,Genero")] Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.Id))
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
            ViewData["EnfermeraId"] = new SelectList(_context.enfermeras, "Id", "Apellidos", paciente.EnfermeraId);
            ViewData["FamiliarDesignadoId"] = new SelectList(_context.familiaresDesignados, "Id", "Apellidos", paciente.FamiliarDesignadoId);
            ViewData["HistoriaId"] = new SelectList(_context.historias, "Id", "Diagnostico", paciente.HistoriaId);
            ViewData["MedicoId"] = new SelectList(_context.medicos, "Id", "Apellidos", paciente.MedicoId);
            return View(paciente);
        }

        // GET: Paciente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.pacientes == null)
            {
                return NotFound();
            }

            var paciente = await _context.pacientes
                .Include(p => p.Enfermera)
                .Include(p => p.FamiliarDesignado)
                .Include(p => p.Historia)
                .Include(p => p.Medico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.pacientes == null)
            {
                return Problem("Entity set 'HospitalContext.pacientes'  is null.");
            }
            var paciente = await _context.pacientes.FindAsync(id);
            if (paciente != null)
            {
                _context.pacientes.Remove(paciente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
          return (_context.pacientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
