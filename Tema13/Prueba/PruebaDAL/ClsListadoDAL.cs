using PruebaDTO;
using System.Runtime.ConstrainedExecution;

namespace PruebaDAL
{
    public class ClsListadoDAL
    {

        private static List<ClsPersona> personas = new List<ClsPersona>()
        {
            new ClsPersona("1", "Hector", "Salamanca", "Ding ding guy"),
            new ClsPersona("2", "Tuco", "Salamanca", "Crazy guy"),
            new ClsPersona("3a", "Lalo", "Salamanca", "Saul guy"),
            new ClsPersona("4", "Leonel", "Salamanca", "Twin A guy"),
            new ClsPersona("5", "Marco", "Salamanca", "Twin B guy"),
            new ClsPersona("6", "Joaquin", "Salamanca", "Eladio guy")
        };

        /// <summary>
        /// Metodo que obtiene el listado de personas completo
        /// Pre: nada
        /// Post: siempre devuelve un listado de personas completo
        /// </summary>
        /// <returns>Listado de personas completo</returns>
        public static List<ClsPersona> ObtenerTodo()
        {
            return personas;
        }

        /// <summary>
        /// Metodo que busca a una persona mediante su ID
        /// Pre: id de la persona a buscar
        /// Post: puede devolver null o a la persona buscada
        /// </summary>
        /// <param name="id">ID de la persona a buscar</param>
        /// <returns>Persona encontrada</returns>
        public static ClsPersona? BuscarPorID(String id)
        {
            return personas.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Metodo que agrega una persona al listado
        /// Pre: nada
        /// Post: nada
        /// </summary>
        /// <param name="per">Persona a agregar</param>
        public static void AgregarPersonaDAL(ClsPersona per)
        {
            personas.Add(per);
        }

        /// <summary>
        /// Metodo que actualiza una persona de la lista
        /// Pre: nada
        /// Post: siempre devuelve si la operacion se ha hecho correctamente o no
        /// </summary>
        /// <param name="per">Persona a modificar</param>
        /// <returns>Resultado de la operacion</returns>
        public static bool ModificarPersonaDAL(ClsPersona per)
        {
            bool res = false;
            ClsPersona? perFinal = BuscarPorID(per.Id);
            if (perFinal != null) {
                perFinal.Nombre = per.Nombre;
                perFinal.Apellidos = per.Apellidos;
                perFinal.Descripcion = per.Descripcion;
                res = true;
            }
            return res;
        }

        /// <summary>
        /// Metodo que elimina una persona de la lista
        /// Pre: nada
        /// Post: siempre devuelve si la operacion se ha hecho correctamente o no
        /// </summary>
        /// <param name="id">ID de la persona a eliminar</param>
        /// <returns>Resultado de la operacion</returns>
        public static bool EliminarPersonaDAL(string id)
        {
            bool res = false;
            ClsPersona? perEncontrada = BuscarPorID(id);
            if (perEncontrada != null)
            {
                personas.Remove(perEncontrada);
            }
            return res;
        }

    }
}
