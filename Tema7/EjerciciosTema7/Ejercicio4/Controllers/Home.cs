using Ejercicio4.Models.DAL;
using Ejercicio4.Models.ENT;
using Ejercicio4.Models.VM;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio4.Controllers
{
    public class Home : Controller
    {
        /// <summary>
        /// Pagina principal
        /// </summary>
        /// <returns>Vista de la pagina principal</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Pagina para editar persona
        /// </summary>
        /// <returns>Vista de edicion de persona</returns>
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
