using EjercicioCRUD_DAL;
using EjercicioCRUD_ENT;

namespace EjercicioCRUD_BL
{
    public class ClsListadoBL
    {
        /// <summary>
        /// Ofrece un listado de personas con las restricciones aplicadas
        /// </summary>
        /// <pre>Ninguna</pre>
        /// <post>Devuelve siempre una lista de personas</post>
        /// <returns>Listado de personas con restricciones</returns>
        public static List<ClsPersona> ObtenerPersonasBL()
        {
            List<ClsPersona> listadoPersonas = ClsListadoDAL.ObtenerPersonasDAL();
            return listadoPersonas;
        }

        /// <summary>
        /// Ofrece un listado de personas con las restricciones aplicadas
        /// </summary>
        /// <pre>Ninguna</pre>
        /// <post>Devuelve siempre una lista de departamentos</post>
        /// <returns>Listado de personas con restricciones</returns>
        public static List<ClsDepartamento> ObtenerDepartamentosBL()
        {
            List<ClsDepartamento> listadoDepartamentos = ClsListadoDAL.ObtenerDepartamentosDAL();
            return listadoDepartamentos;
        }
    }
}
