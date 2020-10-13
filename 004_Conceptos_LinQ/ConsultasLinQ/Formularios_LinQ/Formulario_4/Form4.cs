using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Formularios_LinQ.Formulario_4
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        List<Categoria> listaCategoria;
        private void Form4_Load(object sender, EventArgs e)
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

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            var consulta = (from categoria in listaCategoria
                           where categoria.nombreCategoria.ToLower().Contains(txtNombre.Text.ToLower())
                           select categoria).ToList();

            dgvCategoria.DataSource = null;
            dgvCategoria.DataSource = consulta;
        }
    }
}
