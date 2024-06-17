using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarrosMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarrosMVC.Controllers
{
    public class CarsController : Controller
    {
        private readonly ILogger<CarsController> _logger;
        private readonly ApplicationDbContext _context;

        public CarsController(ILogger<CarsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Cars
        public IActionResult Index()
        {
            var carros = _context.Carros.Include(c => c.Marca).Include(c => c.Carroceria).ToList();
            return View(carros);
        }

        // GET: Cars/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = _context.Carros
                .Include(c => c.Marca)
                .Include(c => c.Carroceria)
                .FirstOrDefault(c => c.Id == id);

            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewBag.MarcaId = new SelectList(_context.Marcas, "Id", "Nome");
            ViewBag.CarroceriaId = new SelectList(_context.Carrocerias, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome,MarcaId,CarroceriaId")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                carro.Marca = null;
                carro.Carroceria = null;
                _context.Add(carro);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MarcaId = new SelectList(_context.Marcas, "Id", "Nome", carro.MarcaId);
            ViewBag.CarroceriaId = new SelectList(_context.Carrocerias, "Id", "Nome", carro.CarroceriaId);
            return View(carro);
        }

        // GET: Cars/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = _context.Carros.Find(id);
            if (carro == null)
            {
                return NotFound();
            }

            ViewBag.MarcaId = new SelectList(_context.Marcas, "Id", "Nome", carro.MarcaId);
            ViewBag.CarroceriaId = new SelectList(_context.Carrocerias, "Id", "Nome", carro.CarroceriaId);
            return View(carro);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nome,MarcaId,CarroceriaId")] Carro carro)
        {
            if (id != carro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carro);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(carro.Id))
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
            ViewBag.MarcaId = new SelectList(_context.Marcas, "Id", "Nome", carro.MarcaId);
            ViewBag.CarroceriaId = new SelectList(_context.Carrocerias, "Id", "Nome", carro.CarroceriaId);
            return View(carro);
        }

        // GET: Cars/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = _context.Carros
                .Include(c => c.Marca)
                .Include(c => c.Carroceria)
                .FirstOrDefault(c => c.Id == id);

            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // POST: BodyWork/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var carro = _context.Carros.Find(id);
            if (carro == null)
            {
                return NotFound();
            }

            _context.Carros.Remove(carro);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(int id)
        {
            return _context.Carros.Any(e => e.Id == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
