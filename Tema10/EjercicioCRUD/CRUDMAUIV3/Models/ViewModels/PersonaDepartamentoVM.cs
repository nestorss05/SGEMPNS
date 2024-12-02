using CRUDMAUIV3.Views;
using Ejercicio1.ViewModels.Utilidades;
using EjercicioCRUD_BL;
using EjercicioCRUD_ENT;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CRUDMAUIV3.Models.ViewModels
{
    public class PersonaDepartamentoVM: INotifyPropertyChanged
    {

        #region atributos
        private ObservableCollection<PersonaListaDepartamentos> listadoPersonas;
        private PersonaListaDepartamentos personaSeleccionada;
        private DelegateCommand detallesCommand;
        private DelegateCommand aniadirCommand;
        private DelegateCommand editCommand;
        private DelegateCommand deleteCommand;
        #endregion

        #region propiedades
        public ObservableCollection<PersonaListaDepartamentos> ListadoPersonas
        { 
            get { return listadoPersonas; } 
            set 
            { 
                listadoPersonas = value; 
                NotifyPropertyChanged("ListadoPersonas"); 
            }
        }
        public PersonaListaDepartamentos PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set 
            { 
                personaSeleccionada = value;
                NotifyPropertyChanged("PersonaSeleccionada");
                detallesCommand.RaiseCanExecuteChanged();
                editCommand.RaiseCanExecuteChanged();
                deleteCommand.RaiseCanExecuteChanged();
            }
        }
        public DelegateCommand DetallesCommand
        {
            get
            {
                return detallesCommand;
            }
        }

        public DelegateCommand AniadirCommand
        {
            get
            {
                return aniadirCommand;
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
        public PersonaDepartamentoVM()
        {
            detallesCommand = new DelegateCommand(DetallesCommand_Executed, BotonesPer_CanExecute);
            aniadirCommand = new DelegateCommand(AniadirCommand_Executed);
            editCommand = new DelegateCommand(EditCommand_Executed, BotonesPer_CanExecute);
            deleteCommand = new DelegateCommand(DeleteCommand_Executed, BotonesPer_CanExecute);
            Refrescar();
        }
        #endregion

        #region Funciones

        /// <summary>
        /// Metodo que usa a la persona seleccionada como parametro y navega hacia la pagina de detalles
        /// </summary>
        /// <pre>La persona seleccionada debe ser valida</pre>
        /// <post>Nada</post>
        private async void DetallesCommand_Executed()
        {
            await App.Current.MainPage.Navigation.PushAsync(new Details(personaSeleccionada));
        }

        /// <summary>
        /// Metodo que navega hacia la pagina de creacion de persona
        /// </summary>
        /// <pre>Nada</pre>
        /// <post>Nada</post>
        private async void AniadirCommand_Executed()
        {
            await App.Current.MainPage.Navigation.PushAsync(new Create());
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

        /// <summary>
        /// Metodo que comprueba si los botones de Detalles, Editar y Eliminar pueden estar activados o no
        /// </summary>
        /// <pre>Nada</pre>
        /// <post>El metodo siempre devolvera un booleano</post>
        /// <returns>Variable booleana para activacion/desactivacion de los botones de Detalles, Editar y Eliminar</returns>
        private bool BotonesPer_CanExecute()
        {
            bool res = true;
            if (personaSeleccionada is null)
            {
                res = false;
            }
            return res;
        }

        public void Refrescar()
        {
            try
            {
                List<ClsDepartamento> departamentos = ClsListadoBL.ObtenerDepartamentosBL();
                List<ClsPersona> personas = ClsListadoBL.ObtenerPersonasBL();
                if (listadoPersonas.IsNullOrEmpty())
                {
                    listadoPersonas = new ObservableCollection<PersonaListaDepartamentos>();
                } 
                else
                {
                    listadoPersonas.Clear();
                }
                foreach (ClsPersona per in personas)
                {
                    listadoPersonas.Add(new PersonaListaDepartamentos(per));
                }
                NotifyPropertyChanged("ListadoPersonas");
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
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
