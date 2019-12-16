using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        #region Campos

        private Correo correo;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor que inicializa el form y el campo Correo
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Limpiará los 3 ListBox y
        /// luego recorrerá la lista de paquetes, 
        /// agregando cada uno de ellos en el listado que corresponda.
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();
            lstEstadoIngresado.Items.Clear();

            foreach (Paquete p in correo.Paquetes)
            {
                switch (p.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(p);
                        break;

                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(p);
                        break;

                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(p);
                        break;
                }
            }
        }

        /// <summary>
        /// a. Creará un nuevo paquete y asociará al evento InformaEstado el método paq_InformaEstado.
        /// b. Agregará el paquete al correo, controlando las excepciones que puedan derivar de dicha acción.
        /// c. Llamará al método ActualizarEstados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete p = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
                p.InformaEstado += this.paq_InformaEstado;
                this.correo += p;
                this.ActualizarEstados();
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// contendrá sólo la siguiente línea de código:
        /// this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>) correo);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// contendrá sólo la siguiente línea de código:
        /// this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// evaluará que el atributo elemento no sea nulo y:
        /// a. Mostrará los datos de elemento en el rtbMostrar.
        /// b. Utilizará el método de extensión para guardar los datos en un archivo llamado salida.txt.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            this.rtbMostrar.Clear();

            if (elemento != null)
            {
                if (elemento.GetType() == typeof(Correo))
                {
                    this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                }
                else if (elemento.GetType() == typeof(Paquete))
                {
                    this.rtbMostrar.Text = elemento.ToString();
                }

                elemento.MostrarDatos(elemento).Guardar("salida"); // válido para los dos typeof
            }
        }

        /// <summary>
        /// Al cerrarse el formulario, se deberá llamar al método FinEntregas 
        /// a fin de cerrar todos los hilos abiertos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// llamará al método ActualizarEstados en el ELSE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else // llamar al método
            {
                ActualizarEstados();
            }

        }

        #endregion

    }
}
