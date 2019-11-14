using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Métodos

        /// <summary>
        /// Recibe el path de un archivo y guarda datos en string.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>[true] si consigue guardarlo ok, sino [false]</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            if (!(archivo is null && datos is null))
            {
                System.IO.StreamWriter writer = null; // para escribir sobre el archivo

                try
                {
                    using (writer = new StreamWriter(archivo))
                    {
                        writer.WriteLine(datos);
                    }

                    retorno = true;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
                finally
                {
                    if (!(writer is null))
                    {
                        writer.Close();
                    }
                }
            }

            return retorno;
        }

        /// <summary>
        /// Recibe el path de un archivo y lee datos en string.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>[true] si consigue leerlo ok, sino [false]</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;

            datos = ""; // para limpiar la variable por si tiene basura

            try
            {
                using (StreamReader aux = new StreamReader(archivo))
                {
                    datos += aux.ReadToEnd(); // si está todo ok, escribo
                }

                retorno = true;
            }
            catch (Exception)
            {
                datos = ""; // si da error, limpio la variable
                retorno = false;
            }

            return retorno;
        }

        #endregion}
    }
}
