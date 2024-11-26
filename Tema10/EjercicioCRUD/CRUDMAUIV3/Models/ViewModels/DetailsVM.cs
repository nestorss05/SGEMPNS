using Ejercicio1.ViewModels.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CRUDMAUIV3.Models.ViewModels
{
    [QueryProperty(nameof(PersonaSeleccionada), "PersonaSeleccionada")]
    public class DetailsVM: INotifyPropertyChanged
    {

        #region Atributos
        private PersonaListaDepartamentos personaSeleccionada;
        private DelegateCommand volverCommand;
        #endregion

        #region Propiedades
        public PersonaListaDepartamentos PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set { personaSeleccionada = value; NotifyPropertyChanged("PersonaSeleccionada"); }
        }
        public DelegateCommand VolverCommand
        {
            get
            {
                return volverCommand;
            }
        }
        #endregion

        #region constructores
        public DetailsVM()
        {
            try
            {
                volverCommand = new DelegateCommand(VolverCommand_Executed);
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }
        }

        #endregion

        #region metodos
        /// <summary>
        /// Metodo del comando VolverCommand que va hacia MainPage
        /// <pre>Nada</pre>
        /// <post>Nada</post>
        /// </summary>
        private async void VolverCommand_Executed()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        #endregion
    }
}
