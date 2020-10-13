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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        NorthwindDataContext db = new NorthwindDataContext();
        private void Form2_Load(object sender, EventArgs e)
        {
            var regionTotal = new Region { RegionID = 0 , RegionDescription = "Seleccionar todas las regiones." };
            var regiones = db.Region.ToList();
            regiones.Add(regionTotal);
            cboRegion.DataSource = regiones.OrderBy(r => r.RegionID).ToList();
            cboRegion.DisplayMember = "RegionDescription";
            cboRegion.ValueMember = "RegionID";

            var consulta = from empleado in db.Employees
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
                               Edad = (DateTime.Today - empleado.BirthDate).Value.TotalDays / 365,
                               Territorio = territorio.TerritoryDescription,
                               Region = region.RegionDescription
                           };
            dgvTerritorio.DataSource = consulta.ToList();
        }

        private void FiltrarRegión(object sender, EventArgs e)
        {
            var consulta = from empleado in db.Employees
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
                               Edad = (DateTime.Today - empleado.BirthDate).Value.TotalDays / 365,
                               Territorio = territorio.TerritoryDescription,
                               region.RegionID,
                               Region = region.RegionDescription
                           };
            int regionId = int.Parse(cboRegion.SelectedValue.ToString());
            if (regionId>0)
            {
                consulta = consulta.Where(r => r.RegionID == regionId);
            }

            dgvTerritorio.DataSource = consulta.Select( t =>
                new
                {
                    t.NombreEmpleado,
                    t.Dirección,
                    t.Edad,
                    t.Territorio,
                    t.Region
                }).ToList();
        }
    }
}
