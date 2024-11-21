using MandarinasBL;
using MandarinasENT;

namespace MandarinasV2.Models
{
    public class ClsListadosVM
    {
        private List<ClsMision>? listadoMisiones;
        private ClsMision misionSeleccionada;
        public List<ClsMision>? ListadoMisiones { 
            get { return listadoMisiones; } 
        }
        public ClsMision MisionSeleccionada {
            get { return misionSeleccionada; } 
        }
        public ClsListadosVM() { 
            listadoMisiones = ClsListadosBL.ListadoMisionesBL(); 
        }

        public ClsListadosVM(int id)
        {
            listadoMisiones = ClsListadosBL.ListadoMisionesBL();
            misionSeleccionada = ClsListadosBL.ObtenerMisionSeleccionadaBL(id);
        }
    }
}
