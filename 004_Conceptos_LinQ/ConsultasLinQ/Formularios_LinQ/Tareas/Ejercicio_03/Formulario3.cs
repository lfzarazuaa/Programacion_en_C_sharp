using Formularios_LinQ.Tareas.Ejercicio_01;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Formularios_LinQ.Tareas.Ejercicio_03
{
    public partial class Formulario3 : Form
    {
        public Formulario3()
        {
            InitializeComponent();
        }
        List<Empleado> listaEmpleado;
        List<Modalidad> listaModalidad;
        private void Formulario3_Load(object sender, EventArgs e)
        {
            listaModalidad = new List<Modalidad>()
            {
                new Modalidad(){idModalidad=0 , nombre="Todos los elementos"},
                new Modalidad(){idModalidad=1 , nombre="CAS"},
                new Modalidad(){idModalidad=2 , nombre="Temporal"},
                new Modalidad(){idModalidad=3 , nombre="Plazo Indeterminado"}
            };

            listaEmpleado = new List<Empleado>
            {
                new Empleado(){idEmpleado=1 , nombre="Felipe" , apellidos="Contreras", idModalidad=1},
                new Empleado(){idEmpleado=2 , nombre="Josue" , apellidos="Lopez", idModalidad=2},
                new Empleado(){idEmpleado=3 , nombre="Enrique" , apellidos="Valle", idModalidad=2},
                new Empleado(){idEmpleado=4 , nombre="Carmen" , apellidos="Rojas", idModalidad=1},
                new Empleado(){idEmpleado=5 , nombre="Ricardo" , apellidos="Garma", idModalidad=3},
                new Empleado(){idEmpleado=6 , nombre="Rolando" , apellidos="Minchan", idModalidad=3}
            };

            cboModalidad.DataSource = listaModalidad;
            cboModalidad.DisplayMember = "nombre";
            cboModalidad.ValueMember = "idModalidad";

            var empleados = (from empleado in listaEmpleado
                            join modalidad in listaModalidad
                            on empleado.idModalidad equals modalidad.idModalidad
                            select new { empleado.idEmpleado, empleado.nombre, empleado.apellidos, modalidad.idModalidad,nombreModalidad = modalidad.nombre })
                            .ToList();

            dgvEmpleado.DataSource = empleados;
        }

        private void FiltradoModalidad(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cboModalidad.SelectedValue.ToString());
            var empleados = (from empleado in listaEmpleado
                             join modalidad in listaModalidad
                             on empleado.idModalidad equals modalidad.idModalidad
                             where id==0 || empleado.idModalidad==id
                             select new { empleado.idEmpleado, empleado.nombre, empleado.apellidos, modalidad.idModalidad, nombreModalidad = modalidad.nombre })
                            .ToList();

            dgvEmpleado.DataSource = empleados;
        }
    }
}
