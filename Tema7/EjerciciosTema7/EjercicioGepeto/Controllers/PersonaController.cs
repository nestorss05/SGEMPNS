using Microsoft.AspNetCore.Mvc;
using EjercicioGepeto.Models.ENT;
using EjercicioGepeto.Models.VM;
using System.Linq;
using EjercicioGepeto.Models.DAL; // Asegúrate de que este using esté presente


namespace EjercicioGepeto.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Edit(int id)
        {
            var persona = ClsListados.ObtenerPersonas().FirstOrDefault(p => p.IdDep == id);
            var model = new ClsEditarPersonaVM
            {
                Persona = persona
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ClsEditarPersonaVM model)
        {
            if (ModelState.IsValid)
            {
                // Aquí guardarías los cambios en la base de datos
                // Redirigir a otra acción o vista después de guardar
                return RedirectToAction("Index"); // Cambiar por la acción deseada
            }
            return View(model);
        }
    }
}
