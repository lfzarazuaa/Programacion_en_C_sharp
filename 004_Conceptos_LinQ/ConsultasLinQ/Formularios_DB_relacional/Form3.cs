using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_DB_relacional
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        NorthwindDataContext db = new NorthwindDataContext();
        private void Form3_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void Listar()
        {
            dgvRegion.DataSource = db.Region.OrderBy(r => r.RegionID).ToList<Region>();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);

                bool existeId = db.Region.Where(p => p.RegionID.Equals(id)).Any();

                if (existeId)
                {
                    MessageBox.Show("El Id ya existe.");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Hubo un problema con el Id.");
                return;
            }

            int idn = int.Parse(txtId.Text);
            string nombre = txtNombre.Text;

            Region reg = new Region { RegionID = idn, RegionDescription = nombre };
            //Preparar
            db.Region.InsertOnSubmit(reg);
            try
            {
                //Insertar en la base de datos
                db.SubmitChanges();
                Listar();
                MessageBox.Show("Se agregó correctamente.");
            }
            catch
            {
                MessageBox.Show("Ocurrió un error.");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNombre.Text = "";
        }
    }
}
