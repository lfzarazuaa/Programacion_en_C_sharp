using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_DB_relacional
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        NorthwindDataContext db = new NorthwindDataContext();
        private void Form5_Load(object sender, EventArgs e)
        {
            cboCategoria.DataSource = db.Categories;
            cboCategoria.DisplayMember = "CategoryName";
            cboCategoria.ValueMember = "CategoryID";

            cboProveedor.DataSource = db.Suppliers;
            cboProveedor.DisplayMember = "CompanyName";
            cboProveedor.ValueMember = "SupplierID";
            //Mostrar en tabla los elementos.
            Listar();
        }

        private void Listar()
        {
            var consulta = from producto in db.Products
                           join categoria in db.Categories on producto.CategoryID equals categoria.CategoryID
                           join proveedor in db.Suppliers on producto.SupplierID equals proveedor.SupplierID
                           select new
                           {
                               Producto = producto.ProductName,
                               Categoría = categoria.CategoryName,
                               Proveedor = proveedor.CompanyName,
                               Descripción = producto.QuantityPerUnit,
                               Precio = producto.UnitPrice,
                               Stock = producto.UnitsInStock
                           };

            dgvEmpleados.DataSource = consulta.ToList();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            int categoriaId = Convert.ToInt32(cboCategoria.SelectedValue.ToString());
            int proveedorId = Convert.ToInt32(cboProveedor.SelectedValue.ToString());
            errorFormulario.Clear();
            string productName= txtNombre.Text;
            if (productName.Equals(""))
            {
                errorFormulario.SetError(txtNombre, "Rellenar campo.");
                return;
            }
            var existeProducto = db.Products.Where(p => p.ProductName.Equals(productName)).Any();
            if (existeProducto)
            {
                errorFormulario.SetError(txtNombre, "Ya existe el producto.");
                return;
            }
            if (categoriaId <= 0)
            {
                errorFormulario.SetError(cboCategoria, "Seleccionar categoria.");
                return;
            }
            if (proveedorId <= 0)
            {
                errorFormulario.SetError(cboCategoria, "Seleccionar proveedor.");
                return;
            }
            string Descripción = txtDescripción.Text;
            if (Descripción.Length>20)
            {
                Descripción = Descripción.Substring(0, 20);
            }

            if (Descripción.Equals(""))
            {
                errorFormulario.SetError(txtDescripción, "Rellenar campo.");
                return;
            }
            int precio = Convert.ToInt32(txtprecio.Value);
            if (precio<0)
            {
                errorFormulario.SetError(txtprecio, "Ingresar precio válido.");
                return;
            }
            short stock = Convert.ToByte(txtstock.Value);
            if (stock < 0)
            {
                errorFormulario.SetError(txtstock, "Ingresar stock válido.");
                return;
            }

            Products productoNuevo = new Products
            { 
                ProductName = productName,
                CategoryID = categoriaId,
                SupplierID = proveedorId,
                QuantityPerUnit = Descripción,
                UnitPrice = precio,
                UnitsInStock = stock
            };

            db.Products.InsertOnSubmit(productoNuevo);
            try
            {
                db.SubmitChanges();
                Listar();
                Limpiar();
                MessageBox.Show("Se agregó correctamente.");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al ingresar el dato. {ex.Message}");
            }
        }

        private void Limpiar()
        {
            txtNombre.Text = "";
            txtDescripción.Text = "";
            txtprecio.Value = 0;
            txtstock.Value = 0;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
