using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_DB_simple
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        EmpresaDataContext db = new EmpresaDataContext();
        private void Form6_Load(object sender, EventArgs e)
        {
            dgvEmpleado.DataSource = db.Empleado;
            cboOpcion.Items.AddRange(new object[] {
            "Id",
            "Nombre",
            "Apellido Paterno",
            "Apellido Materno"});
            cboOpcion.SelectedIndex = 0;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string texto = txtValor.Text;
            List<Empleado> consulta;
            switch (cboOpcion.SelectedItem)
            {
                case "Id":
                    consulta = db.Empleado.Where(c => c.codigo.Contains(texto)).ToList();
                    break;
                case "Nombre":
                    consulta = db.Empleado.Where(c => c.nombre.Contains(texto)).ToList();
                    break;
                case "Apellido Paterno":
                    consulta = db.Empleado.Where(c => c.apellidoPaterno.Contains(texto)).ToList();
                    break;
                case "Apellido Materno":
                    consulta = db.Empleado.Where(c => c.apellidoMaterno.Contains(texto)).ToList();
                    break;
                default:
                    consulta = db.Empleado.ToList();
                    break;
            }
            dgvEmpleado.DataSource = null;
            dgvEmpleado.DataSource = consulta;
        }
    }
}
