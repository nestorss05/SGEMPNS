﻿using Ejercicio2ENT;
using Microsoft.Data.SqlClient;

namespace Ejercicio2DAL
{
    public class ClsListadoDAL
    {
        /// <summary>
        /// Ofrece un listado completo de personas obtenidas de una BD alojada en Azure
        /// </summary>
        /// <returns>Listado completo de personas</returns>
        public static List<ClsPersona> ObtenerPersonas()
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
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return listadoPersonas;
        }
    }
}
