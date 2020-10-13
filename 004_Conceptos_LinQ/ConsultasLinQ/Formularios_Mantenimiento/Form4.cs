using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios_Mantenimiento
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        ErrorProv errorProvider;
        NorthwindDataContext db = new NorthwindDataContext();
        private void Form4_Load(object sender, EventArgs e)
        {
            errorProvider = new ErrorProv(errorTerritorio);
            Listar();
        }

        private void Listar()
        {
            dgvTerritorios.DataSource = from territorio in db.Territories
                                        join region in db.Region on territorio.RegionID equals region.RegionID
                                        where territorio.bitHabilitado.Equals(true)
                                        select new
                                        {
                                            Código = territorio.TerritoryID,
                                            Territorio = territorio.TerritoryDescription,
                                            Región = region.RegionDescription
                                        };
        }
        string código = "";
        private void ObtenerDatos(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider.InitializeError();//Limpia los errores anteriores.
            código = dgvTerritorios.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            errorProvider.InitializeError();//Limpia los errores anteriores.
            if (String.IsNullOrWhiteSpace(código))
            {
                errorProvider.SetError(btnEliminar, "Seleccionar un Id dando click en elemento deseado.");
            }
            if (errorProvider.GetError())//Verifica si se levantó algún error.
            {
                return;
            }
            var Opcion = MessageBox.Show("¿Desea eliminar el territorio seleccionado?", "Aviso", MessageBoxButtons.YesNo);
            if (Opcion.Equals(DialogResult.Yes))
            {
                //Obtiene registro a eliminar
                var territorio = db.Territories.Where(t => t.TerritoryID.Equals(código)).FirstOrDefault();
                try
                {
                    //Actualiza el estado del registro.
                    territorio.bitHabilitado = false;
                    //Elimina el registro en la base de datos.
                    db.SubmitChanges();
                    //Actualizar la tabla
                    Listar();
                    código = "";
                    MessageBox.Show("Territorio eliminado.");
                }
                catch
                {
                    MessageBox.Show("Ha ocurrido un error.");
                }
            }
        }
    }
}
