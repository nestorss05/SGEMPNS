using EjercicioCRUD_BL;
using EjercicioCRUD_ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDMAUIV3.Models
{
    public class PersonaListaDepartamentos
    {
        private string nombreDepartamento;
        public string NombreDepartamento { get { return nombreDepartamento; } }

        public PersonaListaDepartamentos(ClsPersona per, List<ClsDepartamento> departamentos)
        {
            
        }
    }
}
