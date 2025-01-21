using Prueba2DTOv4;

namespace Prueba2DAL
{
    public class ClsListadoArtistasDAL
    {

        private static List<ClsArtista> artistas = new List<ClsArtista>()
        {
            new ClsArtista(1, "Miguel", "Borrego", "Urban Z Music", "48596840F", new DateTime(2006, 02, 11), "Miami"),
            new ClsArtista(2, "Aurelio", "Boris", "Señor Terror", "24567873T", new DateTime(1994, 09, 22), "Benacazon"),
            new ClsArtista(3, "Carlos", "Salinas", "Papote Malote", "75343657B", new DateTime(1999, 11, 29), "Medellin"),
            new ClsArtista(4, "Carlitos", "LaHiena", "MC Revolver", "63456354R", new DateTime(2003, 08, 19), "Sevilla"),
            new ClsArtista(5, "Pablo", "Dominguez", "Su_Morenito_19", "54377456E", new DateTime(2005, 05, 26), "Los Alcores"),
            new ClsArtista(6, "Lucas", "Salas", "Lucas Skywalker", "75554772B", new DateTime(2006, 12, 01), "DLC de Torreblanca")
        };

        /// <summary>
        /// Devuelve un listado de artistas completo
        /// </summary>
        /// <pre>Nada</pre>
        /// <post>Siempre devuelve un listado de artistas completo</post>
        /// <returns>Listado de artistas completo</returns>
        public static List<ClsArtista> todoArtistas()
        {
            return artistas;
        }

        /// <summary>
        /// Metodo que busca un artista por su ID
        /// Pre: el ID del artista debe existir en la BD
        /// Post: si encuentra al artista, devolvera un objeto de la clase Artista. De lo contrario, devolvera null
        /// </summary>
        /// <param name="id">ID del artista</param>
        /// <returns>Artista encontrado</returns>
        public static ClsArtista? BuscarPorID(int id)
        {
            return artistas.FirstOrDefault(p => p.IdArtista == id);
        }

        /// <summary>
        /// Metodo que agrega un artista al listado
        /// Pre: El objeto Artista debe ser valido
        /// Post: nada
        /// </summary>
        /// <param name="art">Artista a agregar</param>
        public static void AgregarArtistaDAL(ClsArtista art)
        {
            artistas.Add(art);
        }

        /// <summary>
        /// Metodo que actualiza un artista de la lista
        /// Pre: El objeto Artista debe ser valido
        /// Post: siempre devuelve si la operacion se ha hecho correctamente o no
        /// </summary>
        /// <param name="art">Artista a modificar</param>
        /// <returns>Resultado de la operacion</returns>
        public static bool ModificarArtistaDAL(ClsArtista art)
        {
            bool res = false;
            ClsArtista? artFinal = BuscarPorID(art.IdArtista);
            if (artFinal != null)
            {
                artFinal.Nombre = art.Nombre;
                artFinal.Apellidos = art.Apellidos;
                artFinal.NombreArtistico = art.NombreArtistico;
                artFinal.DNI = art.DNI;
                artFinal.FechaNac = art.FechaNac;
                artFinal.Residencia = art.Residencia;
                res = true;
            }
            return res;
        }

        /// <summary>
        /// Metodo que elimina un artista de la lista
        /// Pre: nada
        /// Post: siempre devuelve si la operacion se ha hecho correctamente o no
        /// </summary>
        /// <param name="id">ID del artista a eliminar</param>
        /// <returns>Resultado de la operacion</returns>
        public static bool EliminarArtistaDAL(int id)
        {
            bool res = false;
            ClsArtista? artistaEncontrado = BuscarPorID(id);
            if (artistaEncontrado != null)
            {
                artistas.Remove(artistaEncontrado);
            }
            return res;
        }

    }
}
