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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        EmpresaDataContext db = new EmpresaDataContext();
        private void Form5_Load(object sender, EventArgs e)
        {
            listarTodo();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            decimal[] numeros= new decimal[] { txtRango1.Value, txtRango2.Value };
            var numerosOrdenados = numeros.OrderBy(n => n).Select(n => Convert.ToInt32(n)).ToArray();
            int numeroMenor = numerosOrdenados[0];
            int numeroMayor = numerosOrdenados[1];
            var consulta = db.Empleado.Where(n=>n.edad>=numeroMenor && n.edad<=numeroMayor).ToList();
            
            dgvEmpleado.DataSource = null;
            dgvEmpleado.DataSource = consulta;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            listarTodo();
            txtRango1.Value = 0;
            txtRango2.Value = 0;
        }
        private void listarTodo()
        {
            var consulta = db.Empleado;
            dgvEmpleado.DataSource = consulta;
        }
    }
}
