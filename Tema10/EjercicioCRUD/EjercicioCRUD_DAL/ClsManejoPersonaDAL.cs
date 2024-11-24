using EjercicioCRUD_ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCRUD_DAL
{
    public class ClsManejoPersonaDAL
    {
        /// <summary>
        /// Inserta una persona en la BD
        /// </summary>
        /// <pre>La persona creada debe ser valida</pre>
        /// <post>Puede devolver 0 o N dependiendo de la cantidad de filas afectadas</post>
        /// <param name="per">Persona a añadir</param>
        /// <returns>Nº de filas afectadas</returns>
        public static int CrearPersonaDAL(ClsPersona per)
        {
            int numeroFilasAfectadas = 0;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            miConexion.ConnectionString = (ClsConexion.CadenaConexion());
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = per.Nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = per.Apellidos;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = per.Telefono;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = per.Direccion;
            miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = per.Foto;
            miComando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = per.FechaNacimiento;
            miComando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = per.IdDepartamento;
            try
            {
                miConexion.Open();
                miComando.CommandText = "INSERT INTO Personas VALUES (@nombre, @apellidos, @telefono, @direccion, @foto, @fechaNacimiento, @idDepartamento)";
                miComando.Connection = miConexion;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                miConexion.Close();
            }
            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Edita una persona de la BD
        /// </summary>
        /// <pre>La persona debe existir en la BD</pre>
        /// <post>Puede devolver 0 o N dependiendo de la cantidad de filas afectadas</post>
        /// <param name="per">Persona a modificar</param>
        /// <returns>Nº de filas afectadas</returns>
        public static int EditarPersonaDAL(ClsPersona per)
        {
            int numeroFilasAfectadas = 0;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            miConexion.ConnectionString = (ClsConexion.CadenaConexion());
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = per.Id;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = per.Nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = per.Apellidos;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = per.Telefono;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = per.Direccion;
            miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = per.Foto;
            miComando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = per.FechaNacimiento;
            miComando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = per.IdDepartamento;
            try
            {
                miConexion.Open();
                miComando.CommandText = "UPDATE Personas SET Nombre = @nombre, Apellidos = @apellidos, Telefono = @telefono, Direccion = @direccion, Foto = @foto, FechaNacimiento = @fechaNacimiento, IDDepartamento = @idDepartamento WHERE ID = @id";
                miComando.Connection = miConexion;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                miConexion.Close();
            }
            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Borra una persona de la BD a base de su ID
        /// </summary>
        /// <pre>El ID de persona debe corresponder con uno que exista en la BD</pre>
        /// <post>Puede devolver 0 o N dependiendo de la cantidad de filas afectadas</post>
        /// <param name="id">ID de la persona a eliminar</param>
        /// <returns>Nº de filas afectadas</returns>
        public static int BorrarPersonaDAL(int id)
        {
            int numeroFilasAfectadas = 0;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            miConexion.ConnectionString = (ClsConexion.CadenaConexion());
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            try
            {
                miConexion.Open();
                miComando.CommandText = "DELETE FROM Personas WHERE ID=@id";
                miComando.Connection = miConexion;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                miConexion.Close();
            }
            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Busca una persona en la List
        /// </summary>
        /// <pre>El id deberia ser mayor que 0</pre>
        /// <post>Puede devolver null si no ha encontrado una persona</post>
        /// <param name="id"></param>
        /// <returns>Persona encontrada</returns>
        public static ClsPersona? BuscarPersonaDAL(int id)
        {
            List<ClsPersona> personas = ClsListadoDAL.ObtenerPersonasDAL();
            ClsPersona per = personas.Find(perx => perx.Id == id);
            return per;
        }
    }
}
