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
    [QueryProperty(nameof(PersonaSeleccionada), "PersonaSeleccionada")]
    public class EditVM : ClsPersona, INotifyPropertyChanged
    {

        #region Atributos
        private PersonaListaDepartamentos personaSeleccionada;
        private DelegateCommand editCommand;
        private DelegateCommand volverCommand;
        private ClsDepartamento depSeleccionado;
        private List<ClsDepartamento> departamentos;
        #endregion

        #region Propiedades
        public PersonaListaDepartamentos PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set { personaSeleccionada = value; NotifyPropertyChanged("PersonaSeleccionada"); }
        }
        public int Id
        {
            get { return base.Id; }
            set { base.Id = value; NotifyPropertyChanged("Id"); editCommand.RaiseCanExecuteChanged(); }
        }
        public string Nombre
        {
            get { return base.Nombre; }
            set { base.Nombre = value; NotifyPropertyChanged("Nombre"); editCommand.RaiseCanExecuteChanged(); }
        }
        public string Apellidos
        {
            get { return base.Apellidos; }
            set { base.Apellidos = value; NotifyPropertyChanged("Apellidos"); editCommand.RaiseCanExecuteChanged(); }
        }
        public string Direccion
        {
            get { return base.Direccion; }
            set { base.Direccion = value; NotifyPropertyChanged("Direccion"); editCommand.RaiseCanExecuteChanged(); }
        }
        public string Foto
        {
            get { return base.Foto; }
            set { base.Foto = value; NotifyPropertyChanged("Foto"); editCommand.RaiseCanExecuteChanged(); }
        }
        public DateTime FechaNacimiento
        {
            get { return base.FechaNacimiento; }
            set { base.FechaNacimiento = value; NotifyPropertyChanged("FechaNacimiento"); editCommand.RaiseCanExecuteChanged(); }
        }
        public string Telefono
        {
            get { return base.Telefono; }
            set { base.Telefono = value; NotifyPropertyChanged("Telefono"); editCommand.RaiseCanExecuteChanged(); }
        }
        public DateTime FechaActual
        {
            get { return DateTime.Now; }
        }
        public List<ClsDepartamento> Departamentos
        {
            get { return departamentos; }
        }
        public ClsDepartamento DepSeleccionado
        {
            get { return depSeleccionado; }
            set { depSeleccionado = value; NotifyPropertyChanged("DepSeleccionado"); }
        }
        public DelegateCommand EditCommand
        {
            get
            {
                return editCommand;
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
        public EditVM()
        {
            try
            {

                // TODO por algun motivo, el EditVM no funciona como deberia y PersonaSeleccionada es nulo

                base.Id = personaSeleccionada.Id;
                base.Nombre = personaSeleccionada.Nombre;
                base.Apellidos = personaSeleccionada.Apellidos;
                base.Direccion = personaSeleccionada.Direccion;
                base.Foto = personaSeleccionada.Foto;
                base.FechaNacimiento = personaSeleccionada.FechaNacimiento;
                base.Telefono = personaSeleccionada.Telefono;
                base.IdDepartamento = personaSeleccionada.IdDepartamento;

                departamentos = ClsListadoBL.ObtenerDepartamentosBL();
                depSeleccionado = ClsManejoDepartamentoBL.BuscarDepartamentoBL(personaSeleccionada.IdDepartamento);
                volverCommand = new DelegateCommand(VolverCommand_Executed);
                editCommand = new DelegateCommand(EditCommand_Executed, EditCommand_CanExecute);
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo del comando VolverCommand que va hacia MainPage
        /// <pre>Nada</pre>
        /// <post>Nada</post>
        /// </summary>
        private async void VolverCommand_Executed()
        {
            await Shell.Current.GoToAsync("//MainPage");
        }

        /// <summary>
        /// Metodo del comando CreateCommand para crear la persona y despues ir hacia MainPage
        /// <pre>Nada</pre>
        /// <post>Nada</post>
        /// </summary>
        private async void EditCommand_Executed()
        {
            ClsPersona per = new ClsPersona();
            per.Id = this.Id;
            per.Nombre = this.Nombre;
            per.Apellidos = this.Apellidos;
            per.Direccion = this.Direccion;
            per.Foto = this.Foto;
            per.FechaNacimiento = this.FechaNacimiento;
            per.Telefono = this.Telefono;
            per.IdDepartamento = this.IdDepartamento;
            int res = ClsManejoPersonaBL.EditarPersonaBL(per);
            if (res == 1)
            {
                await Application.Current.MainPage.DisplayAlert("Editado", "Persona editada satisfactoriamente", "Aceptar");
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Editado", "ERROR: Persona no editada", "Aceptar");
            }

        }

        /// <summary>
        /// Metodo que comprueba si el boton Editar se puede activar o no
        /// </summary>
        /// <pre>Nada</pre>
        /// <post>El metodo siempre devolvera un booleano</post>
        /// <returns>Booleana que habilita / deshabilita el boton de Editar</returns>
        private bool EditCommand_CanExecute()
        {
            return !string.IsNullOrWhiteSpace(this.Nombre) &&
               !string.IsNullOrWhiteSpace(this.Apellidos) &&
               !string.IsNullOrWhiteSpace(this.Direccion) &&
               !string.IsNullOrWhiteSpace(this.Foto) &&
               !string.IsNullOrWhiteSpace(this.Telefono);
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
