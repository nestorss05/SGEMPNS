﻿using EjercicioCRUD_BL;
using EjercicioCRUD_ENT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioCRUD_ASP.Controllers
{
    public class DepartamentosController : Controller
    {
        // GET: DepartamentosController
        public ActionResult Index()
        {
            List<ClsDepartamento> personas = ClsListadoBL.ObtenerDepartamentosBL();
            return View("Listado", personas);
        }

        // GET: DepartamentosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartamentosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartamentosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartamentosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartamentosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartamentosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartamentosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
