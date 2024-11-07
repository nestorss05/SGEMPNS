namespace EjercicioT8FinalENT
{
    /// <summary>
    /// Clase utilizada para almacennar la informacion de una mision
    /// </summary>
    public class ClsMision
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int recompensa { get; set; }

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
