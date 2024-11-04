using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinefilosplus.Models;

namespace Cinefilosplus.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly MyDbContext _context;

        public PeliculasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Peliculas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Peliculas.ToListAsync());
        }

        // GET: Peliculas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinefilosplus = await _context.Peliculas
                .FirstOrDefaultAsync(m => m.idpeliculas == id);
            if (cinefilosplus == null)
            {
                return NotFound();
            }

            return View(cinefilosplus);
        }

        // GET: Peliculas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Peliculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idpeliculas,Titulo,Director,Sinopsis,Duracion,Clasificacion,Genero")] Cinefilosplus cinefilosplus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cinefilosplus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cinefilosplus);
        }

        // GET: Peliculas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinefilosplus = await _context.Peliculas.FindAsync(id);
            if (cinefilosplus == null)
            {
                return NotFound();
            }
            return View(cinefilosplus);
        }

        // POST: Peliculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idpeliculas,Titulo,Director,Sinopsis,Duracion,Clasificacion,Genero")] Cinefilosplus cinefilosplus)
        {
            if (id != cinefilosplus.idpeliculas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cinefilosplus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CinefilosplusExists(cinefilosplus.idpeliculas))
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
            return View(cinefilosplus);
        }

        // GET: Peliculas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinefilosplus = await _context.Peliculas
                .FirstOrDefaultAsync(m => m.idpeliculas == id);
            if (cinefilosplus == null)
            {
                return NotFound();
            }

            return View(cinefilosplus);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinefilosplus = await _context.Peliculas.FindAsync(id);
            if (cinefilosplus != null)
            {
                _context.Peliculas.Remove(cinefilosplus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CinefilosplusExists(int id)
        {
            return _context.Peliculas.Any(e => e.idpeliculas == id);
        }
    }
}
