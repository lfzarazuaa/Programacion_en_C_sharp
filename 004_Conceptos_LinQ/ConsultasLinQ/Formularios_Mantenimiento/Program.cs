using Formularios_Mantenimiento.Mantenimiento_Empleado;
using Formularios_Mantenimiento.Mantenimiento_Productos;
using Formularios_Mantenimiento.Mantenimiento_Territorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_Mantenimiento
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMantenimientoProducto());
        }
    }
}
