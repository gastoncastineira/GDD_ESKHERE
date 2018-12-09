using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Comprar
{
    public partial class Comprar : Form
    {
        public Comprar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            List<String> categorias = new List<string>();
            String descrip;
            DateTime desde = DateTime.Now;
            DateTime? hasta = null;

            //tomo valores
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                foreach (String s in checkedListBox1.CheckedItems)
                {
                    categorias.Add(s);
                }
            }
            if(!string.IsNullOrWhiteSpace(descripcion.Text))
            {
                descrip = descripcion.Text;
            }
            else descrip = null;
            if (!string.IsNullOrWhiteSpace(fechaDesde.Value.ToString()))
            {
                desde = fechaDesde.Value;
            }
            if (!string.IsNullOrWhiteSpace(fechaHasta.Value.ToString()))
            {
                hasta = fechaHasta.Value;
            }

            //select
        }

        private void fechaDesde_ValueChanged(object sender, EventArgs e)
        {
            fechaDesde.CustomFormat = " ";
            fechaDesde.Format = DateTimePickerFormat.Custom;
        }

        private void fechaHasta_ValueChanged(object sender, EventArgs e)
        {
            fechaHasta.CustomFormat = " ";
            fechaHasta.Format = DateTimePickerFormat.Custom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkedListBox1.ClearSelected();
            descripcion.Clear();
            fechaDesde.CustomFormat = " ";
            fechaDesde.Format = DateTimePickerFormat.Custom;
            fechaHasta.CustomFormat = " ";
            fechaHasta.Format = DateTimePickerFormat.Custom;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

    }
}
