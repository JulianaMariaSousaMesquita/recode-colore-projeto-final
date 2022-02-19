#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Colore.Models;

namespace Colore.Controllers
{
    public class RequisitosController : Controller
    {
        private readonly Conexao _context;

        public RequisitosController(Conexao context)
        {
            _context = context;
        }

        // GET: Requisitos
        public async Task<IActionResult> Index()
        {
            return View(await _context.requisitos.ToListAsync());
        }

        // GET: Requisitos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisitos = await _context.requisitos
                .FirstOrDefaultAsync(m => m.id == id);
            if (requisitos == null)
            {
                return NotFound();
            }

            return View(requisitos);
        }

        // GET: Requisitos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Requisitos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,escolaridade,experiencia,idiomas,area")] Requisitos requisitos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requisitos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requisitos);
        }

        // GET: Requisitos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisitos = await _context.requisitos.FindAsync(id);
            if (requisitos == null)
            {
                return NotFound();
            }
            return View(requisitos);
        }

        // POST: Requisitos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,escolaridade,experiencia,idiomas,area")] Requisitos requisitos)
        {
            if (id != requisitos.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requisitos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequisitosExists(requisitos.id))
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
            return View(requisitos);
        }

        // GET: Requisitos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisitos = await _context.requisitos
                .FirstOrDefaultAsync(m => m.id == id);
            if (requisitos == null)
            {
                return NotFound();
            }

            return View(requisitos);
        }

        // POST: Requisitos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requisitos = await _context.requisitos.FindAsync(id);
            _context.requisitos.Remove(requisitos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequisitosExists(int id)
        {
            return _context.requisitos.Any(e => e.id == id);
        }
    }
}
