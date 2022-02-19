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
    public class FormacaoController : Controller
    {
        private readonly Conexao _context;

        public FormacaoController(Conexao context)
        {
            _context = context;
        }

        // GET: Formacao
        public async Task<IActionResult> Index()
        {
            return View(await _context.formacao.ToListAsync());
        }

        // GET: Formacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacao = await _context.formacao
                .FirstOrDefaultAsync(m => m.id == id);
            if (formacao == null)
            {
                return NotFound();
            }

            return View(formacao);
        }

        // GET: Formacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Formacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,titulo,nivel,instituicao,inicio,fim,imagemDiploma")] Formacao formacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formacao);
        }

        // GET: Formacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacao = await _context.formacao.FindAsync(id);
            if (formacao == null)
            {
                return NotFound();
            }
            return View(formacao);
        }

        // POST: Formacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,titulo,nivel,instituicao,inicio,fim,imagemDiploma")] Formacao formacao)
        {
            if (id != formacao.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormacaoExists(formacao.id))
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
            return View(formacao);
        }

        // GET: Formacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formacao = await _context.formacao
                .FirstOrDefaultAsync(m => m.id == id);
            if (formacao == null)
            {
                return NotFound();
            }

            return View(formacao);
        }

        // POST: Formacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formacao = await _context.formacao.FindAsync(id);
            _context.formacao.Remove(formacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormacaoExists(int id)
        {
            return _context.formacao.Any(e => e.id == id);
        }
    }
}
