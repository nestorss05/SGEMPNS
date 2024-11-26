using Ejercicio1.ViewModels.Utilidades;
using EjercicioCRUD_BL;
using EjercicioCRUD_ENT;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
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
        private List<ClsPersona> personas;
        private List<PersonaListaDepartamentos> listadoPersonas;
        private PersonaListaDepartamentos personaSeleccionada;
        private DelegateCommand detallesCommand;
        private DelegateCommand aniadirCommand;
        #endregion

        #region propiedades
        public List<PersonaListaDepartamentos> ListadoPersonas
        { 
            get { return listadoPersonas; } 
            set { listadoPersonas = value; NotifyPropertyChanged("ListadoPersonas"); }
        }
        public PersonaListaDepartamentos PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set 
            { 
                personaSeleccionada = value;
                NotifyPropertyChanged("PersonaSeleccionada");
                detallesCommand.RaiseCanExecuteChanged();
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
        #endregion

        #region constructores
        public PersonaDepartamentoVM()
        {
            detallesCommand = new DelegateCommand(DetallesCommand_Executed, DetallesCommand_CanExecute);
            aniadirCommand = new DelegateCommand(AniadirCommand_Executed);
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
            var navigationParameter = new ShellNavigationQueryParameters
            {
                { "PersonaSeleccionada", personaSeleccionada }
            };
            await Shell.Current.GoToAsync("//Details", navigationParameter);
        }

        /// <summary>
        /// Metodo que navega hacia la pagina de creacion de persona
        /// </summary>
        /// <pre>Nada</pre>
        /// <post>Nada</post>
        private async void AniadirCommand_Executed()
        {
            await Shell.Current.GoToAsync("//Create");
        }

        /// <summary>
        /// Metodo que comprueba si el boton de Detalles puede estar activado o no
        /// </summary>
        /// <pre>Nada</pre>
        /// <post>El metodo siempre devolvera un booleano</post>
        /// <returns>Variable booleana para activacion/desactivacion del boton de Detalles</returns>
        private bool DetallesCommand_CanExecute()
        {
            bool res = true;
            if (personaSeleccionada is null)
            {
                res = false;
            }
            return res;
        }

        /// <summary>
        /// Monta el listado de personas final para mostrarlo por pantalla
        /// </summary>
        /// <pre>Ninguna</pre>
        /// <post>Ninguna</post>
        private void montarListado()
        {
            PersonaListaDepartamentos itemNuevo;
            foreach (ClsPersona per in personas)
            {
                itemNuevo = new PersonaListaDepartamentos(per);
                listadoPersonas.Add(itemNuevo);
            }
        }

        public void Refrescar()
        {
            try
            {
                personas = ClsListadoBL.ObtenerPersonasBL();
                if (listadoPersonas.IsNullOrEmpty())
                {
                    listadoPersonas = new List<PersonaListaDepartamentos>();
                } else
                {
                    listadoPersonas.Clear();
                }
                montarListado();
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
