using EjercicioT8FinalBL;
using EjercicioT8FinalENT;

namespace EjercicioT8FinalVM
{
    /// <summary>
    /// Muestra los detalles de la mision
    /// </summary>
    public class ClsListadoVM: ClsMision
    {
        public List<ClsMision>? misiones
        {
            get
            {
                return ClsListadoBL.ObtenerMisiones();
            }
        }

        public ClsMision misionSeleccionada { get; set; }

        public ClsListadoVM() { }

        public ClsListadoVM(int idMision)
        {
            this.misionSeleccionada = ClsListadoBL.ObtenerMision(idMision);
        }
    }
}
