using Microsoft.AspNetCore.Mvc;
using EjercicioGepeto.Models.DAL;

namespace EjercicioGepeto.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var personas = ClsListados.ObtenerPersonas();
            return View(personas);
        }
    }
}
