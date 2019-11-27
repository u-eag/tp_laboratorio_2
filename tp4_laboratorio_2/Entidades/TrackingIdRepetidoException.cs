﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        #region Constructores

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje"></param>
        public TrackingIdRepetidoException(string mensaje) : base (mensaje)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="inner"></param>
        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }

        #endregion
    }
}
