using EjercicioT8FinalBL;
using EjercicioT8FinalENT;

namespace EjercicioT8FinalVM
{
    /// <summary>
    /// Muestra los detalles de la mision
    /// </summary>
    public class ClsListadoVM:ClsMision
    {

        public List<ClsMision>? misiones { get; }

        public ClsMision misionSeleccionada { get; }

        public ClsListadoVM(List<ClsMision>? misiones, ClsMision misionSeleccionada)
        {
            this.misiones = ClsListadoBL.ObtenerMisiones();
            if (misionSeleccionada != null)
            {
                this.misionSeleccionada = ClsListadoBL.ObtenerMision(misionSeleccionada.id);
            }
        }

    }
}
