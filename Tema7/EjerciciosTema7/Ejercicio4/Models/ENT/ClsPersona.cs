namespace Ejercicio4.Models.ENT
{
    public class ClsPersona
    {

        String nombre { get; set; }
        String apellido { get; set; }
        int edad { get; set; }
        int idDep { get; set; }

        public ClsPersona(string nombre, string apellido, int edad, int idDep)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.idDep = idDep;
        }

    }
}
