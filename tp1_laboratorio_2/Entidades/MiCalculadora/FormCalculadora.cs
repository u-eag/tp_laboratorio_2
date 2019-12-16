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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnLimpiar.Enabled = false;
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero aux = new Numero(lblResultado.Text);

            lblResultado.Text = aux.DecimalBinario(lblResultado.Text);
            btnConvertirADecimal.Enabled = true;
            btnConvertirABinario.Enabled = false;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero aux = new Numero(lblResultado.Text);

            lblResultado.Text = aux.BinarioDecimal(lblResultado.Text);
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = (Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text)).ToString();
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
            btnLimpiar.Enabled = true;
        }

        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double retorno = 0;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            if(num1 != null && num2 != null)
            {
                retorno = Calculadora.Operar(num1, num2, operador);
            }

            return retorno;
        }
    }
}
