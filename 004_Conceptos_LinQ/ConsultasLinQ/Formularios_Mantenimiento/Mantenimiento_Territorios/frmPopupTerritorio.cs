using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_Mantenimiento.Mantenimiento_Territorios
{
    public partial class frmPopupTerritorio : Form
    {
        private string _accion;

        public string accion
        {
            get { return _accion; }
            set { _accion = value; }
        }

        public string id { get; set; }
        public frmPopupTerritorio()
        {
            InitializeComponent();
        }
        NorthwindDataContext db = new NorthwindDataContext();
        ErrorProv errorProvider;
        private void frmPopupTerritorio_Load(object sender, EventArgs e)
        {
            //Cargar combo box con las regiones.
            cboRegión.DataSource = db.Region.ToList();
            cboRegión.ValueMember = "RegionID";
            cboRegión.DisplayMember = "RegionDescription";

            //Seleccionar comportamiento de formulario.
            this.Text = _accion.Equals("Nuevo") ? "Ingrese nuevo territorio" : "Editar territorio";
            if (!_accion.Equals("Nuevo"))
            {
                //Bloquear controles.
                txtID.ReadOnly = true;
                txtID.Enabled = false;
                //Consultar datos del territorio.
                var territorio = db.Territories.Where(t => t.TerritoryID.Equals(id)).FirstOrDefault();
                txtID.Text = territorio.TerritoryID;
                txtTerritorio.Text = territorio.TerritoryDescription;
                cboRegión.SelectedValue = territorio.RegionID;
            }

            //Crear errorProvider
            errorProvider = new ErrorProv(errorData);
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProvider.InitializeError();//Limpia los errores pasados.
            if (_accion.Equals("Nuevo"))
            {
                AgregarTerritorio();
            }
            else
            {
                EditarTerritorio();
            }
        }

        private void AgregarTerritorio()
        {
            string id = txtID.Text;
            if (string.IsNullOrWhiteSpace(id))
            {
                errorProvider.SetError(txtID, "Ingrese Id correcta.");
            }
            bool existeID = db.Territories.Where(t => t.TerritoryID.Equals(id)).Any();
            if (existeID)
            {
                errorProvider.SetError(txtID, "El ID ya está registrado.");
            }
            string nombre = txtTerritorio.Text;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                errorProvider.SetError(txtTerritorio, "Ingrese nombre de territorio.");
            }
            bool existeTerritorio = db.Territories.Where(t => t.TerritoryDescription.Equals(nombre)).Any();
            if (existeTerritorio)
            {
                errorProvider.SetError(txtTerritorio, "El nombre del territorio ya está registrado.");
            }
            if (errorProvider.GetError())
            {
                this.DialogResult = DialogResult.None;//Impide que la ventana se cierre por causa del botón aceptar.
                return;
            }
            int regionid = (int)cboRegión.SelectedValue;
            Territories territorio = new Territories
            {
                TerritoryID = id,
                TerritoryDescription = nombre,
                RegionID = regionid,
                bitHabilitado = true
            };
            //Agregar territorio nuevo al datacontext.
            db.Territories.InsertOnSubmit(territorio);
            try
            {
                //Actualizar la base de datos.
                db.SubmitChanges();
                MessageBox.Show("Territorio agregado correctectamente.");
            }
            catch
            {
                MessageBox.Show("Ocurrió un error.");
            }
        }

        private void EditarTerritorio()
        {
            string id = txtID.Text;
            if (string.IsNullOrWhiteSpace(id))
            {
                errorProvider.SetError(txtID, "Ingrese Id correcta.");
            }
            bool existeID = db.Territories.Where(t => t.TerritoryID.Equals(id)).Any();
            if (!existeID)
            {
                errorProvider.SetError(txtID, "El ID no se encuentra registrado.");
            }
            string nombre = txtTerritorio.Text;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                errorProvider.SetError(txtTerritorio, "Ingrese nombre de territorio.");
            }
            bool existeTerritorio = db.Territories
                .Where(t => t.TerritoryDescription.Equals(nombre) && t.TerritoryID != id).Any();
            if (existeTerritorio)
            {
                errorProvider.SetError(txtTerritorio, "El nombre del territorio ya está registrado.");
            }
            if (errorProvider.GetError())
            {
                this.DialogResult = DialogResult.None;//Impide que la ventana se cierre por causa del botón aceptar.
                return;
            }
            int regionid = (int)cboRegión.SelectedValue;
            //Agregar territorio nuevo al datacontext.
            var territorio = db.Territories.Where(t => t.TerritoryID.Equals(id)).FirstOrDefault();
            territorio.TerritoryDescription = nombre;
            territorio.RegionID = regionid;
            territorio.bitHabilitado = true;
            try
            {
                //Actualizar la base de datos.
                db.SubmitChanges();
                MessageBox.Show("Territorio modificado correctectamente.");
            }
            catch
            {
                MessageBox.Show("Ocurrió un error.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
