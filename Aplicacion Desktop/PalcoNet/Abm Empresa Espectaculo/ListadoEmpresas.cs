using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class ListadoEmpresas : FormTemplate
    {
        private Dictionary<string, string> filtros = new Dictionary<string, string>();
        public ListadoEmpresas() : base()
        {
            InitializeComponent();
        }

        private void MostrarResultado(DialogResult dr)
        {
            if (dr == DialogResult.OK)
                MessageBox.Show("Se actualizó correctamente");
            if (dr == DialogResult.Abort)
                MessageBox.Show("Se encontró un error fatal y se abortó la actualización");
            if (dr == DialogResult.Cancel)
                MessageBox.Show("Se canceló la solicitud");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Controls.OfType<TextBox>().All(t => string.IsNullOrEmpty(t.Text)))
            {
                MessageBox.Show("Se debe ingresar algun filtro");
            }
            else
            {
                if (!string.IsNullOrEmpty(txtNombre.Text))
                    filtros.Add("Espec_Empresa_Razon_Social", Conexion.Filtro.Libre(txtNombre.Text));
                if (!string.IsNullOrEmpty(txtMail.Text))
                    filtros.Add("Espec_Empresa_Mail", Conexion.Filtro.Libre(txtMail.Text));
                if (!string.IsNullOrEmpty(txtCuit.Text))
                    filtros.Add("Espec_Empresa_Cuit", Conexion.Filtro.Exacto(txtCuit.Text));
                DataTable data = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Empresa, filtros);
                data.Columns.Add(new DataColumn("habilitado", typeof(bool)));
                foreach (DataRow d in data.Rows)
                {
                    Dictionary<string, string> filtro = new Dictionary<string, string>();
                    filtro["id"] = Conexion.Filtro.Exacto(d["ID_Usuario"].ToString());
                    d["habilitado"] = Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Usuario, new List<string>(new string[] { "habilitado" }), filtro)["habilitado"][0];
                }
                dgvEmpresa.DataSource = data;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MostrarResultado(new ModificarEmpresa(dgvEmpresa.SelectedCells[0].OwningRow.Cells).ShowDialog());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MostrarResultado(new AltaEmpresa().ShowDialog());
        }

        private void dgvEmpresa_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            btnDeshabilitar.Enabled = true;
            btnModificar.Enabled = true;
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(dgvEmpresa.SelectedCells[0].OwningRow.Cells["habilitado"].Value))
                Conexion.getInstance().deshabilitar(Conexion.Tabla.Usuario, Convert.ToInt32(dgvEmpresa.SelectedCells[0].OwningRow.Cells["ID_Usuario"].Value));
            else
                Conexion.getInstance().habilitar(Conexion.Tabla.Usuario, Convert.ToInt32(dgvEmpresa.SelectedCells[0].OwningRow.Cells["ID_Usuario"].Value));

            DataTable data = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Empresa, filtros);
            data.Columns.Add(new DataColumn("habilitado", typeof(bool)));
            foreach (DataRow d in data.Rows)
            {
                Dictionary<string, string> filtro = new Dictionary<string, string>();
                filtro["id"] = Conexion.Filtro.Exacto(d["ID_Usuario"].ToString());
                d["habilitado"] = Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Usuario, new List<string>(new string[] { "habilitado" }), filtro)["habilitado"][0];
            }
            dgvEmpresa.DataSource = data;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCuit.Text = txtMail.Text = txtNombre.Text = string.Empty;

        }
    }
}
