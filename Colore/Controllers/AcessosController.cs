#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Colore.Models;
using Acessos.Empresa;
using Acessos.Usuario;

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
        public async Task<IActionResult> CreateEmpresa([Bind("id,email,senha,imagem,titulo,telefone,cnpj,endereco")] Empresa acessos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acessos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acessos);
        }

        // POST: Acessos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUsuario([Bind("id,email,senha,imagem")] Usuario acessos)
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
        //***************************       Usuario           ***************************
        // GET: Usuario
        public async Task<IActionResult> Usuario()
        {
            return View(await _context.usuario.ToListAsync());
        }

        // GET: Acessos/DetailsUsuario/5
        public async Task<IActionResult> DetailsUsuario(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.usuario
                .FirstOrDefaultAsync(m => m.id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }


        // GET:  Acessos/EditUsuario/5
        public async Task<IActionResult> EditUsuario(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Acessos/EditUsuario/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUsuario(int id, [Bind("id,email,senha,imagem,curriculo")] Usuario usuario)
        {
            if (id != usuario.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Empresa));
            }
            return View(usuario);
        }

        // GET: Acessos/DeleteUsuario/5
        public async Task<IActionResult> DeleteUsuario(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.usuario
                .FirstOrDefaultAsync(m => m.id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Acessos/DeleteUsuario/5
        [HttpPost, ActionName("DeleteUsuario")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedUsuario(int id)
        {
            var usuario = await _context.usuario.FindAsync(id);
            _context.usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.usuario.Any(e => e.id == id);
        }



        //***************************       Empresa           ***************************
        // GET: Empresa
        public async Task<IActionResult> Empresa()
        {
            return View(await _context.empresa.ToListAsync());
        }

        // GET: Empresa/Details/5
        public async Task<IActionResult> DetailsEmpresa(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.empresa
                .FirstOrDefaultAsync(m => m.id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }


        // GET: Empresa/Edit/5
        public async Task<IActionResult> EditEmpresa(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.empresa.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }

        // POST: Empresa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEmpresa(int id, [Bind("id,email,senha,imagem,titulo,telefone,cnpj,endereco")] Empresa empresa)
        {
            if (id != empresa.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Empresa));
            }
            return View(empresa);
        }

        // GET: Acessos/DeleteEmpresa/5
        public async Task<IActionResult> DeleteEmpresa(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.empresa
                .FirstOrDefaultAsync(m => m.id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Acessos/DeleteEmpresa/5
        [HttpPost, ActionName("DeleteEmpresa")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedEmpresa(int id)
        {
            var empresa = await _context.empresa.FindAsync(id);
            _context.empresa.Remove(empresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaExists(int id)
        {
            return _context.empresa.Any(e => e.id == id);
        }
    }
}
