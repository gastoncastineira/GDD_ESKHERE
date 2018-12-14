using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Historial_Cliente
{
    public partial class ListadoDeCompras : Form
    {

        private DataTable datos;
        private int numPag = 0;
        private int idCliente;

        public ListadoDeCompras(int idCliente)
        {
            this.idCliente = idCliente;
            InitializeComponent();
        }

        private void pasarPagina()
        {
            int cantPag = numPag * Convert.ToInt32(cbbCantPag.Text);
            DataTable data = datos.Clone();
            for (int index = cantPag; index < cantPag + Convert.ToInt32(cbbCantPag.Text); index++)
            {
                try
                {
                    data.ImportRow(datos.Rows[index]);
                }
                catch(IndexOutOfRangeException)
                {
                    break;
                }
            }
            dgvCompras.DataSource = data;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            filtros.Add("id_cliente", Conexion.Filtro.Exacto(idCliente.ToString()));
            datos = Conexion.getInstance().conseguirTabla(Conexion.Tabla.HistorialCompras, filtros);
            datos.Columns.Remove("id_cliente");
            for(int i = 1; i<=50;i++)
            {
                cbbCantPag.Items.Add(i);
            }
        }

        private void cbbCantPag_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbCantPag.Enabled = false;
            btnDerecha.Enabled = true;
            btnIzquierda.Enabled = true;
            pasarPagina();
        }

        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            if(numPag>0)
            {
                numPag--;
                pasarPagina();
            }
        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {
            int cantMaxPags = datos.Rows.Count / Convert.ToInt32(cbbCantPag.Text) + 1;
            if (numPag < cantMaxPags)
            {
                numPag++;
                pasarPagina();
            }
        }
    }
}
