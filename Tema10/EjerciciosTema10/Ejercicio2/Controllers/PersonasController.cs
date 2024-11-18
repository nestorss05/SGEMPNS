using Ejercicio2DAL;
using Ejercicio2ENT;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio2.Controllers
{
    public class PersonasController : Controller
    {
        public IActionResult Listado()
        {
            List<ClsPersona> listado = ClsListadoDAL.ObtenerPersonas();
            return View(listado);
        }
    }
}
