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
    public partial class ListadoEmpresas : Form
    {
        public ListadoEmpresas()
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
                Dictionary<string, string> filtros = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(txtNombre.Text))
                    filtros.Add("Espec_Empresa_Razon_Social", Conexion.Filtro.Libre(txtNombre.Text));
                if (!string.IsNullOrEmpty(txtMail.Text))
                    filtros.Add("Espec_Empresa_Mail", Conexion.Filtro.Libre(txtMail.Text));
                if (!string.IsNullOrEmpty(txtCuit.Text))
                    filtros.Add("Espec_Empresa_Cuit", Conexion.Filtro.Exacto(txtCuit.Text));
                Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Empresa, ref dgvEmpresa, filtros);
                dgvEmpresa.Columns.Remove("id_usuario");
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

        }
    }
}
