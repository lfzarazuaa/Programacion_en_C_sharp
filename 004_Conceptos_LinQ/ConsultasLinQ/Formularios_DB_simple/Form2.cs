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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        EmpresaDataContext db = new EmpresaDataContext();
        private void Form2_Load(object sender, EventArgs e)
        {
            var consulta = from empleado in db.Empleado
                           select new
                           {
                               nombreCompleto = $"{empleado.nombre} {empleado.apellidoPaterno} {empleado.apellidoMaterno}",
                               Edad = empleado.edad,
                               EdadFutura = empleado.edad + 10
                           };
            dgvEmpleado.DataSource = consulta.ToList();
            string[] titulos = new string[] { "Nombre Completo", "Edad", "Edad Futura" };
            for (int i = 0; i < dgvEmpleado.ColumnCount; i++)
            {
                dgvEmpleado.Columns[i].HeaderCell.Value = titulos[i];
            }
        }
    }
}
