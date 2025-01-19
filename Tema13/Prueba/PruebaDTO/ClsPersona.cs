namespace PruebaDTO
{
    public class ClsPersona
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Descripcion { get; set; }
        public ClsPersona() { }
        public ClsPersona(string id, string nombre, string apellidos, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Descripcion = descripcion;
        }
    }
}
