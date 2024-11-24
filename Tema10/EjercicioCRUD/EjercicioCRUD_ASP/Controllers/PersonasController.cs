using EjercicioCRUD_ASP.Models;
using EjercicioCRUD_ASP.Models.ViewModels;
using EjercicioCRUD_BL;
using EjercicioCRUD_ENT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EjercicioCRUD_ASP.Controllers
{
    public class PersonasController : Controller
    {
        // GET: PersonasController
        public ActionResult Index()
        {
            List<PersonaDepartamentoVM> listaPersonasDpto = new List<PersonaDepartamentoVM>();
            List<ClsPersona> personas = ClsListadoBL.ObtenerPersonasBL();
            try
            {
                foreach (ClsPersona per in personas)
                {
                    PersonaDepartamentoVM personaDpto = new PersonaDepartamentoVM(per);
                    listaPersonasDpto.Add(personaDpto);
                }
            }
            catch (SqlException e)
            {
                return View("Error", new ErrorVM(new Exception("ERROR: no se ha podido acceder a la BD")));
            }
            catch (Exception e)
            {
                return View("Error", new ErrorVM(e));
            }
            return View(listaPersonasDpto);
        }

        // GET: PersonasController/Details/5
        public ActionResult Details(int id)
        {
            PersonaDepartamentoVM perDep = new PersonaDepartamentoVM();
            try
            {
                perDep = new PersonaDepartamentoVM(ClsManejoPersonaBL.BuscarPersonaBL(id));
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorVM(ex));
            }
            return View(perDep);
        }

        // GET: PersonasController/Create
        public ActionResult Create()
        {
            List<ClsDepartamento> departamentos = new List<ClsDepartamento>();
            try
            {
                departamentos = ClsListadoBL.ObtenerDepartamentosBL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(departamentos);
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClsPersona per)
        {
            List<ClsDepartamento> departamentos = new List<ClsDepartamento>();
            try
            {
                int res = ClsManejoPersonaBL.CrearPersonaBL(per);
                if (res != 1)
                {
                    return View("Error", new ErrorVM(new Exception("ERROR: No se ha podido añadir la persona")));
                }
            }
            catch (Exception e)
            {
                return View("Error", new ErrorVM(e));
            } finally
            {
                departamentos = ClsListadoBL.ObtenerDepartamentosBL();
            }
            return View(departamentos);
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            PersonaListaDepartamentos perDepts = new PersonaListaDepartamentos();
            try
            {
                perDepts = new PersonaListaDepartamentos(ClsManejoPersonaBL.BuscarPersonaBL(id));
            }
            catch (Exception e)
            {
                return View("Error", new ErrorVM(e));
            }
            return View(perDepts);
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClsPersona per)
        {
            try
            {
                int res = ClsManejoPersonaBL.EditarPersonaBL(per);
                if (res != 1)
                {
                    return View("Error", new ErrorVM(new Exception("ERROR: No se pudo modificar la persona")));
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View("Error", new ErrorVM(e));
            }
        }

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            ClsPersona per;
            try
            {
                per = ClsManejoPersonaBL.BuscarPersonaBL(id);
            }
            catch (Exception e) 
            {
                return View("Error", new ErrorVM(e));
            }
            return View(per);
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            try
            {
                int eliminado = ClsManejoPersonaBL.BorrarPersonaBL(id);
                if (eliminado != 1)
                {
                    return View("Error", new ErrorVM(new Exception("ERROR: No se ha podido eliminar la persona")));
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View("Error", new ErrorVM(e));
            }
        }
    }
}
