using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_DB_relacional.Tareas
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        NorthwindDataContext db = new NorthwindDataContext();
        private void Form4_Load(object sender, EventArgs e)
        {
            //Mostrar regiones.
            cboRegion.DataSource = db.Region;
            cboRegion.DisplayMember = "RegionDescription";
            cboRegion.ValueMember = "RegionID";

            //Desplegar productos.
            Listar();
        }

        private void Listar()
        {
            var consulta = from territorio in db.Territories
                           join region in db.Region on territorio.RegionID equals region.RegionID
                           select new
                           {
                               Código = territorio.TerritoryID,
                               Nombre = territorio.TerritoryDescription,
                               Region = region.RegionDescription
                           };
            dgvTerritorios.DataSource = consulta.ToList();
        }
        string id = "";
        private void ObtenerDatos(object sender, DataGridViewCellEventArgs e)
        {
            errorTerritorio.Clear();//Limpiar Errores.
            id = (string) dgvTerritorios.CurrentRow.Cells[0].Value;
            txtID.Text = id;
            txtNombre.Text = (string)dgvTerritorios.CurrentRow.Cells[1].Value;
            //Obtener id de categoria para combo box region.
            string region = (string) dgvTerritorios.CurrentRow.Cells[2].Value;
            cboRegion.SelectedValue = db.Region.Where(r => r.RegionDescription.Equals(region)).Select(r => r.RegionID).FirstOrDefault();
        }
        bool bError = false;
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Validación.
            errorTerritorio.Clear();//Limpiar Errores.
            bError = false;
            if (string.IsNullOrWhiteSpace(id))
            {
                setError(txtID, "Seleccionar Código(dar click en el código de la tabla).");
            }

            string Nombre = txtNombre.Text;
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                setError(txtNombre, "Ingresar nombre de territorio.");
            }
            bool existeTerritorio = db.Territories.Where(t => t.TerritoryDescription.Equals(Nombre) && t.TerritoryID!=id).Any();
            if (existeTerritorio)
            {
                setError(txtNombre, "El territorio ya está registrado.");
            }
            if (bError) { return; }
            // Consultar registro.
            var territorio = db.Territories.Where(t => t.TerritoryID.Equals(id)).ToList().FirstOrDefault();
            try
            {
                //Actualizar registro en memoria.
                territorio.TerritoryDescription = Nombre;
                territorio.RegionID = (int)cboRegion.SelectedValue;
                //Actualizar registro en base datos.
                db.SubmitChanges();
                //Listar registros.
                Listar();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error.");
            }
        }

        private void Limpiar()
        {
            id = "";//Resetear Id.
            txtID.Text = "";
            txtNombre.Text = "";
            cboRegion.SelectedIndex = 0;
        }

        private void setError(Control control, string mensaje)
        {
            errorTerritorio.SetError(control, mensaje);
            bError = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
