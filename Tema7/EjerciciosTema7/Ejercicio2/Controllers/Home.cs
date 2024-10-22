using Ejercicio2.Models;
using Ejercicio2.Models.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio2.Controllers
{
    public class Home : Controller
    {
        /// <summary>
        /// Pagina principal
        /// </summary>
        /// <returns>Hora, saludo, y mi persona</returns>
        public IActionResult Index()
        {
            ViewBag.Fecha = DateTime.Now;
            if (DateTime.Now.Hour >= 21 || DateTime.Now.Hour < 6)
            {
                ViewData["Saludo"] = "Buenas noches";
            }
            else if (DateTime.Now.Hour >= 13)
            {
                ViewData["Saludo"] = "Buenas tardes";
            }
            else
            {
                ViewData["Saludo"] = "Buenos dias";
            }
            clsPersona oPersona = new clsPersona();
            oPersona.idPersona = 1;
            oPersona.nombre = "Nestor";
            oPersona.apellidos = "Sanchez Sanchez";
            oPersona.fechaNac = new DateTime(2005, 11, 15);
            oPersona.direccion = "Donde yo me se";
            oPersona.telefono = "000000000";
            return View(oPersona);
        }

        /// <summary>
        /// Pagina de listado de personass
        /// </summary>
        /// <returns>Un listado de seis personas</returns>
        public IActionResult ListaPersonas()
        {
            try
            {
                List<clsPersona> personas = ClsListado.GetListado();
                return View(personas);
            } catch (Exception e)
            {
                return View();
            }
        }

    }
}
