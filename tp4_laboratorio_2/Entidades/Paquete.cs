using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete
    {
        #region Campos

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #endregion

        #region Propiedades

        /// <summary>
        /// 
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                // a completar
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                // a completar
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
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
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            // a completar
        }

        #endregion

        #region Métodos

        /// <summary>
        /// 
        /// </summary>
        public void MockCicloDeVida()
        {
            // a completar
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            // a completar
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "";
        }

        #endregion

        #region Sobrecarga de Operadores

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return true; // a completar
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        #endregion

        #region Eventos

        public event DelegadoEstado InformaEstado;

        #endregion

        #region Tipos Anidados

        public delegate void DelegadoEstado(); // completar los parámetros

        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }

        #endregion
    }
}
