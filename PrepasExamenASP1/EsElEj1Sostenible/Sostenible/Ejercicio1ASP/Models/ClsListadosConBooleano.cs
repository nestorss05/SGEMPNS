using Ejercicio1ENT;

namespace Ejercicio1ASP.Models
{
    public class ClsListadosConBooleano: ClsPersona
    {
        private bool mayorEdad;
        public bool MayorEdad { get { return mayorEdad; } }

        public ClsListadosConBooleano(ClsPersona per) : base()
        {
            this.Nombre = per.Nombre;
            this.Apellidos = per.Apellidos;
            this.FechaNac = per.FechaNac;
            mayorEdad = esMayorEdad(per);
        }

        /// <summary>
        /// Funcion que devuelve un booleano indicando si la persona es mayor de edad o no
        /// </summary>
        /// <pre>La persona debe tener una fecha de nacimiento valida</pre>
        /// <post>La funcion siempre devuelve un valor booleano</post>
        /// <param name="per">Persona a analizar su mayoria de edad</param>
        /// <returns>Booleana que indica la mayoria de edad de una persona</returns>
        private bool esMayorEdad(ClsPersona per)
        {
            bool mayor = false;
            if (DateTime.Now.Year - per.FechaNac.Year >= 18 && DateTime.Now.Month >= per.FechaNac.Month && DateTime.Now.Day >= per.FechaNac.Day)
            {
                mayor = true;
            }
            return mayor;
        }

    }
}
