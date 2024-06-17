using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CarrosMVC.Models;

namespace CarrosMVC.Controllers
{
    public class BrandController : Controller
    {
        private readonly ILogger<BrandController> _logger;
        private readonly ApplicationDbContext _context;

        public BrandController(ILogger<BrandController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var marca = _context.Marcas.ToList();
            return View(marca);
        }

        // GET: BodyWork/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BodyWork/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome")] Marca marca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marca);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        // GET: BodyWork/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = _context.Marcas.Find(id);
            if (marca == null)
            {
                return NotFound();
            }
            return View(marca);
        }

        // POST: BodyWork/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nome")] Marca marca)
        {
            if (id != marca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marca);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaExists(marca.Id))
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
            return View(marca);
        }

        // GET: BodyWork/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = _context.Marcas.Find(id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // POST: BodyWork/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var marca = _context.Marcas.Find(id);
            if (marca == null)
            {
                return NotFound();
            }

            _context.Marcas.Remove(marca);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaExists(int id)
        {
            return _context.Marcas.Any(e => e.Id == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
        }
    }
}
