using CRUDMAUIV3.Views;
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
    public class DetailsVM: INotifyPropertyChanged
    {

        #region Atributos
        private PersonaListaDepartamentos personaSeleccionada;
        private DelegateCommand volverCommand;
        private DelegateCommand editCommand;
        private DelegateCommand deleteCommand;
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
        public DelegateCommand EditCommand
        {
            get
            {
                return editCommand;
            }
        }

        public DelegateCommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
        }
        #endregion

        #region constructores
        public DetailsVM()
        {
            try
            {
                volverCommand = new DelegateCommand(VolverCommand_Executed);
                editCommand = new DelegateCommand(EditCommand_Executed);
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
            await App.Current.MainPage.Navigation.PopAsync();
        }
        /// <summary>
        /// Metodo que usa a la persona seleccionada como parametro y navega hacia la pagina de editado
        /// </summary>
        /// <pre>La persona seleccionada debe ser valida</pre>
        /// <post>Nada</post>
        private async void EditCommand_Executed()
        {
            await App.Current.MainPage.Navigation.PushAsync(new Edit(personaSeleccionada));
        }

        /// <summary>
        /// Metodo que usa a la persona seleccionada como parametro y navega hacia la pagina de borrado
        /// </summary>
        /// <pre>La persona seleccionada debe ser valida</pre>
        /// <post>Nada</post>
        private async void DeleteCommand_Executed()
        {
            await App.Current.MainPage.Navigation.PushAsync(new Delete(personaSeleccionada));
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
