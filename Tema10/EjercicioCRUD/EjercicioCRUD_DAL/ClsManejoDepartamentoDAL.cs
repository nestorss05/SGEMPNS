﻿using EjercicioCRUD_ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioCRUD_DAL
{
    public class ClsManejoDepartamentoDAL
    {
        /// <summary>
        /// Inserta un departamento en la BD
        /// </summary>
        /// <pre>El departamento creado debe ser valido</pre>
        /// <post>Puede devolver 0 o N dependiendo de la cantidad de filas afectadas</post>
        /// <param name="per">Departamento a añadir</param>
        /// <returns>Nº de filas afectadas</returns>
        public static int CrearDepartamentoDAL(ClsDepartamento dep)
        {
            int numeroFilasAfectadas = 0;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            miConexion.ConnectionString = (ClsConexion.CadenaConexion());
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = dep.Id;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = dep.Nombre;
            try
            {
                miConexion.Open();
                miComando.CommandText = "INSERT INTO Departamentos VALUES (@id, @nombre)";
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
        /// Edita un departamento de la BD
        /// </summary>
        /// <pre>El departamento debe existir en la BD</pre>
        /// <post>Puede devolver 0 o N dependiendo de la cantidad de filas afectadas</post>
        /// <param name="per">Departamento a modificar</param>
        /// <returns>Nº de filas afectadas</returns>
        public static int EditarDepartamentoDAL(ClsDepartamento dep)
        {
            int numeroFilasAfectadas = 0;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            miConexion.ConnectionString = (ClsConexion.CadenaConexion());
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = dep.Id;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = dep.Nombre;

            try
            {
                miConexion.Open();
                miComando.CommandText = "UPDATE Departamentos SET Nombre = @nombre WHERE ID = @id";
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
        /// Borra un departamento de la BD a base de su ID
        /// </summary>
        /// <pre>El ID de departamento debe corresponder con uno que exista en la BD</pre>
        /// <post>Puede devolver 0 o N dependiendo de la cantidad de filas afectadas</post>
        /// <param name="id">ID del departamento a eliminar</param>
        /// <returns>Nº de filas afectadas</returns>
        public static int BorrarDepartamentoDAL(int id)
        {
            int numeroFilasAfectadas = 0;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            miConexion.ConnectionString = (ClsConexion.CadenaConexion());
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            try
            {
                miConexion.Open();
                miComando.CommandText = "DELETE FROM Departamentos WHERE ID=@id";
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
        /// Busca un departamento en la List
        /// </summary>
        /// <pre>El id deberia ser mayor que 0</pre>
        /// <post>Puede devolver null si no ha encontrado un departamento</post>
        /// <param name="id"></param>
        /// <returns>Departamento encontrado</returns>
        public static ClsDepartamento? BuscarDepartamentoDAL(int id)
        {
            List<ClsDepartamento> departamentos = ClsListadoDAL.ObtenerDepartamentosDAL();
            ClsDepartamento dep = departamentos.Find(depx => depx.Id == id);
            return dep;
        }

    }
}
