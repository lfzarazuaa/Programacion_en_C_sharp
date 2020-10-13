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
    public partial class frmPopupProducto : Form, IFormPopup
    {

        /// <summary>
        /// Propiedad de acción.
        /// </summary>
        public AccionPopup Accion { get; set; }

        /// <summary>
        /// Propiedad de identificador único.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Asignar los valores de acción e identificador en el formulario.
        /// </summary>
        /// <param name="accion">Acción de Nuevo o Editar.</param>
        /// <param name="id">Identificador de registro.</param>
        public void IncializarPopup(AccionPopup accion, string id)
        {
            this.Accion = accion;
            this.Id = id;
        }

        /// <summary>
        /// Constructor de formulario.
        /// </summary>
        public frmPopupProducto()
        {
            InitializeComponent();
            IncializarPopup(AccionPopup.Nuevo, "0");
        }

        /// <summary>
        /// Constructor con parámetros de acción e identificador de registro.
        /// </summary>
        /// <param name="accion"></param>
        /// <param name="id"></param>
        public frmPopupProducto(AccionPopup accion, string id)
        {
            InitializeComponent();
            IncializarPopup(accion, id);
        }

        NorthwindDataContext db = new NorthwindDataContext();
        ErrorProv errorProvider;

        /// <summary>
        /// Inicializar formulario con valores del registro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPopupProducto_Load(object sender, EventArgs e)
        {
            //Objeto para crear alertas de error en formulario.
            errorProvider = new ErrorProv(errorData);
            //Actualiza los controles con los valores del registro.
            ColocarValoresEnControles();
        }
        Products producto = new Products();

        /// <summary>
        /// Realiza la operación de inserción o actualización segun la acción del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Limpiar errores pasados.
            errorProvider.InitializeError();
            //Condicional de Id vacío.
            errorProvider.HasError(String.IsNullOrWhiteSpace(txtID.Text), txtID, "Rellenar campo de Id");
            //Condicional de Producto vacío.
            errorProvider.HasError(String.IsNullOrWhiteSpace(txtNombre.Text), txtNombre, "Rellenar campo de Nombre del producto");
            if (errorProvider.GetError(this)) { return; }
            //Condicional de Id númerico.
            errorProvider.HasError(!int.TryParse(txtID.Text, out var id), txtID, "Ingrese código númerico de maximo 10 dígitos.");
            if (Accion.Equals(AccionPopup.Nuevo))
            {
                if (errorProvider.GetError(this)) { return; }
                //Condicional de Id repetido.
                var existeID = db.Products.Any(p => p.ProductID.Equals(txtID.Text));
                errorProvider.HasError(existeID, txtID, "El Id ya está registrado.");
                //Condicional de Producto repetido.
                var existeProducto = db.Products.Any(p => p.ProductName.Equals(txtNombre.Text));
                errorProvider.HasError(existeProducto, txtNombre, "El producto ya está registrado.");
                if (errorProvider.GetError(this)) { return; }
                //Agregar Recurso.
                AgregarRecurso();
            }
            else
            {
                //Condicional de Producto repetido.
                var existeProducto = db.Products.Any(p => p.ProductName == txtNombre.Text && p.ProductID != id);
                errorProvider.HasError(existeProducto, txtNombre, "El producto ya está registrado.");
                if (errorProvider.GetError(this)) { return; }
                //Editar el recurso.
                EditarRecurso();
            }
        }

        /// <summary>
        /// Actualiza los controles con los valores del registro.
        /// </summary>
        public void ColocarValoresEnControles()
        {
            //Combo box Proveedores
            var proveedores = db.Suppliers.Select(p => new { p.SupplierID, p.CompanyName });
            cboProveedor.DataSource = proveedores.ToList();
            cboProveedor.DisplayMember = "CompanyName";
            cboProveedor.ValueMember = "SupplierID";
            //Combo box Categorías
            var categorias = db.Categories.Select(c => new { c.CategoryID, c.CategoryName });
            cboCategoría.DataSource = categorias.ToList();
            cboCategoría.DisplayMember = "CategoryName";
            cboCategoría.ValueMember = "CategoryID";
            //Elegir valor actual en controles.
            if (Accion.Equals(AccionPopup.Nuevo))
            {
                this.Text = "Agregar Producto";
            }
            else
            {
                this.Text = "Modificar Producto";
                txtID.Enabled = false;
                producto = db.Products.First(p => p.ProductID.Equals(Id));
                txtID.Text = producto.ProductID.ToString();
                txtNombre.Text = producto.ProductName;
                cboProveedor.SelectedValue = producto.SupplierID;
                cboCategoría.SelectedValue = (int)producto.CategoryID;
            }
        }
        
        /// <summary>
        /// Guardar en memoria los valores de los controles.
        /// </summary>
        public void LeerValoresDeControles()
        {
            producto.ProductID = Convert.ToInt32(txtID.Text);
            producto.ProductName = txtNombre.Text;
            producto.SupplierID = (int)cboProveedor.SelectedValue;
            producto.CategoryID = (int)cboCategoría.SelectedValue;
            producto.bitHabilitado = true;
        }

        /// <summary>
        /// Método para agregar un nuevo recurso.
        /// </summary>
        public void AgregarRecurso()
        {
            //Obtener los valores de los controles.
            LeerValoresDeControles();
            //Agregar en memoria.
            db.Products.InsertOnSubmit(producto);
            try
            {
                //Actualizar en base de datos
                db.SubmitChanges();
                Mensajes.RecursoCreado();
            }
            catch
            {
                Mensajes.Error();
            }
        }
        
        /// <summary>
        /// Método para actualizar un recurso.
        /// </summary>
        public void EditarRecurso()
        {
            //Obtener los valores de los controles.
            LeerValoresDeControles();
            //Actualizar el recurso con los valores.
            var ProductoActualizar = db.Products.First(p => p.ProductID.Equals(Id));
            ProductoActualizar.ProductName = producto.ProductName;
            ProductoActualizar.CategoryID = producto.CategoryID;
            ProductoActualizar.SupplierID = producto.SupplierID;
            try
            {
                //Actualizar en base de datos.
                db.SubmitChanges();
                Mensajes.RecursoModificado();
            }
            catch
            {
                Mensajes.Error();
            }
        }
    }
}
