using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarrosMVC.Data;
using CarrosMVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CarrosMVC.Controllers
{
    public class ModelosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModelosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Modelos
        public async Task<IActionResult> Index()
        {
            var modelos = await _context.Modelos.ToListAsync();
            return View(modelos);
        }

        // GET: Modelos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // GET: Modelos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modelos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // GET: Modelos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }
            return View(modelo);
        }

        // POST: Modelos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Modelo modelo)
        {
            if (id != modelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloExists(modelo.Id))
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
            return View(modelo);
        }

        // GET: Modelos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // POST: Modelos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modelo = await _context.Modelos.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }

            _context.Modelos.Remove(modelo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloExists(int id)
        {
            return _context.Modelos.Any(e => e.Id == id);
        }
    }
}
