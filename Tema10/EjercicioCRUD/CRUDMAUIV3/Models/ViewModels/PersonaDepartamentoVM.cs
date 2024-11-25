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
    public class PersonaDepartamentoVM
    {

        private List<PersonaListaDepartamentos> listadoPersonas;

        public List<PersonaListaDepartamentos> ListadoPersonas { get { return listadoPersonas; } }

        public PersonaDepartamentoVM()
        {
            List<ClsPersona> personas = ClsListadoBL.ObtenerPersonasBL();
            List<ClsDepartamento> departamentos = ClsListadoBL.ObtenerDepartamentosBL();
            listadoPersonas = new List<PersonaListaDepartamentos>();


        }
    }
}
