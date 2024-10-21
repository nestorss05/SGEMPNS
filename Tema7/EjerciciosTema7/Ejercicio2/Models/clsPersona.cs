namespace Ejercicio2.Models
{
    public class clsPersona
    {
        public int idPersona { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public DateTime fechaNac { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }

        public clsPersona()
        {
        }

        public clsPersona(int idPersona, string nombre, string apellidos, DateTime fechaNac, string direccion, string telefono)
        {
            this.idPersona = idPersona;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNac = fechaNac;
            this.direccion = direccion;
            this.telefono = telefono;
        }

    }
}
