using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        #region Métodos

        /// <summary>
        /// Método de extensión para la clase String.
        /// Guardará en un archivo de texto en el escritorio de la máquina.
        /// Recibirá como parámetro el nombre del archivo.
        /// Si el archivo existe, agregará información en él.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;

            if (!string.IsNullOrEmpty(archivo) && !string.IsNullOrEmpty(texto))
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                //using maneja el archivo, encargándose de cerrarlo  al finalizar
                using (StreamWriter sw = new StreamWriter(folderPath + "\\" + archivo, File.Exists(archivo)))
                {
                    sw.WriteLine(texto); // si el archivo existe, guardo el texto pasado por parámetro
                    retorno = true;
                }
            }

            return retorno;
        }

        #endregion
    }
}
