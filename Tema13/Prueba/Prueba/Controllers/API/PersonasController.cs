using Microsoft.AspNetCore.Mvc;
using PruebaDAL;
using PruebaDTO;
using System.Runtime.ConstrainedExecution;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PersonasController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<ClsPersona> listadoCompleto = new List<ClsPersona>();
            try
            {
                listadoCompleto = ClsListadoDAL.ObtenerTodo();
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

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(String id)
        {
            IActionResult salida;
            ClsPersona? persona = new ClsPersona();
            try
            {
                persona = ClsListadoDAL.BuscarPorID(id);
                if (persona != null)
                {
                    {
                        salida = Ok(persona);
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

        // POST api/<PersonasController>
        [HttpPost]
        public IActionResult Post([FromBody] ClsPersona per)
        {
            IActionResult salida;
            if (per != null)
            {
                try
                {
                    ClsListadoDAL.AgregarPersonaDAL(per);
                    salida = Ok(per);
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

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClsPersona per)
        {
            int guardadoCorrectamente = 0;
            bool res = false;
            IActionResult salida;
            if (per != null)
            {
                try
                {
                    res = ClsListadoDAL.ModificarPersonaDAL(per);
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

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(String id)
        {
            int guardadoCorrectamente = 0;
            bool res = false;
            IActionResult salida;
            ClsPersona? per = ClsListadoDAL.BuscarPorID(id);
            if (per != null)
            {
                try
                {
                    res = ClsListadoDAL.EliminarPersonaDAL(id);
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
