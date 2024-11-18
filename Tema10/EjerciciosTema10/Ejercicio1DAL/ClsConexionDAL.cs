using Microsoft.Data.SqlClient;

namespace Ejercicio1DAL
{
    public class ClsConexionDAL
    {
        /// <summary>
        /// Metodo que devuelve el estado de conexion de una BD en Azure
        /// </summary>
        /// <returns>Estado de conexion de la BD</returns>
        public static String AbrirConexion()
        {
            SqlConnection miConexion = new SqlConnection();
            String estadoConexion;

            try
            {
                miConexion.ConnectionString = "Server=tcp:nestorss.database.windows.net,1433;Initial Catalog=EusebioNS;Persist Security Info=False;User ID=usuario;Password=Lacampana123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                miConexion.Open();
                estadoConexion = miConexion.State.ToString();
            }
            catch (Exception ex)
            {
                estadoConexion = "Error: " + ex.Message;
            }
            finally
            {
                if (miConexion.State == System.Data.ConnectionState.Open)
                {
                    miConexion.Close();
                }
            }
            return estadoConexion;
        }
    }
}
