using System.Collections.Generic;
using EjercicioGepeto.Models.ENT;

namespace EjercicioGepeto.Models.DAL
{
    public static class ClsListados
    {
        public static List<ClsPersona> ObtenerPersonas()
        {
            // Aquí puedes agregar lógica para obtener personas desde una base de datos.
            return new List<ClsPersona>
            {
                new ClsPersona { Nombre = "Juan", Apellido = "Pérez", Edad = 30, IdDep = 1 },
                new ClsPersona { Nombre = "María", Apellido = "González", Edad = 25, IdDep = 2 }
            };
        }

        public static List<ClsDepartamento> ObtenerDepartamentos()
        {
            // Aquí puedes agregar lógica para obtener departamentos desde una base de datos.
            return new List<ClsDepartamento>
            {
                new ClsDepartamento { IdDep = 1, Nombre = "Recursos Humanos" },
                new ClsDepartamento { IdDep = 2, Nombre = "Desarrollo" }
            };
        }
    }
}
