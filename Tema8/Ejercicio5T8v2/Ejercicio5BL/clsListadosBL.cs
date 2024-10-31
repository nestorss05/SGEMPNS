using Ejercicio5DAL;
using Ejercicio5Ent;
using System.Collections.ObjectModel;

namespace Ejercicio5BL
{
    public class clsListadosBL
    {
        /// <summary>
        /// Funcion estatica que llama a la DAL, aplica las reglas de negocio oportunas y devuelve el listado de personas
        /// </summary>
        /// <returns>Listado de ClsPersonas en ObservableCollection</returns>
        public static List<clsPersona> listadoPersonasBL()
        {
            List<clsPersona> miListado = clsListadosDAL.getListadoCompletoPersonas();

            //TODO Comprobar si es jueves y antes o despues de las 13:30

            return miListado;
        
        }
    }
}
