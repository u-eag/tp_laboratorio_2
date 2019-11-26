using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo
    {
        #region Campos

        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #endregion

        #region Propiedades

        /// <summary>
        /// 
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                // a completar
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// 
        /// </summary>
        public Correo()
        {

        }

        #endregion

        #region Métodos

        /// <summary>
        /// 
        /// </summary>
        public void FinEntregas()
        {
            // a completar
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar <List<Paquete>> elementos)
        {
            // a completar
            return "";
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            // a completar

            return c;
        }

        #endregion
    }
}
