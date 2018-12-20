using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Editar_Publicacion
{
    public partial class SeleccionarPublicacion : FormTemplate
    {
        int idEmpresa;
        public SeleccionarPublicacion(int idEmpresa):base()
        {
            InitializeComponent();
            this.idEmpresa = idEmpresa;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(descripcion.Text) && string.IsNullOrEmpty(rubro.Text) && string.IsNullOrEmpty(grado.Text))
            {
                MessageBox.Show("Se debe ingresar algun filtro");
            }
            else
            {
                Dictionary<string, string> filtros = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(descripcion.Text))
                    filtros.Add("Descripcion", Conexion.Filtro.Libre(descripcion.Text));
                if (!string.IsNullOrEmpty(rubro.Text))
                    filtros.Add("Publicacion_Rubro", Conexion.Filtro.Libre(rubro.Text));
                if (!string.IsNullOrEmpty(grado.Text))
                    filtros.Add("ID_grado", Conexion.Filtro.Exacto(grado.SelectedValue.ToString()));
                
                filtros.Add("Id_Empresa_publicante", Conexion.Filtro.Exacto(idEmpresa.ToString()));
                Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.PublicacionBorrador, ref dgbPublicaciones, filtros );
                dgbPublicaciones.Columns.Remove("Id_Empresa_publicante");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgbPublicaciones.DataSource=null;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            new EditarPublicacion(Convert.ToInt32(dgbPublicaciones.CurrentRow.Cells[0].Value),idEmpresa).ShowDialog();
        }

        private void SeleccionarPublicacion_Load(object sender, EventArgs e)
        {
            DataTable grados = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Grado, null);
            grado.DataSource = grados;
            grado.ValueMember = "ID";
            grado.DisplayMember = "Descripcion";
            grado.SelectedIndex = -1;
        }
    }
}
