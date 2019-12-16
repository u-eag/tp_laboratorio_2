using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase estática que se encargará de guardar los datos de un paquete 
    /// en la base de datos generada anteriormente.
    /// </summary>
    public static class PaqueteDAO
    {
        #region Campos

        private static SqlCommand comando;
        private static SqlConnection conexion;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor sin parámetros que inicializa los campos estáticos
        /// </summary>
        static PaqueteDAO()
        {
            // "Data Source=[Instancia Del Servidor]; Initial Catalog=[Nombre de la Base de Datos]: Integrated Security=True;"
            String connectionStr = "Server = .\\SQLEXPRESS; Database = correo-sp-2017; Trusted_Connection = True;";

            conexion = new SqlConnection(connectionStr);

            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;

            comando.Connection = conexion;

            // El campo alumno de la base de datos deberá contener el nombre del alumno que está realizando el TP:
            //comando.Parameters.AddWithValue("@alumno", "Antonella Gualco");
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Se encargará de guardar los datos de un paquete en la base de datos.
        /// De surgir cualquier error con la carga de datos, 
        /// se deberá lanzar una excepción tantas veces como sea necesario 
        /// hasta llegar a la vista(formulario).
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;

            if(p != null)
            {
                try
                {
                    conexion.Open();
                    string comandoInsert = string.Format("INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) VALUES ('{0}', '{1}', 'Antonella Gualco')",
                                                        p.DireccionEntrega, p.TrackingID);
                    comando.CommandText = comandoInsert;
                    comando.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e; // De surgir cualquier error con la carga de datos, se deberá lanzar una excepción
                }
                finally
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                    {
                        conexion.Close();
                        retorno = true;
                    }
                }
            }

            return retorno;
        }

        #endregion
    }
}
