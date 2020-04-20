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
            Limpiar();
        }

        #region Buttons
        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Reflejará el resultado del método Operar en el Label txtResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = (Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text)).ToString();
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
            btnLimpiar.Enabled = true;
        }

        /// <summary>
        /// Convertirá el resultado, de existir, a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero aux = new Numero(lblResultado.Text);

            lblResultado.Text = aux.DecimalBinario(lblResultado.Text);
            btnConvertirADecimal.Enabled = true;
            btnConvertirABinario.Enabled = false;
        }

        /// <summary>
        /// convertirá el resultado, de existir, a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero aux = new Numero(lblResultado.Text);

            lblResultado.Text = aux.BinarioDecimal(lblResultado.Text);
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Será llamado por el evento click del botón btnLimpiar 
        /// y borrará los datos de los TextBox, ComboBox y Label de la pantalla.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
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
            double retorno = 0;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            if (num1 != null && num2 != null)
            {
                retorno = Calculadora.Operar(num1, num2, operador);
            }

            return retorno;
        }
        #endregion
    }
}