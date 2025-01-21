using Prueba2DTOv4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2DAL
{
    public class ClsListadoCancionesDAL
    {

        private static List<ClsCancion> canciones = new List<ClsCancion>()
        {
            new ClsCancion(1, 1, "Soy puter", "3:11", "Trap", 2023),
                new ClsCancion(2, 3, "Soy reggaeton", "3:21", "Reggaeton", 2023),
                new ClsCancion(3, 5, "Soy cani", "3:29", "Falso Pop", 2022),
                new ClsCancion(4, 3, "Colosio Colosal", "3:09", "Blues", 2014),
                new ClsCancion(5, 2, "Soy gotico", "2:20", "Gotico", 2012),
                new ClsCancion(6, 6, "Soy friki", "4:07", "Pop", 2024),
                new ClsCancion(7, 4, "Bandolero", "3:25", "Trap", 2022),
                new ClsCancion(8, 1, "Rap de Anuel", "2:46", "Rap", 2023),
                new ClsCancion(9, 2, "Gotica Q-Loona", "3:11", "Trap", 2019),
                new ClsCancion(10, 5, "Nadie conoce al Betis", "1:53", "Antibetis", 2017),
                new ClsCancion(11, 6, "Sociedad", "2:45", "Trap", 2023),
                new ClsCancion(12, 4, "Bandolero Remix", "2:58", "Reggaeton", 2024),
                new ClsCancion(13, 3, "Solidaridad", "2:02", "Pop", 2019),
                new ClsCancion(14, 6, "Nestle caca", "3:24", "Trap", 2023)
        };

        /// <summary>
        /// Devuelve un listado de todas las canciones de cada artista
        /// </summary>
        /// Pre: Ninguno
        /// Post: Siempre devolvera un listado de canciones de todos los artista
        /// <returns>Listado de canciones de todos los artistas</returns>
        public static List<ClsCancion> todoCanciones()
        {
            return canciones;
        }

        /// <summary>
        /// Metodo que busca una cancion por su ID
        /// Pre: el ID de la cancion debe existir en la BD
        /// Post: si encuentra a la cancion, devolvera un objeto de la clase Cancion. De lo contrario, devolvera null
        /// </summary>
        /// <param name="id">ID de la cancion</param>
        /// <returns>Cancion encontrada</returns>
        public static ClsCancion? BuscarPorID(int id)
        {
            return canciones.FirstOrDefault(p => p.IdCancion == id);
        }

        /// <summary>
        /// Metodo que agrega una Cancion al listado
        /// Pre: El objeto Cancion debe ser valido
        /// Post: nada
        /// </summary>
        /// <param name="can">Cancion a agregar</param>
        public static void AgregarCancionDAL(ClsCancion can)
        {
            canciones.Add(can);
        }

        /// <summary>
        /// Metodo que actualiza una cancion de la lista
        /// Pre: El objeto Cancion debe ser valido
        /// Post: siempre devuelve si la operacion se ha hecho correctamente o no
        /// </summary>
        /// <param name="can">Cancion a modificar</param>
        /// <returns>Resultado de la operacion</returns>
        public static bool ModificarCancionDAL(ClsCancion can)
        {
            bool res = false;
            ClsCancion? canFinal = BuscarPorID(can.IdCancion);
            if (canFinal != null)
            {
                canFinal.IdArtista = can.IdArtista;
                canFinal.Nombre = can.Nombre;
                canFinal.Duracion = can.Duracion;
                canFinal.Genero = can.Genero;
                canFinal.Año = can.Año;
                res = true;
            }
            return res;
        }

        /// <summary>
        /// Metodo que elimina una cancion de la lista
        /// Pre: nada
        /// Post: siempre devuelve si la operacion se ha hecho correctamente o no
        /// </summary>
        /// <param name="id">ID de la cancion a eliminar</param>
        /// <returns>Resultado de la operacion</returns>
        public static bool EliminarCancionDAL(int id)
        {
            bool res = false;
            ClsCancion? cancionEncontrada = BuscarPorID(id);
            if (cancionEncontrada != null)
            {
                canciones.Remove(cancionEncontrada);
            }
            return res;
        }

    }
}
