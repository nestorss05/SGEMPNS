using MandarinasDAL;
using MandarinasENT;

namespace MandarinasBL
{
    public class ClsListadosBL
    {
        /// <summary>
        /// Ofrece un listado completo de misiones
        /// </summary>
        /// <returns>Listado completo de misiones</returns>
        public static List<ClsMision>? ListadoMisionesBL()
        {
            List<ClsMision>? misiones = ClsListadosDAL.ListadoMisionesDAL(); ;
            if (DateTime.Now.Hour < 8)
            {
                misiones = null;
            }
            return misiones;
        }

        /// <summary>
        /// Ofrece los detalles de una mision seleccionada
        /// </summary>
        /// <param name="id">ID de una mision</param>
        /// <returns>Mision seleccionada</returns>
        public static ClsMision ObtenerMisionSeleccionadaBL(int id)
        {
            return ClsListadosDAL.ObtenerMisionSeleccionadaDAL(id);
        }
    }
}
