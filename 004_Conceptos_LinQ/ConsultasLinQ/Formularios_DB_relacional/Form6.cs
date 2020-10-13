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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        NorthwindDataContext db = new NorthwindDataContext();
        int id = 0;
        string Nombre;
        private void Form6_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void Listar()
        {
            dgvRegion.DataSource = null;
            dgvRegion.DataSource = db.Region.ToList();
        }

        private void ObtenerDato(object sender, DataGridViewCellEventArgs e)
        {
            id= (int) dgvRegion.CurrentRow.Cells[0].Value;
            txtID.Text = id.ToString();
            Nombre = (string)dgvRegion.CurrentRow.Cells[1].Value;
            txtNombre.Text = Nombre;
        }

        bool bError = false;
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Validación.
            errorRegion.Clear();//Limpiar Errores.
            bError = false;
            if (id.Equals(0))
            {
                setError(txtID, "Seleccionar ID(dar click en el id de la tabla).");
            }
            Nombre = txtNombre.Text;
            if (String.IsNullOrWhiteSpace(Nombre))
            {
                setError(txtNombre, "Rellenar el campo.");
            }
            if (bError){ return; }
            // Consultar registro.
            var region = db.Region.Where(r => r.RegionID.Equals(id)).ToList().FirstOrDefault();
            try
            {
                //Actualizar registro en memoria.
                region.RegionDescription = Nombre;
                //Actualizar registro en base datos.
                db.SubmitChanges();
                //Listar registros.
                Listar();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error.");
            }
        }

        private void setError(Control control, string mensaje)
        {
            errorRegion.SetError(control, mensaje);
            bError = true;
        }
    }
}
