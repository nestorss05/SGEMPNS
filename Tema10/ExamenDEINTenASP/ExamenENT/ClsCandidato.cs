namespace ExamenENT
{
    public class ClsCandidato
    {
        private int id;
        private string nombre;

        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }

        public ClsCandidato() { }
        public ClsCandidato(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}
