using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_DB_simple.Tareas
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
            var consulta = db.ALUMNO.Select(p =>
               new
               {
                   NombreCompleto = $"{p.NOMBREALUMNO} {p.APELLIDOPATERNOALUMNO} {p.APELLIDOMATERNOALUMNO}",
                   Promedio = Convert.ToDecimal(p.NOTA1 + p.NOTA2 + p.NOTA3 + p.NOTA4)/4
               });
            dgvAlumno.DataSource = consulta.ToList();
        }
    }
}
