using Ejercicio2.Models;
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
        public IActionResult ListadoPersonas()
        {
            List<clsPersona> personas = new List<clsPersona>();
            personas.Add(new clsPersona(1, "Andrea", "Torres Rodríguez", new DateTime(1990, 03, 14), "Madrid, España", "+34 612 345 678"));
            personas.Add(new clsPersona(2, "Santiago", "Gómez Pérez", new DateTime(1985, 11, 22), "Buenos Aires, Argentina", "+54 11 1234 5678"));
            personas.Add(new clsPersona(3, "Valeria", "Ruiz Martínez", new DateTime(1998, 07, 05), "Bogotá, Colombia", "+57 310 765 4321"));
            personas.Add(new clsPersona(4, "Luis Fernando", "Silva López", new DateTime(1978, 01, 30), "Ciudad de México, México", "+52 55 9876 5432"));
            personas.Add(new clsPersona(5, "Carolina", "Jiménez Sánchez", new DateTime(1995, 09, 19), "Quito, Ecuador", "+593 2 345 6789"));
            personas.Add(new clsPersona(6, "Daniel", "Vargas Castillo", new DateTime(1983, 12, 08), "Santiago, Chile", "+56 9 8765 4321"));
            return View(personas);
        }

    }
}
