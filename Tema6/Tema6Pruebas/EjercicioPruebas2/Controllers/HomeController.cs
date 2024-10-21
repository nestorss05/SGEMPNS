using EjercicioPruebas2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EjercicioPruebas2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public String Index()
        {
            return "Superbigote";
        }

        public String ElonMok()
        {
            return "Vamo a darno";
        }

        public int Numero()
        {
            return 53;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
