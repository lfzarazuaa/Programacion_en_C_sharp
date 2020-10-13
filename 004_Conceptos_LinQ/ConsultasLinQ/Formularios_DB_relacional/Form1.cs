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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NorthwindDataContext db = new NorthwindDataContext();
        private void Form1_Load(object sender, EventArgs e)
        {
            var consulta = (from empleado in db.Employees
                           join empleadosterritorios in db.EmployeeTerritories
                           on empleado.EmployeeID equals empleadosterritorios.EmployeeID
                           join territorio in db.Territories
                           on empleadosterritorios.TerritoryID equals territorio.TerritoryID
                           join region in db.Region
                           on territorio.RegionID equals region.RegionID
                           select new
                           {
                               NombreEmpleado = $"{empleado.FirstName} {empleado.LastName}",
                               Dirección = empleado.Address, 
                               Edad = (DateTime.Today-empleado.BirthDate).Value.TotalDays/365,
                               Territorio = territorio.TerritoryDescription,
                               Region = region.RegionDescription
                           }).Where(p => p.Edad>70);
            dgvTerritorio.DataSource=consulta.ToList();
        }
    }
}
