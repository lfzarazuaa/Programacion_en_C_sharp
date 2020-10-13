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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        EmpresaDataContext db = new EmpresaDataContext();
        private void Form3_Load(object sender, EventArgs e)
        {
            var consulta = db.ALUMNO.Select(p =>
               new
               {
                   Id = p.IDALUMNO,
                   Nombre = $"{p.NOMBREALUMNO} {p.APELLIDOPATERNOALUMNO} {p.APELLIDOMATERNOALUMNO}",
                   Nota1 = p.NOTA1,
                   Nota2 = p.NOTA2,
                   Nota3 = p.NOTA3,
                   Nota4 = p.NOTA4,
               });
            dgvAlumno.DataSource = consulta.ToList();
        }

        private void FiltrarIdAlumno(object sender, EventArgs e)
        {
            var consulta = db.ALUMNO.Where(p=> p.IDALUMNO.ToString().Contains(txtIdAlumno.Text))
               .Select(p =>
               new
               {
                   Id = p.IDALUMNO,
                   Nombre = $"{p.NOMBREALUMNO} {p.APELLIDOPATERNOALUMNO} {p.APELLIDOMATERNOALUMNO}",
                   Nota1 = p.NOTA1,
                   Nota2 = p.NOTA2,
                   Nota3 = p.NOTA3,
                   Nota4 = p.NOTA4,
               });
            dgvAlumno.DataSource = null;
            dgvAlumno.DataSource = consulta.ToList();
        }
    }
}
