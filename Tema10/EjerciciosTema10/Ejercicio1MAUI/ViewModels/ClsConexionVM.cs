using Java.Net;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1MAUI.ViewModels
{
    public class ClsConexionVM
    {
        SqlConnection miConexion = new SqlConnection();
        String estadoConexion = abrirConexion(miConexion);

        public static String abrirConexion(SqlConnection miConexion)
        {
            String estado = "";
            try
            {
                miConexion.ConnectionString = "Server=tcp:nestorss.database.windows.net,1433;Initial Catalog=EusebioNS;Persist Security Info=False;User ID=usuario;Password=Lacampana123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                miConexion.Open();
                estado = miConexion.State.ToString();
            }
            catch (Exception ex)
            {
                estado = "Error: " + ex.Message;
            }
            finally
            {
                if (miConexion.State == System.Data.ConnectionState.Open)
                {
                    miConexion.Close();
                }
            }

            return estado;
        }
            
    }
}
