using EjercicioT8FinalENT;

namespace EjercicioT8FinalDAL
{
    /// <summary>
    /// Clase donde se ofrecen listados
    /// </summary>
    public class ClsListadoDAL
    {
        /// <summary>
        /// Ofrece un listado completo de misiones
        /// </summary>
        /// <returns>Listado completo de misiones</returns>
        public static List<ClsMision>ObtenerMisiones()
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
        /// Ofrece una mision
        /// </summary>
        /// <param name="id">ID de la mision</param>
        /// <returns>Mision con ID correspondiente</returns>
        public static ClsMision ObtenerMision(int id)
        {
            List<ClsMision> misiones = ObtenerMisiones();
            ClsMision m = misiones.Find(ms => ms.id == id);
            return m;
        }

    }
}
