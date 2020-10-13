using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Formularios_LinQ.Formulario_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                decimal numero1 = Convert.ToDecimal(txtNumero1.Text);
                decimal numero2 = Convert.ToDecimal(txtNumero2.Text);
                lblResultado.Text = Convert.ToString(numero1 + numero2);
            }
            catch
            {
                MessageBox.Show("Ingresar números correctos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                lblResultado.Text = "";
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblResultado.Text = "";
        }
    }
}
