using EjercicioT8FinalBL;
using EjercicioT8FinalENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioT8FinalMAUI.ViewModels
{
    /// <summary>
    /// Muestra los detalles de la mision
    /// </summary>
    public class ClsListadoVM : INotifyPropertyChanged
    {
        private List<ClsMision> _misiones;
        private ClsMision _misionSeleccionada;
        private Boolean _visibleForm = true;
        private Boolean _visibleError = false;

        public Boolean VisibleError
        {
            get { return _visibleError; }
        }

        public Boolean VisiblePicker
        {
            get { return !_visibleError; }
        }

        public List<ClsMision>? Misiones
        {
            get
            {
                List<ClsMision>? ms = ClsListadoBL.ObtenerMisiones();
                if (ms == null)
                {
                    _visibleForm = false;
                    _visibleError = true;
                    NotifyPropertyChanged("VisibleError");
                    NotifyPropertyChanged("VisiblePicker");
                }
                return ClsListadoBL.ObtenerMisiones();
            }
        }

        public ClsMision MisionSeleccionada 
        { 
            get { return _misionSeleccionada; }
            set { _misionSeleccionada = value; NotifyPropertyChanged("MisionSeleccionada"); }
        }

        public ClsListadoVM() { }

        public ClsListadoVM(int idMision)
        {
            this._misionSeleccionada = ClsListadoBL.ObtenerMision(idMision);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

    }
}
