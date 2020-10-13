using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Formularios_LinQ.Formulario_3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        List<Categoria> listaCategoria;
        private void Form3_Load(object sender, EventArgs e)
        {
            listaCategoria = new List<Categoria>
            {
                new Categoria { idCategoria=1, nombreCategoria="Frutas" },
                new Categoria { idCategoria=2, nombreCategoria="Verduras" },
                new Categoria { idCategoria=3, nombreCategoria="Medicinas" },
                new Categoria { idCategoria=4, nombreCategoria="Lapiceros" },
                new Categoria { idCategoria=5, nombreCategoria="Celulares" }
            };

            dgvCategoria.DataSource = listaCategoria;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ///Leer texto.
            string nombre = txtNombre.Text;
            //Elaborar la consulta.
            var consulta = listaCategoria.Where(c => c.nombreCategoria.Equals(nombre)).ToList();
            //Mostrar consulta.
            dgvCategoria.DataSource = null;//Limpiar Data Grid View.
            dgvCategoria.DataSource = consulta;//Colocar lista.
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            dgvCategoria.DataSource = null;//Limpiar Data Grid View.
            dgvCategoria.DataSource = listaCategoria;//Colocar lista.
        }
    }
}
