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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        EmpresaDataContext db = new EmpresaDataContext();
        private void Form4_Load(object sender, EventArgs e)
        {
            var consulta = db.Empleado;
            dgvEmpleado.DataSource = consulta.ToList();
        }

        private void Filtrar_Nombre(object sender, EventArgs e)
        {
            var consulta = db.Empleado.Where(emp => emp.nombre.Contains(txtNombre.Text));
            dgvEmpleado.DataSource = consulta.ToList();
        }
    }
}
