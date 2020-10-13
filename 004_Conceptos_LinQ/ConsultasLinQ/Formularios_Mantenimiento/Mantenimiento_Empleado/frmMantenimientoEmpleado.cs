using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_Mantenimiento.Mantenimiento_Empleado
{
    public partial class frmMantenimientoEmpleado : Form
    {
        public frmMantenimientoEmpleado()
        {
            InitializeComponent();
        }

        NorthwindDataContext db = new NorthwindDataContext();
        private void frmMantenimientoEmpleado_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void Listar()
        {
            dgvEmpleados.DataSource = null;
            using (var bd = new NorthwindDataContext())
            {
                var consulta = bd.Employees.Where(em => em.bitHabilitado == true && em.FirstName.Contains(txtNombre.Text)).ToList();
                dgvEmpleados.DataSource = consulta;
            };
        }
        private void ActualizarListado(frmPopupEmpleado ofrmPopupEmpleado)
        {
            bool opcionPopMenu = ofrmPopupEmpleado.DialogResult.Equals(DialogResult.OK);
            if (opcionPopMenu)
            {
                Listar();
            }
        }
        #region Menus
        private void menuNuevo_Click(object sender, EventArgs e)
        {
            frmPopupEmpleado ofrmPopupEmpleado = new frmPopupEmpleado();
            ofrmPopupEmpleado.accion = "Nuevo";
            ofrmPopupEmpleado.ShowDialog();
            ActualizarListado(ofrmPopupEmpleado);
        }

        private void menuEditar_Click(object sender, EventArgs e)
        {
            if (ExistenEmpleadosActivos())
            {
                return;
            }
            frmPopupEmpleado ofrmPopupEmpleado = new frmPopupEmpleado();
            ofrmPopupEmpleado.accion = "Editar";
            ofrmPopupEmpleado.id = dgvEmpleados.CurrentRow.Cells[0].Value.ToString();
            ofrmPopupEmpleado.txtCódigo.ReadOnly = true;
            ofrmPopupEmpleado.txtCódigo.Text = ofrmPopupEmpleado.id.ToString();
            ofrmPopupEmpleado.ShowDialog();
            ActualizarListado(ofrmPopupEmpleado);
        }

        private void menuEliminar_Click(object sender, EventArgs e)
        {
            if (ExistenEmpleadosActivos())
            {
                return;
            }
            string id = dgvEmpleados.CurrentRow.Cells[0].Value.ToString();
            var Opcion = MessageBox.Show("¿Desea eliminar al empleado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Opcion.Equals(DialogResult.Yes))
            {
                var empleado = db.Employees.Where(em => em.EmployeeID.Equals(id)).Single();
                empleado.bitHabilitado = false;
                try
                {
                    db.SubmitChanges();
                    Listar();
                    MessageBox.Show("Empleado eliminado correctamente.", "Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ocurrió un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void menuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void FiltrarNombre(object sender, EventArgs e)
        {
            Listar();
        }

        private bool ExistenEmpleadosActivos()
        {
            if (dgvEmpleados.CurrentRow == null)
            {
                MessageBox.Show("No se encontraron empleados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }
    }
}
