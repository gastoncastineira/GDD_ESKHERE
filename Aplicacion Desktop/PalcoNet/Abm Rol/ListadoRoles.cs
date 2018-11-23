using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Rol
{
    public partial class ListadoRoles : Form
    {
        public ListadoRoles()
        {
            InitializeComponent();
        }

        private void ListadoRoles_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //va a mostrar la tabla de roles

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Int64 id = Convert.ToInt64(dataGridView1.CurrentRow.Cells[0].Value);
                //seleccion del rol

            }
            else
            {
                MessageBox.Show("Seleccione un rol");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
