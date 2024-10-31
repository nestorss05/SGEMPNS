using Ejercicio5ASP.Models;
using Ejercicio5BL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicio5ASP.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View(clsListadosBL.listadoPersonasBL());
        }

    }
}
