using System;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;

namespace Formularios_Mantenimiento.Mantenimiento_Empleado
{
    public partial class frmPopupEmpleado : Form
    {
        public string accion { get; set; }
        public string id { get; set; }
        public frmPopupEmpleado()
        {
            InitializeComponent();
        }
        NorthwindDataContext db = new NorthwindDataContext();
        ErrorProv errorProvider;
        private void frmPopupEmpleado_Load(object sender, EventArgs e)
        {
            errorProvider = new ErrorProv(errorData);
            if (!accion.Equals("Nuevo"))
            {
                var empleado = db.Employees.Where(em => em.EmployeeID.Equals(id)).Single();
                txtNombre.Text = empleado.FirstName;
                txtApellidos.Text = empleado.LastName;
                txtDirección.Text = empleado.Address;
                txtFecha.Value = (DateTime)empleado.BirthDate;
                txtTitulo.Text = empleado.Title;
            }
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            errorProvider.InitializeError();//Lia errores pasados.
            if (string.IsNullOrWhiteSpace( txtCódigo.Text))
            {
                errorProvider.SetError(txtCódigo, "Ingrese código");
            }
            if (!int.TryParse(txtCódigo.Text, out var n))
            {
                errorProvider.SetError(txtCódigo, "Ingrese código númerico de maximo 10 dígitos.");
            }
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider.SetError(txtNombre, "Ingrese nombre del empleado");
            }
            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                errorProvider.SetError(txtApellidos, "Ingrese apellidos del empleado");
            }
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                errorProvider.SetError(txtTitulo, "Ingrese título del empleado");
            }
            if (errorProvider.GetError())
            {
                this.DialogResult = DialogResult.None;
                return;
            }
            //Insertar un nuevo dato.
            int Código = Convert.ToInt32(txtCódigo.Text);
            string Nombre = txtNombre.Text;
            string Apellidos = txtApellidos.Text;
            string Dirección = txtDirección.Text;
            string Título = txtTitulo.Text;
            DateTime Fecha = txtFecha.Value;

            if (accion.Equals("Nuevo"))
            {
                Employees empleado = new Employees
                {
                    EmployeeID = Código,
                    FirstName = Nombre,
                    LastName = Apellidos,
                    Address = Dirección,
                    BirthDate = Fecha,
                    Title = Título,
                    bitHabilitado=true
                };
                try
                {
                    //Agregar
                    db.Employees.InsertOnSubmit(empleado);
                    //Actualizar en base de datos
                    db.SubmitChanges();
                    MessageBox.Show("Empleado agregado correctamente.", "Insertar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ocurrió un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var empleado = db.Employees.Where(em => em.EmployeeID.Equals(id)).Single();
                empleado.FirstName = Nombre;
                empleado.LastName = Apellidos;
                empleado.Address = Dirección;
                empleado.BirthDate = Fecha;
                empleado.Title = Título;
                try
                {
                    //Actualizar en base de datos
                    db.SubmitChanges();
                    MessageBox.Show("Empleado actualizado correctamente.", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ocurrió un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
