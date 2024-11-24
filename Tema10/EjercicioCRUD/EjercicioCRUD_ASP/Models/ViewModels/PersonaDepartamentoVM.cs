using EjercicioCRUD_ENT;

namespace EjercicioCRUD_ASP.Models.ViewModels
{
    public class PersonaDepartamentoVM
    {
        private ClsPersona persona;
        private string departamento;
        public ClsPersona Persona { get { return persona; } set { persona = value; } }
        public string Departamento { get { return departamento; } set { departamento = value; } }

        public PersonaDepartamentoVM() { }

        public PersonaDepartamentoVM(ClsPersona p)
        {
            persona = p;
            try
            {
                departamento = EjercicioCRUD_BL.ClsManejoDepartamentoBL.BuscarDepartamentoBL(persona.IdDepartamento).Nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
