using Ejercicio4.Models.DAL;
using Ejercicio4.Models.ENT;
using Ejercicio4.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio4.Controllers
{
    public class Home : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditarPersona()
        {
            Random rnd = new Random();
            List<ClsPersona> personas = ClsListados.ObtenerPersonas();
            int numAleatorio = rnd.Next(personas.Count);
            ClsPersona oPersona = new ClsPersona(personas[numAleatorio]);
            ClsEditarPersonaVM personaEdit = new ClsEditarPersonaVM(oPersona);
            return View(personaEdit);
        }

    }
}
