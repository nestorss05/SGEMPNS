using Ejercicio2DAL;
using Ejercicio2ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2MAUI.ViewModels
{
    public class ClsListadoVM: INotifyPropertyChanged
    {

        #region Atributos
        private List<ClsPersona> listadoPersonas;
        private ClsPersona personaSeleccionada;
        #endregion

        #region Propiedades
        public List<ClsPersona> ListadoPersonas
        {
            get { return listadoPersonas; }
            set { listadoPersonas = value; NotifyPropertyChanged("ListadoPersonas"); }
        }
        public ClsPersona PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set { personaSeleccionada = value; NotifyPropertyChanged("PersonaSeleccionada"); }
        }
        #endregion

        #region Constructores
        public ClsListadoVM()
        {
            try
            {
                listadoPersonas = ClsListadoDAL.ObtenerPersonas();
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }
        }
        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        #endregion
    }
}
