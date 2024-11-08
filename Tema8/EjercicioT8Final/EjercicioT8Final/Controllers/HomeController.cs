using EjercicioT8Final.Models;
using EjercicioT8FinalENT;
using EjercicioT8Final;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EjercicioT8FinalUI.Models;

namespace EjercicioT8Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ClsListadoVM misiones = new ClsListadoVM();
            return View(misiones);
        }

        [HttpPost]
        public IActionResult Detalles(int id)
        {
            ClsListadoVM misiones = new ClsListadoVM(id);
            return View("Index", misiones);
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
