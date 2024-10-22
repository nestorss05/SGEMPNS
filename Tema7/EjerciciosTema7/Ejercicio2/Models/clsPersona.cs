namespace Ejercicio2.Models
{
    public class clsPersona
    {
        public clsPersona()
        {
        }

        public clsPersona(int v1, string v2, string v3, DateTime dateTime, string v4, string v5)
        {
            this.idPersona = v1;
            this.nombre = v2;
            this.apellidos = v3;
            this.fechaNac = dateTime;
            this.direccion = v4;
            this.telefono = v5;
        }
        #region propiedades
        public int idPersona { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public DateTime fechaNac { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        #endregion

    }
}
