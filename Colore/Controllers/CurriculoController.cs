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
    public class CurriculoController : Controller
    {
        private readonly Conexao _context;

        public CurriculoController(Conexao context)
        {
            _context = context;
        }

        // GET: Curriculo
        public async Task<IActionResult> Index()
        {
            return View(await _context.curriculo.ToListAsync());
        }

        // GET: Curriculo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curriculo = await _context.curriculo
                .FirstOrDefaultAsync(m => m.id == id);
            if (curriculo == null)
            {
                return NotFound();
            }

            return View(curriculo);
        }

        // GET: Curriculo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Curriculo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,sobrenome,nomeSocial,telefone,cpf,rg,dataNasc")] Curriculo curriculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curriculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(curriculo);
        }

        // GET: Curriculo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curriculo = await _context.curriculo.FindAsync(id);
            if (curriculo == null)
            {
                return NotFound();
            }
            return View(curriculo);
        }

        // POST: Curriculo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,sobrenome,nomeSocial,telefone,cpf,rg,dataNasc")] Curriculo curriculo)
        {
            if (id != curriculo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curriculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurriculoExists(curriculo.id))
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
            return View(curriculo);
        }

        // GET: Curriculo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curriculo = await _context.curriculo
                .FirstOrDefaultAsync(m => m.id == id);
            if (curriculo == null)
            {
                return NotFound();
            }

            return View(curriculo);
        }

        // POST: Curriculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curriculo = await _context.curriculo.FindAsync(id);
            _context.curriculo.Remove(curriculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurriculoExists(int id)
        {
            return _context.curriculo.Any(e => e.id == id);
        }
    }
}
