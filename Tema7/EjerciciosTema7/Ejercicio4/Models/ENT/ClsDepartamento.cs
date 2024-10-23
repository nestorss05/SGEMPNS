namespace Ejercicio4.Models.ENT
{
    public class ClsDepartamento
    {

        public ClsDepartamento(int idDep, string nombre)
        {
            this.idDep = idDep;
            this.nombre = nombre;
        }

        public int idDep { get; }
        public String nombre { get; set; }

    }
}
