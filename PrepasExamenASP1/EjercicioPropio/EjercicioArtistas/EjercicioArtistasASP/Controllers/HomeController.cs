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

        [HttpPost]
        public IActionResult Detalles(int idArtista)
        {
            ClsCancionesArtistaVM info = new ClsCancionesArtistaVM(idArtista);
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
