namespace MandarinasENT
{
    public class ClsMision
    {
        private int id;
        private string nombre;
        private string descripcion;
        private int recompensa;

        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value;} }
        public string Descripcion { get { return descripcion; } set { descripcion = value;} }
        public int Recompensa { get { return recompensa; } set { recompensa = value; } }

        public ClsMision() { }
        public ClsMision(int id, string nombre, string descripcion, int recompensa)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            if (recompensa > 0) 
            {
                this.recompensa = recompensa;
            }
        }
    }
}
