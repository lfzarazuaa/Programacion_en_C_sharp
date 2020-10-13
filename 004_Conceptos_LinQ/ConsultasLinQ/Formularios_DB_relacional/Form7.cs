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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        NorthwindDataContext db = new NorthwindDataContext();

        private void Form7_Load(object sender, EventArgs e)
        {
            //Combo Box Categoría.
            cboCategoria.DataSource = db.Categories;
            cboCategoria.DisplayMember = "CategoryName";
            cboCategoria.ValueMember = "CategoryID";
            //Combo Box Proveedor.
            cboProveedor.DataSource = db.Suppliers;
            cboProveedor.DisplayMember = "CompanyName";
            cboProveedor.ValueMember = "SupplierID";
            //Listar los elementos.
            Listar();
        }
        int id = 0;
        private void ObtenerId(object sender, DataGridViewCellEventArgs e)
        {
            errorProducto.Clear();//Limpiar Errores.
            id = (int)dgvProductos.CurrentRow.Cells[0].Value;
            txtID.Text = id.ToString();
            txtNombre.Text = (string)dgvProductos.CurrentRow.Cells[1].Value;
            //Obtener id de categoria para combo box categoría.
            string categoria = (string) dgvProductos.CurrentRow.Cells[2].Value;
            cboCategoria.SelectedValue = db.Categories.Where(c=>c.CategoryName.Equals(categoria)).Select(c=>c.CategoryID).FirstOrDefault();
            //Obtener id de categoria para combo box categoría.
            string proveedor = (string) dgvProductos.CurrentRow.Cells[3].Value;
            cboProveedor.SelectedValue = db.Suppliers.Where(s => s.CompanyName.Equals(proveedor)).Select(s => s.SupplierID).FirstOrDefault();
            txtDescripción.Text = (string)dgvProductos.CurrentRow.Cells[4].Value;
            txtprecio.Value = (decimal)dgvProductos.CurrentRow.Cells[5].Value;
            txtstock.Value = (short)dgvProductos.CurrentRow.Cells[6].Value;
        }

        private void Listar()
        {
            var consulta = from producto in db.Products
                           join categoria in db.Categories on producto.CategoryID equals categoria.CategoryID
                           join proveedor in db.Suppliers on producto.SupplierID equals proveedor.SupplierID
                           select new
                           {
                               Id = producto.ProductID,
                               Producto = producto.ProductName,
                               Categoría = categoria.CategoryName,
                               Proveedor = proveedor.CompanyName,
                               Descripción = producto.QuantityPerUnit,
                               Precio = producto.UnitPrice,
                               Stock = producto.UnitsInStock
                           };

            dgvProductos.DataSource = consulta.ToList();
        }
        bool bError = false;
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Validación.
            errorProducto.Clear();//Limpiar Errores.
            bError = false;
            if (id.Equals(0))
            {
                setError(txtID, "Seleccionar ID(dar click en el id de la tabla).");
            }

            string Nombre = txtNombre.Text;
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                setError(txtNombre, "Rellenar el campo.");
            }

            string Descripción = txtDescripción.Text;
            if (string.IsNullOrWhiteSpace(Descripción))
            {
                setError(txtDescripción, "Rellenar el campo.");
            }
            if (Descripción.Length>20)
            {
                Descripción = Descripción.Substring(0, 20);
            }
            if (bError) { return; }
            // Consultar registro.
            var producto = db.Products.Where(p => p.ProductID.Equals(id)).ToList().FirstOrDefault();
            try
            {
                //Actualizar registro en memoria.
                producto.ProductName = Nombre;
                producto.CategoryID = (int)cboCategoria.SelectedValue;
                producto.SupplierID = (int)cboProveedor.SelectedValue;
                producto.QuantityPerUnit = Descripción;
                producto.UnitPrice = txtprecio.Value;
                producto.UnitsInStock = (short)txtstock.Value;
                //Actualizar registro en base datos.
                db.SubmitChanges();
                //Listar registros.
                Listar();
                Limpiar();
            }
            catch
            {
                MessageBox.Show("Ocurrió un error.");
            }

        }

        private void Limpiar()
        {
            id = 0;//Resetear Id.
            txtID.Text = "";
            txtNombre.Text = "";
            cboCategoria.SelectedIndex = 0;
            cboProveedor.SelectedIndex = 0;
            txtDescripción.Text = "";
            txtprecio.Value = 0;
            txtstock.Value = 0;
        }

        private void setError(Control control, string mensaje)
        {
            errorProducto.SetError(control, mensaje);
            bError = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
