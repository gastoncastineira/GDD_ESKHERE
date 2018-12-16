using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente
{
    public partial class ListadoClientes : Form
    {
        public ListadoClientes() : base()
        {
            InitializeComponent();
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
                if(!string.IsNullOrEmpty(txtNombre.Text))
                    filtros.Add("Cli_Nombre", Conexion.Filtro.Libre(txtNombre.Text));
                if (!string.IsNullOrEmpty(txtMail.Text))
                    filtros.Add("Cli_Mail", Conexion.Filtro.Libre(txtMail.Text));
                if (!string.IsNullOrEmpty(txtDNI.Text))
                    filtros.Add("Cli_Dni", Conexion.Filtro.Exacto(txtDNI.Text));
                if (!string.IsNullOrEmpty(txtApellido.Text))
                    filtros.Add("Cli_Apellido", Conexion.Filtro.Libre(txtApellido.Text));
                Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Cliente, ref dgbClientes, filtros);
                dgbClientes.Columns.Remove("fecha_creacion");
                dgbClientes.Columns.Remove("ID_Usuario");
                dgbClientes.Columns.Remove("Tipo_Doc");
            }
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MostrarResultado(new ModificarCliente(dgbClientes.SelectedCells[0].OwningRow.Cells).ShowDialog()); 
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            //Setear los bits de la columna anterior como !actual. Pedir confirmacion
        }

        private void dgbClientes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            btnDeshabilitar.Enabled = true;
            btnModificar.Enabled = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MostrarResultado(new AltaCliente().ShowDialog());
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Program.FormInicial.Show();
        }
    }
}
