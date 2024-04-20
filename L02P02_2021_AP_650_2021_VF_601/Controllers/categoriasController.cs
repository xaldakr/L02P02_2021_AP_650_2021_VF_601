using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L02P02_2021_AP_650_2021_VF_601.Models;

namespace L02P02_2021_AP_650_2021_VF_601.Controllers
{
    public class categoriasController : Controller
    {
        private readonly LibreriaContexto _context;

        public categoriasController(LibreriaContexto context)
        {
            _context = context;
        }

        // GET: categorias
        public async Task<IActionResult> Index()
        {
            return View(await _context.categorias.ToListAsync());
        }

        // GET: categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categor = await _context.categorias
                .FirstOrDefaultAsync(m => m.id == id);
            if (categor == null)
            {
                return NotFound();
            }

            return View(categor);
        }

        // GET: categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,categoria")] categor categor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categor);
        }

        // GET: categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categor = await _context.categorias.FindAsync(id);
            if (categor == null)
            {
                return NotFound();
            }
            return View(categor);
        }

        // POST: categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,categoria")] categor categor)
        {
            if (id != categor.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!categorExists(categor.id))
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
            return View(categor);
        }

        // GET: categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categor = await _context.categorias
                .FirstOrDefaultAsync(m => m.id == id);
            if (categor == null)
            {
                return NotFound();
            }

            return View(categor);
        }

        // POST: categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categor = await _context.categorias.FindAsync(id);
            if (categor != null)
            {
                _context.categorias.Remove(categor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool categorExists(int id)
        {
            return _context.categorias.Any(e => e.id == id);
        }
    }
}
