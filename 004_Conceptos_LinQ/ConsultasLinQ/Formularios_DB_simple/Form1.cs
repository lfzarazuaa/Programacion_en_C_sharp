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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EmpresaDataContext db = new EmpresaDataContext();
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvEmpleado.DataSource = db.Empleado;
        }
    }
}
