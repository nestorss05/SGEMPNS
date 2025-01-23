using Prueba2DAL;
using Prueba2DTOv4;

namespace Prueba2.Models
{
    public class ClsCancionConArtista: ClsCancion
    {
        public string NombreArtista { get; set; }

        public ClsCancionConArtista(ClsCancion can) {
            this.IdCancion = can.IdCancion;
            this.IdArtista = can.IdArtista;
            this.Nombre = can.Nombre;
            this.Duracion = can.Duracion;
            this.Genero = can.Genero;
            this.Año = can.Año;
            NombreArtista = buscarNombreArtista(can.IdArtista);
        }

        /// <summary>
        /// Metodo que devuelve el nombre de un artista de una lista de canciones a partir del ID del artista
        /// </summary>
        /// Pre: el ID siempre sera un numero entero
        /// Post: Si el ID es 0 o menor o no encuentra nada, devolvera una cadena vacia. De lo contrario, devolvera el nombre del artista.
        /// <param name="id">ID del artista</param>
        /// <returns>Nombre artistico del artista a base de su ID</returns>
        private string buscarNombreArtista(int id)
        {
            string res = "";
            ClsArtista? art = ClsListadoArtistasDAL.BuscarPorID(id);
            if (art != null)
            {
                res = art.NombreArtistico;
            }
            return res;
        }

    }
}
