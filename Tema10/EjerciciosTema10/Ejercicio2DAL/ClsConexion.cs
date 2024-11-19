using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2DAL
{
    public class ClsConexion
    {

        /// <summary>
        /// Metodo que devuelve el enlace de la BD
        /// </summary>
        /// <returns>Enlace de la BD a conectar</returns>
        public static string CadenaConexion()
        {
            string link = "Server=tcp:nestorss.database.windows.net,1433;Initial Catalog=EusebioNS;Persist Security Info=False;User ID=usuario;Password=Lacampana123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            return link;
        }

    }
}
