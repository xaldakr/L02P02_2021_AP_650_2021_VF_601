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
    public class autoresController : Controller
    {
        private readonly LibreriaContexto _context;

        public autoresController(LibreriaContexto context)
        {
            _context = context;
        }

        // GET: autores
        public async Task<IActionResult> Index()
        {
            return View(await _context.autores.ToListAsync());
        }

        // GET: autores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autore = await _context.autores
                .FirstOrDefaultAsync(m => m.id == id);
            if (autore == null)
            {
                return NotFound();
            }

            return View(autore);
        }

        // GET: autores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: autores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,autor")] autore autore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autore);
        }

        // GET: autores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autore = await _context.autores.FindAsync(id);
            if (autore == null)
            {
                return NotFound();
            }
            return View(autore);
        }

        // POST: autores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,autor")] autore autore)
        {
            if (id != autore.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!autoreExists(autore.id))
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
            return View(autore);
        }

        // GET: autores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autore = await _context.autores
                .FirstOrDefaultAsync(m => m.id == id);
            if (autore == null)
            {
                return NotFound();
            }

            return View(autore);
        }

        // POST: autores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autore = await _context.autores.FindAsync(id);
            if (autore != null)
            {
                _context.autores.Remove(autore);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool autoreExists(int id)
        {
            return _context.autores.Any(e => e.id == id);
        }
    }
}
