using Ejercicio1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1.Controllers
{
    public class Home : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Fecha = DateTime.Now;
            if (DateTime.Now.Hour >=21 || DateTime.Now.Hour < 6)
            {
                ViewData["Saludo"] = "Buenas noches";
            }
            else if (DateTime.Now.Hour >=13)
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
    }
}
