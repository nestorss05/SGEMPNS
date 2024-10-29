using Ejercicio4.Models.ENT;
using Ejercicio4.Models.DAL;
namespace Ejercicio4.Models.VM
{
    public class ClsEditarPersonaVM:ClsPersona
    {

        #region parametros
        public List<ClsDepartamento> departamentos{ get; }
        #endregion

        /// <summary>
        /// Edita el ViewModel de la persona
        /// </summary>
        /// <param name="p"></param>
        public ClsEditarPersonaVM(ClsPersona p): base(p)
        {
            this.nombre = p.nombre;
            this.apellido = p.apellido;
            this.edad = p.edad;
            this.idDep = p.idDep;
            this.departamentos = ClsListados.ObtenerDepartamentos();
        }

    }
}
