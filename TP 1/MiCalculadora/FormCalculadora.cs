using System;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        #region Buttons
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Reflejará el resultado del método Operar en el Label txtResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Convertirá el resultado, de existir, a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// convertirá el resultado, de existir, a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Será llamado por el evento click del botón btnLimpiar 
        /// y borrará los datos de los TextBox, ComboBox y Label de la pantalla.
        /// </summary>
        private void Limpiar()
        {

        }

        /// <summary>
        /// Recibirá los dos números y el operador para luego llamar al método Operar de Calculadora
        /// y retornar el resultado al método de evento del botón btnOperar, 
        /// que reflejará el resultado en el Label txtResultado.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            return 0;
        }
        #endregion
    }
}