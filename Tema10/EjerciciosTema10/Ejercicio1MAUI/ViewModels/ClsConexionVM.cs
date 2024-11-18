using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using Ejercicio1DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1MAUI.ViewModels
{
    public class ClsConexionVM : INotifyPropertyChanged
    {
        #region Atributos
        private String conexion;
        private DelegateCommand conectarCommand;
        #endregion

        #region Propiedades
        public String Conexion
        {
            get { return conexion; }
            set { conexion = value; NotifyPropertyChanged("Conexion"); }
        }
        public DelegateCommand ConectarCommand
        {
            get { return conectarCommand; }
        }
        #endregion

        #region Constructores
        public ClsConexionVM()
        {
            try
            {
                conectarCommand = new DelegateCommand(ConectarCommand_Executed);
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Guarda el estado de la conexion en el atributo conexion
        /// </summary>
        private void ConectarCommand_Executed()
        {
            Conexion = ClsConexionDAL.AbrirConexion();
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
