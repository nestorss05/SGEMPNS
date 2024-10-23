namespace Ejercicio4.Models.ENT
{
    public class ClsPersona
    {

        public String nombre { get; set; }
        public String apellido { get; set; }
        public int edad { get; set; }
        public int idDep { get; set; }

        public ClsPersona()
        {

        }

        public ClsPersona(string nombre, string apellido, int edad, int idDep)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.idDep = idDep;
        }

        public ClsPersona(ClsPersona p)
        {
            this.nombre = p.nombre;
            this.apellido = p.apellido;
            this.edad = p.edad;
            this.idDep = p.idDep;
        }

    }
}
