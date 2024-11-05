using EjercicioT8Final.Models;
using EjercicioT8FinalBL;
using EjercicioT8FinalENT;
using EjercicioT8FinalVM;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            ClsListadoVM misiones = new ClsListadoVM(new List<ClsMision>(), new ClsMision());
            return View(misiones);
        }

        [HttpPost]
        public IActionResult Detalles(int id)
        {
            ClsListadoVM misiones = new ClsListadoVM(new List<ClsMision>(), new ClsMision(id, "", "", 0));
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
