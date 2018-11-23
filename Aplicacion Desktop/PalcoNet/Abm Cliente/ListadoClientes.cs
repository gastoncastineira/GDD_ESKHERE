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
        public ListadoClientes()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                btnDeshabilitar.Enabled = true;
                btnModificar.Enabled = true;
            }
            else
            {
                btnDeshabilitar.Enabled = false;
                btnModificar.Enabled = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (Controls.OfType<TextBox>().All(t => string.IsNullOrEmpty(t.Text)))
            {
                //TODO: traer todo
            }
            else
            {
                Dictionary<string, string> datos = new Dictionary<string, string>();
                //TODO: guardar valores de los textbox (usar como key el nombre del label. Iterar Controls para sacarlos y la propiedad Name
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
                MessageBox.Show("Los valores se deben modificar de a uno");
            else
            {
                //new ModificarCliente().ShowDialog(); Sacar strings del Grid. Averiguar como porque ni idea
            }
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            //Setear los bits de la columna anterior como !actual. Pedir confirmacion
        }
    }
}
