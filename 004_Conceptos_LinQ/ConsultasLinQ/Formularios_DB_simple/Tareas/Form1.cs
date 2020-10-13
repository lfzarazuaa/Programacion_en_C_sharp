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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EmpresaDataContext db = new EmpresaDataContext();
        private void Form1_Load(object sender, EventArgs e)
        {
            var consulta = db.ALUMNO.Select( p =>
                new
                {
                    NombreCompleto = $"{p.NOMBREALUMNO} {p.APELLIDOPATERNOALUMNO} {p.APELLIDOMATERNOALUMNO}",
                    CursoFavorito = p.CURSOFAVORITO,
                    NivelAcadémico = p.NIVELACADEMICO
                });
            dgvAlumno.DataSource = consulta.ToList();
        }
    }
}
