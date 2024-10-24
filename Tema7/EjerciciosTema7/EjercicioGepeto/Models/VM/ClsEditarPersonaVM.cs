using System.Collections.Generic;
using EjercicioGepeto.Models.DAL;
using EjercicioGepeto.Models.ENT;

namespace EjercicioGepeto.Models.VM
{
    public class ClsEditarPersonaVM
    {
        public ClsPersona Persona { get; set; }
        public List<ClsDepartamento> Departamentos { get; private set; }

        public ClsEditarPersonaVM()
        {
            Departamentos = ClsListados.ObtenerDepartamentos();
        }
    }
}
