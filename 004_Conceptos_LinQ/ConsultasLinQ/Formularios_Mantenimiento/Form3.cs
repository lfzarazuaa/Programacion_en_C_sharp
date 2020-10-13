using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_Mantenimiento
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
            dgvRegion.DataSource = db.Region.Where(r=>r.bitHabilitado.Equals(true)).Select(r=>new {
                RegionID=r.RegionID,
                Region=r.RegionDescription
            }).ToList();
        }

        int id = 0;
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (id.Equals(0))
            {
                MessageBox.Show("Seleccionar una región primero en la tabla.");
                return;
            }
            var Opcion = MessageBox.Show("¿Desea eliminar la región?", "Aviso", MessageBoxButtons.YesNo);
            if (Opcion.Equals(DialogResult.Yes))
            {
                //Obtiene registro a eliminar
                var region = db.Region.Where(r => r.RegionID.Equals(id)).FirstOrDefault();
                try
                {
                    region.bitHabilitado = false;
                    //Actualiza el registro dejandolo inactivo logicamente.
                    db.SubmitChanges();
                    //Actualizar la tabla
                    Listar();
                    id = 0;
                    MessageBox.Show("Región eliminada.");
                }
                catch
                {
                    MessageBox.Show("Ha ocurrido un error.");
                }
            }
        }

        private void ObtenerDato(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dgvRegion.CurrentRow.Cells[0].Value;
        }
    }
}
