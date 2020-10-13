using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsultasLinQ.Consultas.Ejercicio_006_select_string
{
    class Empleado
    {
        public string nombreCompleto { get; set; }
        public string ciudad { get; set; }
        public double sueldo { get; set; }
    }
}
