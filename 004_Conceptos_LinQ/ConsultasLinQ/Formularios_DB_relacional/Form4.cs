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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        NorthwindDataContext db = new NorthwindDataContext();
        private void Form4_Load(object sender, EventArgs e)
        {
            Listar();

        }

        private void Listar()
        {
            dgvSuppliers.DataSource = db.Suppliers.Select(
                delegate (Suppliers s) {
                    //var hp = null == s.CompanyName ? "": s.CompanyName;
                    //var productoA = " " + hp.ToCharArray().Count(p=> p.ToString().Equals("a")).ToString();
                    var Compañia = s.CompanyName;
                    var Nombre = s.ContactName;
                    var Titulo = s.ContactTitle;
                    var Dirección = s.Address;
                    var Ciudad = s.City;
                    return new { Compañia, Nombre , Titulo, Dirección, Ciudad};
                }).ToList();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string companyName = txtCompany.Text;
            bool companyExist = (db.Suppliers.Where(p => p.CompanyName.Equals(companyName))).Any();
            if (companyExist)
            {
                MessageBox.Show("Ya se registró esa compañia.");
                return;
            }

            string contactName = txtName.Text;
            string contactTitle = txtTitle.Text;
            string address = txtAddress.Text;
            string city = txtCity.Text;

            Suppliers su = new Suppliers
            {
                CompanyName = companyName,
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = address,
                City = city
            };

            db.Suppliers.InsertOnSubmit(su);
            try
            {
                db.SubmitChanges();
                Listar();
                Limpiar();
                MessageBox.Show("Se agregó correctamente.");
            }
            catch
            {
                MessageBox.Show("No se agregó.");
            }

        }

        private void Limpiar()
        {
            txtCompany.Text="";
            txtName.Text = "";
            txtTitle.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
