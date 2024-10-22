using Microsoft.AspNetCore.Mvc;

namespace Ejercicio4.Controllers
{
    public class Home : Controller
    {

        

        public IActionResult ClsEditarPersonaVM()
        {
            return View();
        }
    }
}
