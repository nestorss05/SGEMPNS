using Ejercicio1.ViewModels.Utilidades;
using EjercicioCRUD_BL;
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
    public class DeleteVM : INotifyPropertyChanged
    {
        #region Atributos
        private PersonaListaDepartamentos personaSeleccionada;
        private DelegateCommand deleteCommand;
        private DelegateCommand volverCommand;
        #endregion

        #region Propiedades
        public PersonaListaDepartamentos PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set { personaSeleccionada = value; NotifyPropertyChanged("PersonaSeleccionada"); }
        }
        public DelegateCommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
        }
        public DelegateCommand VolverCommand
        {
            get
            {
                return volverCommand;
            }
        }
        #endregion

        #region Constructores
        public DeleteVM()
        {
            try
            {
                volverCommand = new DelegateCommand(VolverCommand_Executed);
                deleteCommand = new DelegateCommand(DeleteCommand_Executed);
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

        private async void DeleteCommand_Executed()
        {
            int res = ClsManejoPersonaBL.BorrarPersonaBL(personaSeleccionada.Id);
            if (res == 1)
            {
                await Application.Current.MainPage.DisplayAlert("Borrado", "Persona borrada satisfactoriamente", "Aceptar");
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Borrado", "ERROR: Persona no borrada", "Aceptar");
            }
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
