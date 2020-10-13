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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NorthwindDataContext db = new NorthwindDataContext();
        private void Form1_Load(object sender, EventArgs e)
        {
            var consulta = from producto in db.Products
                           join categoria in db.Categories on producto.CategoryID equals categoria.CategoryID
                           select new
                           {
                               NombreProducto = producto.ProductName,
                               Precio = producto.UnitPrice,
                               Categoría = categoria.CategoryName
                           };
            dgvProductos.DataSource = consulta.ToList();
        }
    }
}
