using System.Diagnostics;
using EjercicioArtistasASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioArtistasASP.Controllers
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
            ClsCancionesArtistaVM info = new ClsCancionesArtistaVM();
            return View(info);
        }

        [HttpGet]
        public IActionResult Detalles(int id)
        {
            ClsCancionesArtistaVM info = new ClsCancionesArtistaVM(id);
            return View("Index", info);
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
