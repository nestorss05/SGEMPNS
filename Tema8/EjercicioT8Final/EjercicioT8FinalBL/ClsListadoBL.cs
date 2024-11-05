using EjercicioT8FinalDAL;
using EjercicioT8FinalENT;

namespace EjercicioT8FinalBL
{
    /// <summary>
    /// Clase que llama a ClsListadoDAL y aplica restricciones
    /// </summary>
    public class ClsListadoBL
    {

        /// <summary>
        /// Ofrece un listado de misiones con las restricciones aplicadas
        /// </summary>
        /// <returns></returns>
        public static List<ClsMision>? ObtenerMisiones()
        {
            List<ClsMision>? misiones = ClsListadoDAL.ObtenerMisiones();
            if (DateTime.Now.Hour < 8)
            {
                misiones = null;
            }
            return misiones;
        }

        /// <summary>
        /// Ofrece una mision sacada de ClsListadoDAL
        /// </summary>
        /// <param name="id">ID de la mision</param>
        /// <returns>Mision con ID correspondiente</returns>
        public static ClsMision ObtenerMision(int id)
        {
            return ClsListadoDAL.ObtenerMision(id);
        }

    }
}
