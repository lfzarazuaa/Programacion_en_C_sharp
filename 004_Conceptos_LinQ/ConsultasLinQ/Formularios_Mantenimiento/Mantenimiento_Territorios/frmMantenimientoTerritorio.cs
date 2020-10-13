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
    public partial class frmMantenimientoTerritorio : Form
    {
        public frmMantenimientoTerritorio()
        {
            InitializeComponent();
        }
        NorthwindDataContext db = new NorthwindDataContext();
        ErrorProv errorProvider;
        private void frmMantenimientoTerritorio_Load(object sender, EventArgs e)
        {
            errorProvider = new ErrorProv(errorData);
            Listar();
        }

        private void Listar()
        {
            dgvTerritorios.DataSource = db.Territories.Where(t => t.bitHabilitado.Equals(true)).Select(t =>
                         new { t.TerritoryID, t.TerritoryDescription, t.Region.RegionDescription }).ToList();
        }
        #region Menu Bar
        private void ActualizarListado(frmPopupTerritorio ofrmPopupTerritorio)
        {
            bool opcionPopMenu = ofrmPopupTerritorio.DialogResult.Equals(DialogResult.OK);
            if (opcionPopMenu)
            {
                Listar();
            }
        }
        private void menuNuevo_Click(object sender, EventArgs e)
        {
            frmPopupTerritorio ofrmPopupTerritorio = new frmPopupTerritorio();
            //Asignar valor de acción (Agregar o Editar)
            ofrmPopupTerritorio.accion = "Nuevo";
            ofrmPopupTerritorio.ShowDialog();
            ActualizarListado(ofrmPopupTerritorio);
        }

        private void menuEditar_Click(object sender, EventArgs e)
        {
            //Verificar un ID seleccionado.
            if (VerificarIdSeleccionado())
            {
                return;
            }

            //Editar territorio
            frmPopupTerritorio ofrmPopupTerritorio = new frmPopupTerritorio();
            //Asignar valor de acción (Agregar o Editar)
            ofrmPopupTerritorio.accion = "Editar";
            ofrmPopupTerritorio.id = id;
            ofrmPopupTerritorio.ShowDialog();
            ActualizarListado(ofrmPopupTerritorio);
        }
        private void menuEliminar_Click(object sender, EventArgs e)
        {
            //Verificar un ID seleccionado.
            if (VerificarIdSeleccionado()) 
            {
                return;
            }
            var Opcion = MessageBox.Show("¿Desea eliminar el territorio?", "Aviso", MessageBoxButtons.YesNo);
            if (Opcion.Equals(DialogResult.Yes))
            {
                var territorio = db.Territories.Where(t => t.TerritoryID.Equals(id)).FirstOrDefault();
                territorio.bitHabilitado = false;
                try
                {
                    //Actualizar la base de datos
                    db.SubmitChanges();
                    Listar();
                    MessageBox.Show("Territorio eliminado correctamente.");
                }
                catch
                {
                    MessageBox.Show("Ocurrió un error.");
                }
            }  
        }

        private bool VerificarIdSeleccionado()
        {
            errorProvider.InitializeError();//Limpia los errores pasados.
            if (String.IsNullOrWhiteSpace(id))
            {
                errorProvider.SetError(dgvTerritorios, "Seleccionar ID dando clic en fila.");
            }
            if (errorProvider.GetError())
            {
                MessageBox.Show("Seleccionar un ID primero");
                return true;
            }
            return false;
        }
        #endregion
        private void FiltrarTerritorio(object sender, EventArgs e)
        {
            dgvTerritorios.DataSource = db.Territories
                .Where(t => t.bitHabilitado.Equals(true) && t.TerritoryDescription.Contains(txtNombre.Text))
                .Select(t =>
                         new { t.TerritoryID, t.TerritoryDescription, t.Region.RegionDescription })
                .ToList();
        }
        string id = "";
        private void ObtenerID(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider.InitializeError();//Limpia los errores pasados.
            id = (string) dgvTerritorios.CurrentRow.Cells[0].Value;
        }

        private void menuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
