using Formularios_LinQ.Formulario_5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Formularios_LinQ.Formulario_6
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        List<Categoria> listaCategoria;
        List<Producto> listaProducto;
        
        private void Cbo_selectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(cboCategoria.SelectedValue.ToString());
            var tablaProducto = (from producto in listaProducto
                                 join categoria in listaCategoria
                                 on producto.idCategoria equals categoria.idCategoria
                                 where cboCategoria.SelectedIndex == 0 || categoria.idCategoria == id
                                 select new { Producto = producto.nombreProducto, Categoria = categoria.nombreCategoria }).ToList();

            dgvProducto.DataSource = null;
            dgvProducto.DataSource = tablaProducto;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            listaCategoria = new List<Categoria>
            {
                new Categoria { idCategoria=0, nombreCategoria="Todos los elementos" },
                new Categoria { idCategoria=1, nombreCategoria="Frutas" },
                new Categoria { idCategoria=2, nombreCategoria="Verduras" },
                new Categoria { idCategoria=3, nombreCategoria="Animal" },
                new Categoria { idCategoria=4, nombreCategoria="Aseo Personal" }
            };

            //Objeto de donde tomará la información.
            cboCategoria.DataSource = listaCategoria;
            //Propiedad que va a desplegar en pantalla el combo box.
            cboCategoria.DisplayMember = "nombreCategoria";
            //Propiedad que va a tomar como valor el combo box.
            cboCategoria.ValueMember = "idCategoria";

            listaProducto = new List<Producto>
            {
                new Producto { idProducto=1, nombreProducto="Papaya", idCategoria=1 },
                new Producto { idProducto=2, nombreProducto="Uva", idCategoria=1 },
                new Producto { idProducto=3, nombreProducto="Plátano", idCategoria=1 },
                new Producto { idProducto=4, nombreProducto="Manzana", idCategoria=1 },
                new Producto { idProducto=5, nombreProducto="Naranja", idCategoria=1 },
                new Producto { idProducto=6, nombreProducto="Papa", idCategoria=2 },
                new Producto { idProducto=7, nombreProducto="Espinaca", idCategoria=2 },
                new Producto { idProducto=8, nombreProducto="Quintonil", idCategoria=2 },
                new Producto { idProducto=9, nombreProducto="Vaca", idCategoria=3 },
                new Producto { idProducto=10, nombreProducto="Pollo", idCategoria=3 },
                new Producto { idProducto=11, nombreProducto="Cerdo", idCategoria=3 },
                new Producto { idProducto=12, nombreProducto="Gallina", idCategoria=3 },
                new Producto { idProducto=13, nombreProducto="Gato", idCategoria=3 },
                new Producto { idProducto=14, nombreProducto="Jabón Juanito", idCategoria=4 },
                new Producto { idProducto=15, nombreProducto="Shampoo", idCategoria=4 },
                new Producto { idProducto=16, nombreProducto="Gel Antibacteral", idCategoria=4 },
                new Producto { idProducto=17, nombreProducto="Desodorante", idCategoria=4 },
            };

            var tablaProducto = (from producto in listaProducto
                                 join categoria in listaCategoria
                                 on producto.idCategoria equals categoria.idCategoria
                                 select new { Producto = producto.nombreProducto, Categoria = categoria.nombreCategoria }).ToList();

            dgvProducto.DataSource = tablaProducto;
        }
    }
}
