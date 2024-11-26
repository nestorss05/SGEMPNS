using Ejercicio1.ViewModels.Utilidades;
using EjercicioCRUD_BL;
using EjercicioCRUD_ENT;
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
        #endregion

        #region propiedades
        public List<PersonaListaDepartamentos> ListadoPersonas { get { return listadoPersonas; } }
        public PersonaListaDepartamentos PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set 
            { 
                personaSeleccionada = value;
                detallesCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("PersonaSeleccionada");
            }
        }
        public DelegateCommand DetallesCommand
        {
            get
            {
                return detallesCommand;
            }
        }
        #endregion

        #region constructores
        public PersonaDepartamentoVM()
        {
            try
            {
                personas = ClsListadoBL.ObtenerPersonasBL();
                listadoPersonas = new List<PersonaListaDepartamentos>();
                detallesCommand = new DelegateCommand(DetallesCommand_Executed, DetallesCommand_CanExecute);
                montarListado();
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }
        }
        #endregion

        #region Funciones

        /// <summary>
        /// 
        /// </summary>
        private async void DetallesCommand_Executed()
        {
            var navigationParameter = new ShellNavigationQueryParameters
            {
                { "PersonaSeleccionada", personaSeleccionada }
            };
            await Shell.Current.GoToAsync("//Details", navigationParameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
