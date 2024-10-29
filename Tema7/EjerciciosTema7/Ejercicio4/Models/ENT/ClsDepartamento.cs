namespace Ejercicio4.Models.ENT
{
    public class ClsDepartamento
    {

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="idDep">ID de departamento</param>
        /// <param name="nombre">Nombre del departamento</param>
        public ClsDepartamento(int idDep, string nombre)
        {
            this.idDep = idDep;
            this.nombre = nombre;
        }

        /// <summary>
        /// ID de departamento
        /// </summary>
        public int idDep { get; }

        /// <summary>
        /// Nombre de departamento
        /// </summary>
        public String nombre { get; set; }

    }
}
