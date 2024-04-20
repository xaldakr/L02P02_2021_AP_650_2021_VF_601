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
    public class libroController : Controller
    {
        private readonly LibreriaContexto _context;

        public libroController(LibreriaContexto context)
        {
            _context = context;
        }

        // GET: libro
        public async Task<IActionResult> Index()
        {
            return View(await _context.libros.ToListAsync());
        }

        // GET: libro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.libros
                .FirstOrDefaultAsync(m => m.id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: libro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: libro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre,descripcion,url_imagen,id_autor,id_categoria,precio,estado")] libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // GET: libro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // POST: libro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,descripcion,url_imagen,id_autor,id_categoria,precio,estado")] libro libro)
        {
            if (id != libro.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!libroExists(libro.id))
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
            return View(libro);
        }

        // GET: libro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.libros
                .FirstOrDefaultAsync(m => m.id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: libro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.libros.FindAsync(id);
            if (libro != null)
            {
                _context.libros.Remove(libro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool libroExists(int id)
        {
            return _context.libros.Any(e => e.id == id);
        }
    }
}
