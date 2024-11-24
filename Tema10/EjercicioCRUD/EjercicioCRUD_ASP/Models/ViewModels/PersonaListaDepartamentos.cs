using EjercicioCRUD_BL;
using EjercicioCRUD_ENT;

namespace EjercicioCRUD_ASP.Models.ViewModels
{
    public class PersonaListaDepartamentos
    {
        private ClsPersona persona;
        private List<ClsDepartamento> departamentos;
        public ClsPersona Persona { get { return persona; } set { persona = value; } }
        public List<ClsDepartamento> Departamentos { get { return departamentos; } set { departamentos = value; } }

        public PersonaListaDepartamentos() { }
        public PersonaListaDepartamentos(ClsPersona p)
        {
            Persona = p;
            try
            {
                departamentos = ClsListadoBL.ObtenerDepartamentosBL();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
