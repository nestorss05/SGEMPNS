namespace Ejercicio2.Models.DAL
{
    public class ClsListado
    {

        public static List<clsPersona> GetListado()
        {
            List<clsPersona> listado = new List<clsPersona>
            {
                new clsPersona(1, "Andrea", "Torres Rodríguez", new DateTime(1990, 03, 14), "Madrid, España", "+34 612 345 678"),
                new clsPersona(2, "Santiago", "Gómez Pérez", new DateTime(1985, 11, 22), "Buenos Aires, Argentina", "+54 11 1234 5678"),
                new clsPersona(3, "Valeria", "Ruiz Martínez", new DateTime(1998, 07, 05), "Bogotá, Colombia", "+57 310 765 4321"),
                new clsPersona(4, "Luis Fernando", "Silva López", new DateTime(1978, 01, 30), "Ciudad de México, México", "+52 55 9876 5432"),
                new clsPersona(5, "Carolina", "Jiménez Sánchez", new DateTime(1995, 09, 19), "Quito, Ecuador", "+593 2 345 6789"),
                new clsPersona(6, "Daniel", "Vargas Castillo", new DateTime(1983, 12, 08), "Santiago, Chile", "+56 9 8765 4321"),
            };
            return listado;
        }

    }
}
