using Ejercicio5BL;
using Ejercicio5Ent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5UIv2.ViewModels
{
    internal class MainPageVM
    {
        private List<clsPersona> lista;
        
        public List<clsPersona> Lista { get {
                lista = clsListadosBL.listadoPersonasBL();

                return lista; } }
        
    }
}
