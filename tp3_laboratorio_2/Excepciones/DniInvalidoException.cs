using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region Campos

        private string mensajeBase;

        #endregion

        #region Constructores

        public DniInvalidoException() : base()
        {

        }

        public DniInvalidoException(Exception e)
        {

        }

        public DniInvalidoException(string message)
        {

        }

        public DniInvalidoException(string message, Exception e)
        {

        }

        #endregion
    }
}
