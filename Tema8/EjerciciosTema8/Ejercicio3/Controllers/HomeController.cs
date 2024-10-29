using Ejercicio3.Models;
using Ejercicio3DAL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicio3.Controllers
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
            var persona = new ClsPersona { nombre = "", apellidos = "", edad = 0 };
            return View(persona);
        }

        [HttpPost]
        public ActionResult Editar(ClsPersona per)
        {
            return View("PersonaModificada", per);
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
