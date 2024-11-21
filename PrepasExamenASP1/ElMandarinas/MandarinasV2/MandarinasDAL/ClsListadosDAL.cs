using MandarinasENT;

namespace MandarinasDAL
{
    public class ClsListadosDAL
    {
        /// <summary>
        /// Ofrece un listado completo de misiones
        /// </summary>
        /// <returns>Listado completo de misiones</returns>
        public static List<ClsMision> ListadoMisionesDAL()
        {
            return new List<ClsMision>()
            {
                new ClsMision(1, "Rescate de Baby Yoda", "Debes hacerte con Grogu y llevarselo a Luke SkyWalker para su entrenamiento.", 5000),
                new ClsMision(2, "Recuperar armadura Beskar", "Tu armadura de Beskar ha sido robada. Debes encontrarla.", 2000),
                new ClsMision(3, "Planeta Sorgon", "Debes llevar a un niño de vuelta a su planeta natal 'Sorgon'.", 500),
                new ClsMision(4, "Renacuajos", "Debes llevar a una Dama Rana y sus huevos de Tatooine a la luna del estuario Trask, donde su esposo fertilizara los huevos.", 500)
            };
        }

        /// <summary>
        /// Ofrece los detalles de una mision seleccionada
        /// </summary>
        /// <param name="id">ID de una mision</param>
        /// <returns>Mision seleccionada</returns>
        public static ClsMision ObtenerMisionSeleccionadaDAL(int id)
        {
            List<ClsMision> misiones = ListadoMisionesDAL();
            ClsMision mision = misiones.Find(x => x.Id == id);
            return mision;
        }
    }
}
