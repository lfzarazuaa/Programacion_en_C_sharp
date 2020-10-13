using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_DB_simple.Tareas
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
            var consulta = db.ALUMNO.Select(p =>
               new
               {
                   Nombre = $"{p.NOMBREALUMNO} {p.APELLIDOPATERNOALUMNO} {p.APELLIDOMATERNOALUMNO}",
                   SumaDeNotas = p.NOTA1 + p.NOTA2 + p.NOTA3 + p.NOTA4
               });
            dgvAlumno.DataSource = consulta.ToList();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            bool condicion = txtRango1.Value >= txtRango2.Value;
            int numeroMenor = Convert.ToInt32(condicion ? txtRango2.Value : txtRango1.Value);
            int numeroMayor = Convert.ToInt32(condicion ? txtRango1.Value : txtRango2.Value);
            var consulta = db.ALUMNO
               .Where(delegate (ALUMNO alumno)
               {
                   var suma = alumno.NOTA1 + alumno.NOTA2 + alumno.NOTA3 + alumno.NOTA4;
                   return suma >= numeroMenor && suma <= numeroMayor;
               })
               .Select(p =>
               new
               {
                   Nombre = $"{p.NOMBREALUMNO} {p.APELLIDOPATERNOALUMNO} {p.APELLIDOMATERNOALUMNO}",
                   SumaDeNotas = p.NOTA1 + p.NOTA2 + p.NOTA3 + p.NOTA4
               }) ;
            dgvAlumno.DataSource = consulta.ToList();
        }
    }
}
