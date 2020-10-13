using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultasLinQ.Consultas.Ejercicio_013_join_multiple
{
    public class Producto
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public int idCategoria { get; set; }
        public int idProveedor { get; set; }
    }
}
