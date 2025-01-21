using Microsoft.AspNetCore.Mvc;
using Prueba2DAL;
using Prueba2DTOv4;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba2.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancionController : ControllerBase
    {
        // GET: api/<CancionController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<ClsCancion> listadoCompleto = new List<ClsCancion>();
            try
            {
                listadoCompleto = ClsListadoCancionesDAL.todoCanciones();
                if (listadoCompleto.Count == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    {
                        salida = Ok(listadoCompleto);
                    }
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // GET api/<CancionController>/5
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            IActionResult salida;
            ClsCancion? cancion = new ClsCancion();
            try
            {
                cancion = ClsListadoCancionesDAL.BuscarPorID(id);
                if (cancion != null)
                {
                    {
                        salida = Ok(cancion);
                    }
                }
                else
                {
                    salida = NoContent();
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // POST api/<CancionController>
        [HttpPost]
        public IActionResult Post([FromBody] ClsCancion can)
        {
            IActionResult salida;
            if (can != null)
            {
                try
                {
                    ClsListadoCancionesDAL.AgregarCancionDAL(can);
                    salida = Ok(can);
                }
                catch
                {
                    salida = BadRequest();
                }
            }
            else
            {
                salida = NoContent();
            }
            return salida;
        }

        // PUT api/<CancionController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClsCancion can)
        {
            int guardadoCorrectamente = 0;
            bool res = false;
            IActionResult salida;
            if (can != null)
            {
                try
                {
                    res = ClsListadoCancionesDAL.ModificarCancionDAL(can);
                    if (res)
                    {
                        guardadoCorrectamente = 1;
                    }
                    salida = Ok(guardadoCorrectamente);
                }
                catch
                {
                    salida = BadRequest();
                }
            }
            else
            {
                salida = NoContent();
            }
            return salida;
        }

        // DELETE api/<CancionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int guardadoCorrectamente = 0;
            bool res = false;
            IActionResult salida;
            ClsCancion? art = ClsListadoCancionesDAL.BuscarPorID(id);
            if (art != null)
            {
                try
                {
                    res = ClsListadoCancionesDAL.EliminarCancionDAL(id);
                    if (res)
                    {
                        guardadoCorrectamente = 1;
                    }
                    salida = Ok(guardadoCorrectamente);
                }
                catch
                {
                    salida = BadRequest();
                }
            }
            else
            {
                salida = NoContent();
            }
            return salida;
        }
    }
}
