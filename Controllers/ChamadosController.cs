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
    public class ChamadosController : Controller
    {
        private readonly ChangeBookContext _context;

        public ChamadosController(ChangeBookContext context)
        {
            _context = context;
        }

        // GET: Chamados
        public async Task<IActionResult> Index()
        {
            var changeBookContext = _context.Chamado.Include(c => c.Usuario);
            return View(await changeBookContext.ToListAsync());
        }

        // GET: Chamados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamado
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.ChamadoId == id);
            if (chamado == null)
            {
                return NotFound();
            }

            return View(chamado);
        }

        // GET: Chamados/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId");
            return View();
        }

        // POST: Chamados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChamadoId,Descricao,Login,UsuarioId")] Chamado chamado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chamado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", chamado.UsuarioId);
            return View(chamado);
        }

        // GET: Chamados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamado.FindAsync(id);
            if (chamado == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", chamado.UsuarioId);
            return View(chamado);
        }

        // POST: Chamados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChamadoId,Descricao,Login,UsuarioId")] Chamado chamado)
        {
            if (id != chamado.ChamadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chamado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChamadoExists(chamado.ChamadoId))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioId", chamado.UsuarioId);
            return View(chamado);
        }

        // GET: Chamados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamado = await _context.Chamado
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.ChamadoId == id);
            if (chamado == null)
            {
                return NotFound();
            }

            return View(chamado);
        }

        // POST: Chamados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chamado = await _context.Chamado.FindAsync(id);
            _context.Chamado.Remove(chamado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChamadoExists(int id)
        {
            return _context.Chamado.Any(e => e.ChamadoId == id);
        }
    }
}
