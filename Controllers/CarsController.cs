using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarrosMVC.Models;

namespace CarrosMVC.Controllers;

public class CarsController : Controller
{
    private readonly ILogger<CarsController> _logger;

    public CarsController(ILogger<CarsController> logger)
    {
        _logger = logger;
    }

    public IActionResult Cars()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
