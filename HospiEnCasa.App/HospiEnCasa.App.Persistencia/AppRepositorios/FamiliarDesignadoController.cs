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
    public class RepositorioFamiliarDesignado : Controller
    {
        private readonly HospitalContext _context;

        public RepositorioFamiliarDesignado(HospitalContext context)
        {
            _context = context;
        }

        // GET: FamiliarDesignado
        public async Task<IActionResult> Index()
        {
              return _context.familiaresDesignados != null ? 
                          View(await _context.familiaresDesignados.ToListAsync()) :
                          Problem("Entity set 'HospitalContext.familiaresDesignados'  is null.");
        }

        // GET: FamiliarDesignado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.familiaresDesignados == null)
            {
                return NotFound();
            }

            var familiarDesignado = await _context.familiaresDesignados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familiarDesignado == null)
            {
                return NotFound();
            }

            return View(familiarDesignado);
        }

        // GET: FamiliarDesignado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FamiliarDesignado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Parentesco,Correo,Id,Nombre,Apellidos,NumeroTelefono,Genero")] FamiliarDesignado familiarDesignado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(familiarDesignado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(familiarDesignado);
        }

        // GET: FamiliarDesignado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.familiaresDesignados == null)
            {
                return NotFound();
            }

            var familiarDesignado = await _context.familiaresDesignados.FindAsync(id);
            if (familiarDesignado == null)
            {
                return NotFound();
            }
            return View(familiarDesignado);
        }

        // POST: FamiliarDesignado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Parentesco,Correo,Id,Nombre,Apellidos,NumeroTelefono,Genero")] FamiliarDesignado familiarDesignado)
        {
            if (id != familiarDesignado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(familiarDesignado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliarDesignadoExists(familiarDesignado.Id))
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
            return View(familiarDesignado);
        }

        // GET: FamiliarDesignado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.familiaresDesignados == null)
            {
                return NotFound();
            }

            var familiarDesignado = await _context.familiaresDesignados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familiarDesignado == null)
            {
                return NotFound();
            }

            return View(familiarDesignado);
        }

        // POST: FamiliarDesignado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.familiaresDesignados == null)
            {
                return Problem("Entity set 'HospitalContext.familiaresDesignados'  is null.");
            }
            var familiarDesignado = await _context.familiaresDesignados.FindAsync(id);
            if (familiarDesignado != null)
            {
                _context.familiaresDesignados.Remove(familiarDesignado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamiliarDesignadoExists(int id)
        {
          return (_context.familiaresDesignados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
