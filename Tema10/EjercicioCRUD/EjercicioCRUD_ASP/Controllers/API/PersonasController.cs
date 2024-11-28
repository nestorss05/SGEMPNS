using EjercicioCRUD_BL;
using EjercicioCRUD_ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EjercicioCRUD_ASP.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PersonasController>
        [HttpGet]
        public List<ClsPersona> Get()
        {
            return ClsListadoBL.ObtenerPersonasBL();
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public ClsPersona Get(int id)
        {
            return ClsManejoPersonaBL.BuscarPersonaBL(id);
        }

        // POST api/<PersonasController>
        [HttpPost]
        public void Post([FromBody] ClsPersona per)
        {
            ClsManejoPersonaBL.CrearPersonaBL(per);
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ClsPersona per)
        {
            ClsManejoPersonaBL.EditarPersonaBL(per);
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ClsManejoPersonaBL.BorrarPersonaBL(id);
        }
    }
}
