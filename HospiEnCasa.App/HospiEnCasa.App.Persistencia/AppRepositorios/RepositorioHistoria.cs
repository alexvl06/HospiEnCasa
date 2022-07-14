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
    public class RepositorioHistoria : Controller
    {
        private readonly HospitalContext _context;

        public RepositorioHistoria(HospitalContext context)
        {
            _context = context;
        }

        // GET: Historia
        public async Task<IActionResult> Index()
        {
              return _context.historias != null ? 
                          View(await _context.historias.ToListAsync()) :
                          Problem("Entity set 'HospitalContext.historias'  is null.");
        }

        // GET: Historia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.historias == null)
            {
                return NotFound();
            }

            var historia = await _context.historias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historia == null)
            {
                return NotFound();
            }

            return View(historia);
        }

        // GET: Historia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Historia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Diagnostico,Entorno")] Historia historia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historia);
        }

        // GET: Historia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.historias == null)
            {
                return NotFound();
            }

            var historia = await _context.historias.FindAsync(id);
            if (historia == null)
            {
                return NotFound();
            }
            return View(historia);
        }

        // POST: Historia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Diagnostico,Entorno")] Historia historia)
        {
            if (id != historia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoriaExists(historia.Id))
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
            return View(historia);
        }

        // GET: Historia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.historias == null)
            {
                return NotFound();
            }

            var historia = await _context.historias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historia == null)
            {
                return NotFound();
            }

            return View(historia);
        }

        // POST: Historia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.historias == null)
            {
                return Problem("Entity set 'HospitalContext.historias'  is null.");
            }
            var historia = await _context.historias.FindAsync(id);
            if (historia != null)
            {
                _context.historias.Remove(historia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoriaExists(int id)
        {
          return (_context.historias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
