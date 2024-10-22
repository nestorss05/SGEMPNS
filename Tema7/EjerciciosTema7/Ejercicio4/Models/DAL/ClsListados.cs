using Ejercicio4.Models.ENT;

namespace Ejercicio4.Models.DAL
{
    public class ClsListados
    {

        public static List<ClsPersona> ObtenerPersonas()
        {
            List<ClsPersona> personas = new List<ClsPersona>
            {
                new ClsPersona("Andrea", "Torres Rodríguez", 34, 1),
                new ClsPersona("Santiago", "Gómez Pérez", 39, 2),
                new ClsPersona("Valeria", "Ruiz Martínez", 26, 2),
                new ClsPersona("Luis Fernando", "Silva López", 46, 3),
                new ClsPersona("Carolina", "Jiménez Sánchez", 29, 4),
                new ClsPersona("Daniel", "Vargas Castillo", 41, 3),
            };

            return personas;
        }
        public static List<ClsDepartamento> ObtenerDepartamentos()
        {
            List<ClsDepartamento> departamentos = new List<ClsDepartamento>
            {
                new ClsDepartamento(1, "Recursos Humanos"),
                new ClsDepartamento(2, "Marketing"),
                new ClsDepartamento(3, "Ventas"),
                new ClsDepartamento(4, "Logistica")
            };
            return departamentos;
        }

    }
}
