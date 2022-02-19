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
    public class AcessosController : Controller
    {
        private readonly Conexao _context;

        public AcessosController(Conexao context)
        {
            _context = context;
        }

        // GET: Acessos
        public async Task<IActionResult> Index()
        {
            return View(await _context.acesso.ToListAsync());
        }

        // GET: Acessos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessos = await _context.acesso
                .FirstOrDefaultAsync(m => m.id == id);
            if (acessos == null)
            {
                return NotFound();
            }

            return View(acessos);
        }

        // GET: Acessos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Acessos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,email,senha,imagem")] Acessos acessos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acessos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acessos);
        }

        // GET: Acessos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessos = await _context.acesso.FindAsync(id);
            if (acessos == null)
            {
                return NotFound();
            }
            return View(acessos);
        }

        // POST: Acessos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,email,senha,imagem")] Acessos acessos)
        {
            if (id != acessos.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acessos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcessosExists(acessos.id))
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
            return View(acessos);
        }

        // GET: Acessos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acessos = await _context.acesso
                .FirstOrDefaultAsync(m => m.id == id);
            if (acessos == null)
            {
                return NotFound();
            }

            return View(acessos);
        }

        // POST: Acessos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acessos = await _context.acesso.FindAsync(id);
            _context.acesso.Remove(acessos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcessosExists(int id)
        {
            return _context.acesso.Any(e => e.id == id);
        }
    }
}
