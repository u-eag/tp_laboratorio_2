using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete> 
    {
        #region Campos

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #endregion

        #region Propiedades

        /// <summary>
        /// [get] devuelve la dirección de entrega
        /// [set] settea la dirección de entrega
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// [get] devuelve el estado de la entrega
        /// [set] settea el estado de la entrega:
        /// Ingresado, EnViaje, Entregado
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// [get] devuelve el id de rastreo
        /// [set] settea el id de rastreo
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }

        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor que recibe dos parámetros.
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado; // El estado del paquete se settea en [Ingresado] por default ??
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Hará que el paquete cambie de estado de la siguiente forma:
        /// a. Colocar una demora de 4 segundos.
        /// b. Pasar al siguiente estado.
        /// c. Informar el estado a través de InformarEstado. EventArgs no tendrá ningún dato extra.
        /// d. Repetir las acciones desde el punto A hasta que el estado sea Entregado.
        /// e. Finalmente guardar los datos del paquete en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.estado++;
                this.InformaEstado(this, new EventArgs());
            }

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Utilizará string.Format con el siguiente formato 
        /// "{0} para {1}", p.trackingID, p.direccionEntrega 
        /// para compilar la información del paquete.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;

            return string.Format("{0} para {1}", p.trackingID, p.direccionEntrega);
        }

        /// <summary>
        /// La sobrecarga del método ToString retornará la información del paquete.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append(MostrarDatos(this)); // trackingID && direccionEntrega
            retorno.AppendFormat("Estado: {0}", this.estado);

            return retorno.ToString();
        }

        #endregion

        #region Sobrecarga de Operadores

        /// <summary>
        /// Dos paquetes serán iguales siempre y cuando su Tracking ID sea el mismo.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;

            if (//p1 != null && p2 != null && --> si lo descomento falla el test de paquete repetido
                p1.TrackingID == p2.TrackingID)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Dos paquetes serán distintos siempre y cuando su Tracking ID sea diferente.
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

        public delegate void DelegadoEstado(object sender, EventArgs args); // chequear los parámetros

        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }

        #endregion
    }
}
