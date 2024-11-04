using Ejercicio5DAL;
using Ejercicio5Ent;
using System.Collections.ObjectModel;

namespace Ejercicio5BL
{
    public class clsListadosBL
    {
        /// <summary>
        /// Funcion estatica que llama a la DAL, aplica las reglas de negocio oportunas (controla el dia y la hora) y devuelve el listado de personas
        /// </summary>
        /// <returns>Listado de ClsPersonas en ObservableCollection</returns>
        public static List<clsPersona> listadoPersonasBL()
        {
            List<clsPersona> miListado = clsListadosDAL.getListadoCompletoPersonas();

            if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
            {
                if (DateTime.Now.Hour <= 13 && DateTime.Now.Minute < 30)
                {
                    miListado = miListado.Take(5).ToList();
                } else {
                    miListado = miListado.Skip(Math.Max(0, miListado.Count - 5)).ToList();
                }
            }

            return miListado;
        
        }
    }
}
