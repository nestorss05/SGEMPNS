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
    public class CreateVM : ClsPersona, INotifyPropertyChanged
    {
        #region Atributos
        private DelegateCommand volverCommand;
        private DelegateCommand createCommand;
        private ClsDepartamento depSeleccionado;
        private List<ClsDepartamento> departamentos;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return base.Nombre; }
            set { base.Nombre = value; NotifyPropertyChanged("Nombre"); createCommand.RaiseCanExecuteChanged(); }
        }
        public string Apellidos
        {
            get { return base.Apellidos; }
            set { base.Apellidos = value; NotifyPropertyChanged("Apellidos"); createCommand.RaiseCanExecuteChanged(); }
        }
        public string Direccion
        {
            get { return base.Direccion; }
            set { base.Direccion = value; NotifyPropertyChanged("Direccion"); createCommand.RaiseCanExecuteChanged(); }
        }
        public string Foto
        {
            get { return base.Foto; }
            set { base.Foto = value; NotifyPropertyChanged("Foto"); createCommand.RaiseCanExecuteChanged(); }
        }
        public DateTime FechaNacimiento
        {
            get { return base.FechaNacimiento; }
            set { base.FechaNacimiento = value; NotifyPropertyChanged("FechaNacimiento"); createCommand.RaiseCanExecuteChanged(); }
        }
        public string Telefono
        {
            get { return base.Telefono; }
            set { base.Telefono = value; NotifyPropertyChanged("Telefono"); createCommand.RaiseCanExecuteChanged(); }
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

        public DelegateCommand VolverCommand
        {
            get { return volverCommand; }
        }

        public DelegateCommand CreateCommand
        {
            get { return createCommand; }
        }
        #endregion

        #region constructores
        public CreateVM(): base()
        {
            try
            {
                base.FechaNacimiento = DateTime.Now;
                departamentos = ClsListadoBL.ObtenerDepartamentosBL();
                depSeleccionado = departamentos.FirstOrDefault();
                volverCommand = new DelegateCommand(VolverCommand_Executed);
                createCommand = new DelegateCommand(CreateCommand_Executed, CreateCommand_CanExecute);
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

        /// <summary>
        /// Metodo del comando CreateCommand para crear la persona y despues ir hacia MainPage
        /// <pre>Nada</pre>
        /// <post>Nada</post>
        /// </summary>
        private async void CreateCommand_Executed()
        {
            ClsPersona per = new ClsPersona(this.Nombre, this.Apellidos, this.Telefono, this.Direccion, this.Foto, this.FechaNacimiento, depSeleccionado.Id);
            int res = ClsManejoPersonaBL.CrearPersonaBL(per);
            if (res == 1)
            {
                await Application.Current.MainPage.DisplayAlert("Añadido", "Persona insertada", "Aceptar");
                await Shell.Current.GoToAsync("//MainPage");
            } else
            {
                await Application.Current.MainPage.DisplayAlert("Añadido", "ERROR: Persona no insertada", "Aceptar");
            }
            
        }

        /// <summary>
        /// Metodo que comprueba si el boton Crear se puede activar o no
        /// </summary>
        /// <pre>Nada</pre>
        /// <post>El metodo siempre devolvera un booleano</post>
        /// <returns>Booleana que habilita / deshabilita el boton de Crear</returns>
        private bool CreateCommand_CanExecute()
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
