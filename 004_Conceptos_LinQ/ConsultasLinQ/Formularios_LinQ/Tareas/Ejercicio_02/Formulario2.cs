using Formularios_LinQ.Tareas.Ejercicio_01;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Formularios_LinQ.Tareas.Ejercicio_02
{
    public partial class Formulario2 : Form
    {
        public Formulario2()
        {
            InitializeComponent();
        }
        List<Empleado> listaEmpleado;
        private void Formulario2_Load(object sender, EventArgs e)
        {
            listaEmpleado = new List<Empleado>
            {
                new Empleado(){idEmpleado=1 , nombre="Felipe" , apellidos="Contreras", idModalidad=1},
                new Empleado(){idEmpleado=2 , nombre="Josue" , apellidos="Lopez", idModalidad=2},
                new Empleado(){idEmpleado=3 , nombre="Enrique" , apellidos="Valle", idModalidad=2},
                new Empleado(){idEmpleado=4 , nombre="Carmen" , apellidos="Rojas", idModalidad=1},
                new Empleado(){idEmpleado=5 , nombre="Ricardo" , apellidos="Garma", idModalidad=3},
                new Empleado(){idEmpleado=6 , nombre="Rolando" , apellidos="Minchan", idModalidad=3}
            };

            var empleados = listaEmpleado.Select(e => new { e.idEmpleado, e.nombre, e.apellidos }).ToList();

            dgvEmpleado.DataSource = empleados;

        }

        private void FiltrarEmpleados(object sender, EventArgs e)
        {
            var empleados = (from empleado in listaEmpleado
                             where empleado.apellidos.ToUpper().Contains(txtApellidos.Text.ToUpper())
                             select new { empleado.idEmpleado, empleado.nombre, empleado.apellidos })
                             .ToList();

            dgvEmpleado.DataSource = null;
            dgvEmpleado.DataSource = empleados;

        }
    }
}
