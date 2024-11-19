using EjercicioT8FinalBL;
using EjercicioT8FinalENT;

namespace EjercicioT8FinalUI.Models
{
    /// <summary>
    /// Muestra los detalles de la mision
    /// </summary>
    public class ClsListadoVM
    {
        public List<ClsMision>? misiones
        {
            get
            {
                return ClsListadoBL.ObtenerMisiones();
            }
        }

        public ClsMision misionSeleccionada { get; }

        public ClsListadoVM() { }

        public ClsListadoVM(int idMision)
        {
            this.misionSeleccionada = ClsListadoBL.ObtenerMision(idMision);
        }
    }
}
