using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Campos

        private static SqlCommand comando;
        private static SqlConnection conexion;

        #endregion

        #region Constructores

        static PaqueteDAO()
        {
            // a completar
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
                    // acá va el comando sql para insertar: comando.CommandText = ...
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
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
