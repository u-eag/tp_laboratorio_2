using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Recibe el path de un archivo y guarda en él un dato de tipo genérico
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
       public bool Guardar (string archivo, T datos)
        {
            bool retorno = false;

            if (!(archivo is null))
            {
                XmlWriter writer = null;
                try
                {
                    writer = new XmlTextWriter(archivo, Encoding.UTF8); // para poder escribir en el archivo xml
                    XmlSerializer serializer = new XmlSerializer(typeof(T)); // creo un serializador para el tipo de objeto T
                    serializer.Serialize(writer, datos); // guardo los datos de ese objeto en el xml
                    retorno = true;
                }
                catch (Exception archivosEx) // si da error
                {
                    throw new ArchivosException(archivosEx); // lanzo la excepcón
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
        /// Recibe el path de un archivo y lee de él un dato de tipo genérico
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer (string archivo, out T datos)
        {
            bool retorno = false;
            datos = default(T); // null genérico para limpiar la variable

            if (!(archivo is null))
            {
                XmlReader lector = null;

                try
                {
                    lector = new XmlTextReader(archivo); 
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    datos = (T)serializador.Deserialize(lector); // levanto el dato genérico según su tipo
                    retorno = true;
                }
                catch (Exception archivoEx)
                {
                    throw new ArchivosException(archivoEx);
                }
                finally
                {
                    if (!(lector is null))
                    {
                        lector.Close();
                    }
                }
            }
            return retorno;
        }
    }
}
