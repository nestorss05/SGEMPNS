using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCRUD_ENT
{
    public class clsMensajeUsuario
    {
        public String nombreUsuario { get; set; }
        public String mensajeUsuario { get; set; }
        public String grupo { get; set; }
        public clsMensajeUsuario() { }
        public clsMensajeUsuario(string nombreUsuario, string mensajeUsuario, string grupo)
        {
            this.nombreUsuario = nombreUsuario;
            this.mensajeUsuario = mensajeUsuario;
            this.grupo = grupo;
        }
    }
}
