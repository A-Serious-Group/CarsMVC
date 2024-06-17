using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            List<Carroceria> carrocerias = _context.Carrocerias.ToList();
            _logger.LogInformation($"Número de carrocerias recuperados: {carrocerias.Count}");
            return View(carrocerias);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
        }
    }
}
