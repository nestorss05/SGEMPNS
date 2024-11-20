using EjercicioCRUD_ENT;
using Microsoft.Data.SqlClient;

namespace EjercicioCRUD_DAL
{
    public class ClsListadoDAL
    {
        /// <summary>
        /// Ofrece un listado completo de personas obtenidas de una BD alojada en Azure
        /// </summary>
        /// <pre>Ninguna</pre>
        /// <post>Devuelve siempre una lista de personas</post>
        /// <returns>Listado completo de personas</returns>
        public static List<ClsPersona> ObtenerPersonasDAL()
        {
            SqlConnection miConexion = new SqlConnection();
            List<ClsPersona> listadoPersonas = new List<ClsPersona>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            ClsPersona oPersona;
            miConexion.ConnectionString = (ClsConexion.CadenaConexion());
            try
            {
                miConexion.Open();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)
                miComando.CommandText = "SELECT * FROM Personas";

                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new ClsPersona();
                        oPersona.Id = (int)miLector["ID"];
                        oPersona.Nombre = (String)miLector["Nombre"];
                        oPersona.Apellidos = (String)miLector["Apellidos"];
                        oPersona.Telefono = (String)miLector["Telefono"];
                        oPersona.Direccion = (String)miLector["Direccion"];
                        oPersona.Foto = (String)miLector["Foto"];
                        oPersona.FechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                        oPersona.IdDepartamento = (int)miLector["IDDepartamento"];
                        listadoPersonas.Add(oPersona);
                    }
                }
                miLector.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            } 
            finally
            {
                miConexion.Close();
            }
            return listadoPersonas;
        }

        /// <summary>
        /// Ofrece un listado completo de departamentos obtenidos de una BD alojada en Azure
        /// </summary>
        /// <pre>Ninguna</pre>
        /// <post>Devuelve siempre una lista de departamentos</post>
        /// <returns>Listado completo de departamentos</returns>
        public static List<ClsDepartamento> ObtenerDepartamentosDAL()
        {
            SqlConnection miConexion = new SqlConnection();
            List<ClsDepartamento> listadoDepartamentos = new List<ClsDepartamento>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            ClsDepartamento oDepartamento;
            miConexion.ConnectionString = (ClsConexion.CadenaConexion());
            try
            {
                miConexion.Open();

                //Creamos el comando (Creamos el comando, le pasamos la sentencia y la conexion, y lo ejecutamos)
                miComando.CommandText = "SELECT * FROM Departamentos";

                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oDepartamento = new ClsDepartamento();
                        oDepartamento.Id = (int)miLector["ID"];
                        oDepartamento.Nombre = (String)miLector["Nombre"];
                        listadoDepartamentos.Add(oDepartamento);
                    }
                }
                miLector.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            finally
            {
                miConexion.Close();
            }
            return listadoDepartamentos;
        }

    }
}
