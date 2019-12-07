using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChangeBook.Data;
using ChangeBook.Models;

namespace ChangeBook.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ChangeBookContext _context;

        public LivrosController(ChangeBookContext context)
        {
            _context = context;
        }

        // GET: Livros
        public async Task<IActionResult> Index()
        {
            var changeBookContext = _context.Livro.Include(l => l.Genero).Include(l => l.Usuario);
            return View(await changeBookContext.ToListAsync());
        }

        // GET: Livros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .Include(l => l.Genero)
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.LivroId == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livros/Create
        public IActionResult Create()
        {
            ViewData["GeneroId"] = new SelectList(_context.Genero, "GeneroId", "GeneroId");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId");
            return View();
        }

        // POST: Livros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LivroId,Nome_livro,Editora,Isbn,Autor,Data_compra,Edicao,Disponibilidade,UsuarioId,GeneroId")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GeneroId"] = new SelectList(_context.Genero, "GeneroId", "GeneroId", livro.GeneroId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", livro.UsuarioId);
            return View(livro);
        }

        // GET: Livros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            ViewData["GeneroId"] = new SelectList(_context.Genero, "GeneroId", "GeneroId", livro.GeneroId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", livro.UsuarioId);
            return View(livro);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LivroId,Nome_livro,Editora,Isbn,Autor,Data_compra,Edicao,Disponibilidade,UsuarioId,GeneroId")] Livro livro)
        {
            if (id != livro.LivroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.LivroId))
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
            ViewData["GeneroId"] = new SelectList(_context.Genero, "GeneroId", "GeneroId", livro.GeneroId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", livro.UsuarioId);
            return View(livro);
        }

        // GET: Livros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .Include(l => l.Genero)
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.LivroId == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _context.Livro.FindAsync(id);
            _context.Livro.Remove(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
            return _context.Livro.Any(e => e.LivroId == id);
        }
    }
}
