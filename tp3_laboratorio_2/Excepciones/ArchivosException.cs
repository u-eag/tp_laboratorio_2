using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        #region Constructores

        /// <summary>
        /// Error al intentar leer o guardar un archivo
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException (Exception innerException) 
            : base(innerException.Message, innerException)
        {

        }

        #endregion
    }
}
