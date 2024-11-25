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

        private List<ClsPersona> personas;
        private List<PersonaListaDepartamentos> listadoPersonas;

        public List<PersonaListaDepartamentos> ListadoPersonas { get { return listadoPersonas; } }

        public PersonaDepartamentoVM()
        {
            personas = ClsListadoBL.ObtenerPersonasBL();
            listadoPersonas = new List<PersonaListaDepartamentos>();
            montarListado();
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
    }
}
