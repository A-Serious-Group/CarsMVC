using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CarrosMVC.Models;

namespace CarrosMVC.Controllers
{
    public class BodyWorkController : Controller
    {
        private readonly ILogger<BodyWorkController> _logger;
        private readonly ApplicationDbContext _context;

        public BodyWorkController(ILogger<BodyWorkController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var carrocerias = _context.Carrocerias.ToList();
            _logger.LogInformation($"Número de carrocerias recuperados: {carrocerias.Count}");
            return View(carrocerias);
        }

        // GET: BodyWork/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BodyWork/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome")] Carroceria carroceria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carroceria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(carroceria);
        }

        // GET: BodyWork/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carroceria = _context.Carrocerias.Find(id);
            if (carroceria == null)
            {
                return NotFound();
            }
            return View(carroceria);
        }

        // POST: BodyWork/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nome")] Carroceria carroceria)
        {
            if (id != carroceria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carroceria);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroceriaExists(carroceria.Id))
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
            return View(carroceria);
        }

        // GET: BodyWork/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carroceria = _context.Carrocerias.Find(id);
            if (carroceria == null)
            {
                return NotFound();
            }

            return View(carroceria);
        }

        // POST: BodyWork/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var carroceria = _context.Carrocerias.Find(id);
            if (carroceria == null)
            {
                return NotFound();
            }

            _context.Carrocerias.Remove(carroceria);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroceriaExists(int id)
        {
            return _context.Carrocerias.Any(e => e.Id == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
        }
    }
}
