namespace Ejercicio4.Models.ENT
{
    public class ClsPersona
    {

        /// <summary>
        /// Nombre de una persona
        /// </summary>
        public String nombre { get; set; }

        /// <summary>
        /// Apellido de una persona
        /// </summary>
        public String apellido { get; set; }
        /// <summary>
        /// Edad de una persona
        /// </summary>
        public int edad { get; set; }
        /// <summary>
        /// ID de departamento de una persona
        /// </summary>
        public int idDep { get; set; }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="edad"></param>
        /// <param name="idDep"></param>
        public ClsPersona(string nombre, string apellido, int edad, int idDep)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.idDep = idDep;
        }

        /// <summary>
        /// Constructor con un objeto persona
        /// </summary>
        /// <param name="p"></param>
        public ClsPersona(ClsPersona p)
        {
            this.nombre = p.nombre;
            this.apellido = p.apellido;
            this.edad = p.edad;
            this.idDep = p.idDep;
        }

    }
}
