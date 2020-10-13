using Formularios_LinQ.Formulario_2;
using Formularios_LinQ.Formulario_3;
using Formularios_LinQ.Formulario_4;
using Formularios_LinQ.Formulario_5;
using Formularios_LinQ.Formulario_6;
using Formularios_LinQ.Tareas.Ejercicio_01;
using Formularios_LinQ.Tareas.Ejercicio_02;
using Formularios_LinQ.Tareas.Ejercicio_03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_LinQ
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Formulario3());//Nombre de formulario a ejecutar.
        }
    }
}
