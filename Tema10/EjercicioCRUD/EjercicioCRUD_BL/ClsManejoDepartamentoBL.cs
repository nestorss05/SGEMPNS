using EjercicioCRUD_DAL;
using EjercicioCRUD_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCRUD_BL
{
    public class ClsManejoDepartamentoBL
    {
        /// <summary>
        /// Inserta un departamento en la BD y aplica restricciones a este
        /// </summary>
        /// <pre>El departamento creado debe ser valido</pre>
        /// <post>Puede devolver 0 o N dependiendo de la cantidad de filas afectadas</post>
        /// <param name="per">Departamento a añadir</param>
        /// <returns>Nº de filas afectadas</returns>
        public static int CrearDepartamentoBL(ClsDepartamento dep)
        {
            int numeroFilasAfectadas = ClsManejoDepartamentoDAL.CrearDepartamentoDAL(dep);
            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Edita un departamento de la BD y aplica restricciones a la edicion
        /// </summary>
        /// <pre>El departamento debe existir en la BD</pre>
        /// <post>Puede devolver 0 o N dependiendo de la cantidad de filas afectadas</post>
        /// <param name="per">Departamento a modificar</param>
        /// <returns>Nº de filas afectadas</returns>
        public static int EditarDepartamentoBL(ClsDepartamento dep)
        {
            int numeroFilasAfectadas = ClsManejoDepartamentoDAL.EditarDepartamentoDAL(dep);
            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Borra un departamento de la BD a base de su ID y aplica restricciones al borrado
        /// </summary>
        /// <pre>ID de un departamento existente en la BD</pre>
        /// <post>Puede devolver 0 o N dependiendo de la cantidad de filas afectadas</post>
        /// <param name="id">ID del departamento a eliminar</param>
        /// <returns>Nº de filas afectadas</returns>
        public static int BorrarDepartamentoBL(int id)
        {
            int numeroFilasAfectadas = ClsManejoDepartamentoDAL.BorrarDepartamentoDAL(id);
            return numeroFilasAfectadas;
        }
    }
}
