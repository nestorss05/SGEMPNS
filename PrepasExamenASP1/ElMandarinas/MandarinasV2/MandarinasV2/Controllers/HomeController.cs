using System.Diagnostics;
using MandarinasV2.Models;
using Microsoft.AspNetCore.Mvc;

namespace MandarinasV2.Controllers
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
            ClsListadosVM misiones = new ClsListadosVM();
            return View(misiones);
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            ClsListadosVM misiones = new ClsListadosVM(id);
            return View(misiones);
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
