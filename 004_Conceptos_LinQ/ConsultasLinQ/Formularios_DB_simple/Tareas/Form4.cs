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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        EmpresaDataContext db = new EmpresaDataContext();
        private void Form4_Load(object sender, EventArgs e)
        {
            var consulta = db.ALUMNO.Select(p =>
               new
               {
                   Nombre = p.NOMBREALUMNO,
                   ApellidoPaterno = p.APELLIDOPATERNOALUMNO,
                   ApellidoMaterno = p.APELLIDOMATERNOALUMNO,
                   CursoFavorito = p.CURSOFAVORITO,
                   GradoAcadémico = p.NIVELACADEMICO,
                   Promedio = Convert.ToDecimal(p.NOTA1 + p.NOTA2 + p.NOTA3 + p.NOTA4) / 4
               });
            dgvAlumno.DataSource = consulta.ToList();
        }

        private void FiltrarGradoAcadémico(object sender, EventArgs e)
        {
            var consulta = db.ALUMNO.Where(a => a.NIVELACADEMICO.Contains(txtNivelAcadémico.Text))
                .Select(p =>
               new
               {
                   Nombre = p.NOMBREALUMNO,
                   ApellidoPaterno = p.APELLIDOPATERNOALUMNO,
                   ApellidoMaterno = p.APELLIDOMATERNOALUMNO,
                   CursoFavorito = p.CURSOFAVORITO,
                   GradoAcadémico = p.NIVELACADEMICO,
                   Promedio = Convert.ToDecimal(p.NOTA1 + p.NOTA2 + p.NOTA3 + p.NOTA4) / 4
               });

            dgvAlumno.DataSource = null;
            dgvAlumno.DataSource = consulta.ToList();
        }
    }
}
