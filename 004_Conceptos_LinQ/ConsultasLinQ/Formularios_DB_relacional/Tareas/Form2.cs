using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_DB_relacional.Tareas
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        NorthwindDataContext db = new NorthwindDataContext();
        private void Form2_Load(object sender, EventArgs e)
        {
            //Mostrar categorías.
            var categorias = db.Categories.Select(c => c).ToList();

            categorias.Add(new Categories { CategoryID = 0, CategoryName = "Seleccionar todos los productos" });

            cboCategoría.DataSource = categorias.OrderBy(c => c.CategoryID).ToList();
            cboCategoría.DisplayMember = "CategoryName";
            cboCategoría.ValueMember = "CategoryID";

            //Desplegar productos.
            var consulta = from producto in db.Products
                           join categoria in db.Categories on producto.CategoryID equals categoria.CategoryID
                           select new
                           {
                               NombreProducto = producto.ProductName,
                               Precio = producto.UnitPrice,
                               Categoría = categoria.CategoryName,
                               Stock = producto.UnitsInStock
                           };
            dgvProductos.DataSource = consulta.ToList();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            //Obtener categoría.
            int id = (int) cboCategoría.SelectedValue;
            //Desplegar productos conforme a la categoría seleccionada.
            var consulta = from producto in db.Products
                           join categoria in db.Categories on producto.CategoryID equals categoria.CategoryID
                           where id.Equals(0) || categoria.CategoryID.Equals(id)
                           select new
                           {
                               NombreProducto = producto.ProductName,
                               Precio = producto.UnitPrice,
                               Categoría = categoria.CategoryName,
                               Stock = producto.UnitsInStock
                           };
            dgvProductos.DataSource = consulta.ToList();
        }

        
    }
}
