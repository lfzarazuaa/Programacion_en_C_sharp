using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Formularios_LinQ.Tareas.Ejercicio_01
{
    public partial class Formulario1 : Form
    {
        public Formulario1()
        {
            InitializeComponent();
        }
        List<Empleado> listaEmpleado;
        private void Formulario1_Load(object sender, EventArgs e)
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

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                //Validación
                bool validacion = false;
                LimpiarErrorProvider();
                if (txtId.Text.Equals(""))
                {
                    validacion = true;
                    errorFormulario.SetError(txtId, "Ingresar Id del empleado");//Crea mensaje de error señalando el elemento que lo produjo.
                }
                if (txtNombre.Text.Equals(""))
                {
                    validacion = true;
                    errorFormulario.SetError(txtNombre, "Ingresar nombre del Empleado.");//Crea mensaje de error señalando el elemento que lo produjo.
                }
                if (txtApellidos.Text.Equals(""))
                {
                    validacion = true;
                    errorFormulario.SetError(txtApellidos, "Ingresar apellidos del Empleado.");//Crea mensaje de error señalando el elemento que lo produjo.
                }
                if (validacion)
                {
                    return;
                }
                //Guardar Valores
                int id = int.Parse(txtId.Text.ToString());
                string nombre = txtNombre.Text;
                string apellidos = txtApellidos.Text;

                //Agregar Empleado a lista
                listaEmpleado.Add(new Empleado() { idEmpleado = id, nombre = nombre, apellidos = apellidos, idModalidad = 0 });

                //Quitar errores de la interfaz.
                LimpiarErrorProvider();

                //Realizar consulta.
                var empleados = listaEmpleado.Select(e => new { e.idEmpleado, e.nombre, e.apellidos }).ToList();

                //Actualizar Data Grid View
                dgvEmpleado.DataSource = null;
                dgvEmpleado.DataSource = empleados;
            }
            catch
            {
                MessageBox.Show("Ocurrió un error.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);//Message box con distintas opciones.
            }
        }

        private void LimpiarErrorProvider()
        {
            errorFormulario.SetError(txtId, "");
            errorFormulario.SetError(txtNombre, "");
            errorFormulario.SetError(txtApellidos, "");
        }
    }
}
