using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_Mantenimiento.Mantenimiento_Productos
{
    public static class Mensajes
    {
        #region Mensajes CRUD
        public static void RecursoCreado(string mensaje = "Recurso agregado correctamente.", string titulo = "Agregar")
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        public static void RecursoModificado(string mensaje = "Recurso modificado correctamente.", string titulo = "Modificar")
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        public static void RecursoEliminado(string mensaje = "Recurso eliminado correctamente.", string titulo = "Eliminar")
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        public static bool EliminarRecurso(string mensaje="¿Desea eliminar el recurso?",string titulo="Eliminar" )
        {
            var Opcion = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return Opcion.Equals(DialogResult.Yes);
        }

        public static void Error(string mensaje="Ocurrió un error.",string titulo="Error" )
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        #endregion
        public static bool ExistenRecursosActivos(DataGridView dgvData, string mensaje = "No se encontraron recursos activos. Agregue uno nuevo.", string titulo = "Aviso")
        {
            if (dgvData.CurrentRow == null)
            {
                MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }
    }
}
