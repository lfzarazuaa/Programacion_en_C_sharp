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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        EmpresaDataContext db = new EmpresaDataContext();
        private void Form3_Load(object sender, EventArgs e)
        {
            var consulta = db.Empleado;
            dgvEmpleado.DataSource = consulta.ToList();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            var consulta = db.Empleado.Where(emp => emp.nombre.Equals(txtNombre.Text));
            dgvEmpleado.DataSource = consulta.ToList();
        }
    }
}
