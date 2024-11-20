using EjercicioCRUD_DAL;
using EjercicioCRUD_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCRUD_BL
{
    public class ClsManejoPersonaBL
    {

        /// <summary>
        /// Inserta una persona en la BD y aplica restricciones a este
        /// </summary>
        /// <param name="per">Persona a añadir</param>
        /// <returns>Nº de filas afectadas</returns>
        public static int CrearPersonaBL(ClsPersona per)
        {
            int numeroFilasAfectadas = ClsManejoPersonaDAL.CrearPersonaDAL(per);
            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Edita una persona de la BD y aplica restricciones a la edicion
        /// </summary>
        /// <param name="per">Persona a modificar</param>
        /// <returns>Nº de filas afectadas</returns>
        public static int EditarPersonaBL(ClsPersona per)
        {
            int numeroFilasAfectadas = ClsManejoPersonaDAL.EditarPersonaDAL(per);
            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Borra una persona de la BD a base de su ID y aplica restricciones al borrado
        /// </summary>
        /// <param name="id">ID de la persona a eliminar</param>
        /// <returns>Nº de filas afectadas</returns>
        public static int BorrarPersonaBL(int id)
        {
            int numeroFilasAfectadas = ClsManejoPersonaDAL.BorrarPersonaDAL(id);
            return numeroFilasAfectadas;
        }

    }
}
