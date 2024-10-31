using Ejercicio5Ent;
using System.Collections.ObjectModel;

namespace Ejercicio5DAL
{
    public class clsListadosDAL
    {

        /// <summary>
        /// Función que nos devuelve un listado de todas las personas
        /// </summary>
        /// <returns>Listado de personas</returns>
        public static List<clsPersona> getListadoCompletoPersonas() {
            List<clsPersona> listaPersona = new List<clsPersona>();
            listaPersona.Add(new clsPersona { id = 1, nombre = "Sofia", apellidos = "Martinez", fechaNac = new DateTime(1994, 03, 12).ToString("dd/MM/yyyy") });
            listaPersona.Add(new clsPersona { id = 2, nombre = "Diego", apellidos = "Fernandez", fechaNac = new DateTime(1988, 07, 23).ToString("dd/MM/yyyy") });
            listaPersona.Add(new clsPersona { id = 3, nombre = "Lucia", apellidos = "Gonzalez", fechaNac = new DateTime(1972, 01, 05).ToString("dd/MM/yyyy") });
            listaPersona.Add(new clsPersona { id = 4, nombre = "Juan", apellidos = "Perez", fechaNac = new DateTime(1965, 11, 17).ToString("dd/MM/yyyy") });
            listaPersona.Add(new clsPersona { id = 5, nombre = "Valentina", apellidos = "Lopez", fechaNac = new DateTime(1990, 04, 29).ToString("dd/MM/yyyy") });
            listaPersona.Add(new clsPersona { id = 6, nombre = "Sebastian", apellidos = "Ramirez", fechaNac = new DateTime(1980, 12, 08).ToString("dd/MM/yyyy") });
            listaPersona.Add(new clsPersona { id = 7, nombre = "Camila", apellidos = "Torres", fechaNac = new DateTime(1957, 08, 03).ToString("dd/MM/yyyy") });
            listaPersona.Add(new clsPersona { id = 8, nombre = "Nicolas", apellidos = "Superbigote", fechaNac = new DateTime(1962, 11, 23).ToString("dd/MM/yyyy") });
            listaPersona.Add(new clsPersona { id = 9, nombre = "Elon", apellidos = "Mok", fechaNac = new DateTime(1971, 06, 28).ToString("dd/MM/yyyy") });
            listaPersona.Add(new clsPersona { id = 10, nombre = "Hugo", apellidos = "Destructor", fechaNac = new DateTime(1954, 07, 28).ToString("dd/MM/yyyy") });
            return listaPersona;
        }

    }
}
