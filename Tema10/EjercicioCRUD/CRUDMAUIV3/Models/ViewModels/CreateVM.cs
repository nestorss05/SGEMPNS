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
    public class CreateVM : INotifyPropertyChanged
    {
        #region Atributos
        private string nombre;
        private string apellidos;
        private string direccion;
        private string foto;
        private DateTime fechaNacimiento;
        private string telefono;
        private DelegateCommand volverCommand;
        private DelegateCommand createCommand;
        private ClsDepartamento depSeleccionado;
        private List<ClsDepartamento> departamentos;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; NotifyPropertyChanged("Nombre"); createCommand.RaiseCanExecuteChanged(); }
        }
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; NotifyPropertyChanged("Apellidos"); createCommand.RaiseCanExecuteChanged(); }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; NotifyPropertyChanged("Direccion"); createCommand.RaiseCanExecuteChanged(); }
        }
        public string Foto
        {
            get { return foto; }
            set { foto = value; NotifyPropertyChanged("Foto"); createCommand.RaiseCanExecuteChanged(); }
        }
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; NotifyPropertyChanged("FechaNacimiento"); createCommand.RaiseCanExecuteChanged(); }
        }
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; NotifyPropertyChanged("Telefono"); createCommand.RaiseCanExecuteChanged(); }
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
        public CreateVM()
        {
            try
            {
                fechaNacimiento = DateTime.Now;
                departamentos = ClsListadoBL.ObtenerDepartamentosBL();
                depSeleccionado = departamentos[0];
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
            ClsPersona per = new ClsPersona(nombre, apellidos, telefono, direccion, foto, fechaNacimiento, depSeleccionado.Id);
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
            bool res = true;
            if (nombre == null || apellidos == null || direccion == null || foto == null || telefono == null)
            {
                res = false;
            }
            return res;
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
