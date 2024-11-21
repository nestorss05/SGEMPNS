using Ejercicio1BL;
using Ejercicio1ENT;

namespace Ejercicio1ASP.Models
{
    public class ClsListadosVM
    {
        private List<ClsPersona> personas;
        private List<ClsListadosConBooleano> personasFull;
        public List<ClsListadosConBooleano> PersonasFull { get { return personasFull; } }
        public ClsListadosVM()
        {
            personas = ClsListadoBL.ListadoPersonasBL();
            personasFull = new List<ClsListadosConBooleano>();
            montarListado();
        }

        /// <summary>
        /// Monta el listado personasFull para mostrarlo por pantalla
        /// </summary>
        /// <pre>Ninguna</pre>
        /// <post>Ninguna</post>
        private void montarListado()
        {
            ClsListadosConBooleano itemNuevo;
            foreach (ClsPersona persona in personas)
            {
                itemNuevo = new ClsListadosConBooleano(persona);
                personasFull.Add(itemNuevo);
            }
        }
    }
}
