using EjercicioCRUD_BL;
using EjercicioCRUD_ENT;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EjercicioCRUD_ASP.Controllers.API
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
                listadoCompleto = ClsListadoBL.ObtenerPersonasBL();
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
            } catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            ClsPersona? persona = new ClsPersona();
            try
            {
                persona = ClsManejoPersonaBL.BuscarPersonaBL(id);
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
            int guardadoCorrectamente = 0;
            IActionResult salida;
            if (per != null)
            {
                try
                {
                    guardadoCorrectamente = ClsManejoPersonaBL.CrearPersonaBL(per);
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

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClsPersona per)
        {
            int guardadoCorrectamente = 0;
            IActionResult salida;
            if (per != null)
            {
                try
                {
                    guardadoCorrectamente = ClsManejoPersonaBL.EditarPersonaBL(per);
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
        public IActionResult Delete(int id)
        {
            int guardadoCorrectamente = 0;
            IActionResult salida;
            ClsPersona? per = ClsManejoPersonaBL.BuscarPersonaBL(id);
            if (per != null)
            {
                try
                {
                    guardadoCorrectamente = ClsManejoPersonaBL.BorrarPersonaBL(id);
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
