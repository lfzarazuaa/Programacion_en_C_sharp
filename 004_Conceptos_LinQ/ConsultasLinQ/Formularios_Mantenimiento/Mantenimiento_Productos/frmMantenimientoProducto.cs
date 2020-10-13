using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_Mantenimiento.Mantenimiento_Productos
{
    public partial class frmMantenimientoProducto : Form
    {
        public frmMantenimientoProducto()
        {
            InitializeComponent();
        }
        NorthwindDataContext db = new NorthwindDataContext();
        /// <summary>
        /// Listar los elementos en una Tabla.
        /// </summary>
        private void Listar()
        {
            //Crear una conexión a la base de datos.
            using (var db= new NorthwindDataContext())
            {
                //Consulta para obtener los registros a listar.
                var productos = from producto in db.Products
                               where producto.bitHabilitado.Equals(true) && producto.ProductName.Contains(txtNombre.Text)
                               select new
                               {
                                   Id = producto.ProductID,
                                   Producto = producto.ProductName,
                                   Categoria = producto.Categories.CategoryName,
                                   Proveedor = producto.Suppliers.CompanyName
                               };
                //Mostrar en DataGridView los productos.
                dgvProducto.DataSource = productos.ToList();
            }
        }
        /// <summary>
        /// Muestra los elementos al cargar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMantenimientoProducto_Load(object sender, EventArgs e)
        {
            Listar();
        }

        #region Eventos de Menú
        /// <summary>
        /// Agregar nuevo registro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuNuevo_Click(object sender, EventArgs e)
        {
            frmPopupProducto ofrmPopupProducto = new frmPopupProducto(AccionPopup.Nuevo,"0");
            ofrmPopupProducto.ShowDialog();
            Listar();
        }
        /// <summary>
        /// Editar un registro existente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEditar_Click(object sender, EventArgs e)
        {
            //Mostrar mensaje si no hay datos registrados.
            if (Mensajes.ExistenRecursosActivos(dgvProducto)) { return; }
            //Obtener id para modificar el recurso.
            string id = dgvProducto.CurrentRow.Cells[0].Value.ToString();
            frmPopupProducto ofrmPopupProducto = new frmPopupProducto(AccionPopup.Editar, id);
            ofrmPopupProducto.ShowDialog();
            Listar();
        }
        /// <summary>
        /// Eliminar un registro existente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuEliminar_Click(object sender, EventArgs e)
        {
            //Mostrar mensaje si no hay datos registrados.
            if (Mensajes.ExistenRecursosActivos(dgvProducto)) { return; }
            //Obtener id para eliminar el recurso.
            string id = dgvProducto.CurrentRow.Cells[0].Value.ToString();
            if (Mensajes.EliminarRecurso())
            {
                //Obtener recurso a eliminar.
                var producto = db.Products.Where(p => p.ProductID.Equals(id)).Single();
                //Eliminación lógica.
                producto.bitHabilitado = false;
                try
                {
                    //Actualizar en la base de datos.
                    db.SubmitChanges();
                    //Actualizar en pantalla.
                    Listar();
                    Mensajes.RecursoEliminado("Producto eliminado correctamente.");
                }
                catch (Exception)
                {
                    //Mostrar mensaje de error.
                    Mensajes.Error();
                }
            }
        }
        /// <summary>
        /// Salir de la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
        /// <summary>
        /// Filtar la lista conforme al nombre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FiltrarProducto(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
