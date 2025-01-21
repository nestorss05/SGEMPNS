using Microsoft.AspNetCore.Mvc;
using Prueba2DAL;
using Prueba2DTOv4;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba2.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistaController : ControllerBase
    {
        // GET: ArtistaController
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<ClsArtista> listadoCompleto = new List<ClsArtista>();
            try
            {
                listadoCompleto = ClsListadoArtistasDAL.todoArtistas();
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

        // GET: ArtistaController/Details/5
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            IActionResult salida;
            ClsArtista? artista = new ClsArtista();
            try
            {
                artista = ClsListadoArtistasDAL.BuscarPorID(id);
                if (artista != null)
                {
                    {
                        salida = Ok(artista);
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

        // POST: ArtistaController/Create
        [HttpPost]
        public IActionResult Post([FromBody] ClsArtista art)
        {
            IActionResult salida;
            if (art != null)
            {
                try
                {
                    ClsListadoArtistasDAL.AgregarArtistaDAL(art);
                    salida = Ok(art);
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

        // PUT: ArtistaController/Edit/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClsArtista art)
        {
            int guardadoCorrectamente = 0;
            bool res = false;
            IActionResult salida;
            if (art != null)
            {
                try
                {
                    res = ClsListadoArtistasDAL.ModificarArtistaDAL(art);
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

        // DELETE: ArtistaController/Delete/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int guardadoCorrectamente = 0;
            bool res = false;
            IActionResult salida;
            ClsArtista? art = ClsListadoArtistasDAL.BuscarPorID(id);
            if (art != null)
            {
                try
                {
                    res = ClsListadoArtistasDAL.EliminarArtistaDAL(id);
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
