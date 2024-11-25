using EjercicioCRUD_BL;
using EjercicioCRUD_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDMAUIV3.Models
{
    public class PersonaListaDepartamentos: ClsPersona
    {
        private string nombreDepartamento;
        public string NombreDepartamento { get { return nombreDepartamento; } }

        public PersonaListaDepartamentos(ClsPersona per)
        {
            this.Id = per.Id;
            this.Nombre = per.Nombre;
            this.Apellidos = per.Apellidos;
            this.Telefono = per.Telefono;
            this.Direccion = per.Direccion;
            this.Foto = per.Foto;
            this.FechaNacimiento = per.FechaNacimiento;
            this.IdDepartamento = per.IdDepartamento;
            nombreDepartamento = buscarNombreDep(per.IdDepartamento);
        }

        /// <summary>
        /// Metodo que devuelve el nombre de un departamento de una lista de departamentos a partir del ID de departamento de una persona pasada por el constructor
        /// </summary>
        /// <pre>La persona debe tener un ID de departamento valido que no sea menor o igual que 0</pre>
        /// <post>Si el ID es 0 o menor, la funcion devolvera una cadena vacia. De lo contrario, la funcion devolvera el nombre del departamento asociado a la ID</post>
        /// <param name="idDep">ID de departamento de la persona pasada por constructor</param>
        /// <returns>Nombre del departamento buscado</returns>
        private string buscarNombreDep(int idDep)
        {
            string res = "";
            List<ClsDepartamento> departamentos = ClsListadoBL.ObtenerDepartamentosBL();
            ClsDepartamento? dep = ClsManejoDepartamentoBL.BuscarDepartamentoBL(idDep);
            if (dep != null) 
            {
                res = dep.Nombre;
            }
            return res;
        }
    }
}
