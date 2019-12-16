using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>> 
    {
        #region Campos

        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #endregion

        #region Propiedades

        /// <summary>
        /// [get] devuelve la lista de paquetes
        /// [set] settea la lista de paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor sin parámetros.
        /// Inicializa las listas.
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Cerrará todos los hilos activos.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread t in this.mockPaquetes)
            {
                if (t.IsAlive)
                {
                    t.Abort();
                }
            }
        }

        /// <summary>
        /// utilizará string.Format con el siguiente formato 
        /// "{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString() 
        /// para retornar los datos de todos los paquetes de su lista.
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar <List<Paquete>> elementos)
        {
            string retorno = "";
            Correo c = (Correo)elementos;

            foreach (Paquete p in c.Paquetes)
            {
                retorno += string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }

            return retorno;
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Esta sobrecarga realiza 4 acciones:
        /// a. Controlar si el paquete ya está en la lista. 
        /// En el caso de que esté, se lanzará la excepción TrackingIdRepetidoException.
        /// b. De no estar repetido, agregar el paquete a la lista de paquetes.
        /// c. Crear un hilo para el método MockCicloDeVida del paquete, 
        /// y agregar dicho hilo a mockPaquetes.
        /// d. Ejecutar el hilo.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.Paquetes)
            {
                if(paquete == p)
                {
                    throw new TrackingIdRepetidoException("Paquete repetido");
                }
            }

            // si llega hasta acá, es porque el paquete no está repetido:
            c.paquetes.Add(p); // agrego el paquete a la lista de paquetes
            Thread thread = new Thread(p.MockCicloDeVida); // creo un hilo para el método MockCicloDeVida del paquete
            c.mockPaquetes.Add(thread); // agrego el hilo a mockPaquetes
            thread.Start(); // ejecuto el hilo

            return c;
        }

        #endregion
    }
}
