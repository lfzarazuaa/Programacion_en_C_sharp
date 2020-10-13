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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        NorthwindDataContext db = new NorthwindDataContext();
        private void Form3_Load(object sender, EventArgs e)
        {
            //Mostrar regiones.
            cboRegion.DataSource = db.Region;
            cboRegion.DisplayMember = "RegionDescription";
            cboRegion.ValueMember = "RegionID";

            //Desplegar territorios.
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

        bool bError = false;

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //Validación.
            errorTerritorio.Clear();//Limpiar Errores.
            bError = false;
            
            if (String.IsNullOrWhiteSpace(txtID.Text))
            {
                setError(txtID, "Rellenar código de Territorio");
            }
            string id = txtID.Text;
            bool existeId = db.Territories.Where(t => t.TerritoryID.Equals(id)).Any();
            if (existeId)
            {
                setError(txtID, "El código del territorio ya existe.");
            }

            string Nombre = txtNombre.Text;
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                setError(txtNombre, "Rellenar el nombre del territorio.");
            }

            bool existeTerritorio = db.Territories.Where(t => t.TerritoryDescription.Equals(Nombre)).Any();
            if (existeTerritorio)
            {
                setError(txtNombre, "Este territorio ya fue registrado.");
            }
            if (bError) { return; }
            // Consultar registro.
            var territorio = new Territories { 
                TerritoryID = id.ToString(),
                TerritoryDescription= Nombre,
                RegionID = (int)cboRegion.SelectedValue,
            };
            db.Territories.InsertOnSubmit(territorio);
            try
            {
                //Insertar registro en base datos.
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
