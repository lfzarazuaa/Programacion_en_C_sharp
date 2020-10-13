using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_LinQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Categoria> listaCategoria;
        private void Form1_Load(object sender, EventArgs e)
        {
            listaCategoria = new List<Categoria>
            {
                new Categoria { idCategoria=1, nombreCategoria="Frutas" },
                new Categoria { idCategoria=2, nombreCategoria="Verduras" }
            };

            dgvCategoria.DataSource = listaCategoria;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                //Validación
                if (txtIdCategoria.Text.Equals(""))
                {
                    errorFormulario.SetError(txtIdCategoria, "Ingresar Id Categoria");//Crea mensaje de error señalando el elemento que lo produjo.
                    return;
                }
                if (txtNombre.Text.Equals(""))
                {
                    errorFormulario.SetError(txtNombre, "Ingresar nombre de Categoria");//Crea mensaje de error señalando el elemento que lo produjo.
                    return;
                }

                //Capturar valores
                int idCategoria = int.Parse(txtIdCategoria.Text);//Obtiene el Id del formulario y lo guarda en una categoría.
                string nombre = txtNombre.Text;
                
                // Validar id
                Categoria categoria = new Categoria();
                categoria.idCategoria = idCategoria;
                categoria.nombreCategoria = nombre;

                var consulta = listaCategoria.Where(c => c.idCategoria.Equals(categoria.idCategoria));

                if (!consulta.Any())
                {
                    listaCategoria.Add(categoria);//Agrega a la lista

                    dgvCategoria.DataSource = null;//Limpia los datos.
                    dgvCategoria.DataSource = listaCategoria;//Coloca la nueva lista en la GUI.
                    limpiar();
                }
                else
                {
                    errorFormulario.SetError(txtIdCategoria, "El Id ya existe.");//Crea mensaje de error señalando el elemento que lo produjo.
                }
                
            }
            catch
            {
                MessageBox.Show("Ocurrió un error.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);//Message box con distintas opciones.
            }

        }

        private void limpiar()
        {
            txtIdCategoria.Text = "";
            txtNombre.Text = "";
            errorFormulario.SetError(txtIdCategoria, "");
            errorFormulario.SetError(txtNombre, "");
        }
    }
}
