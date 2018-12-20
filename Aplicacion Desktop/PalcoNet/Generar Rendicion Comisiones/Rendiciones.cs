using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Generar_Rendicion_Comisiones
{
    public partial class Rendicion : FormTemplate
    {
        Dictionary<string, List<object>> infoEmpresas;
        public Rendicion() : base()
        {
            InitializeComponent();
        }

        private void btnRendir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                try
                {
                    Conexion.getInstance().RendirFactura(dataGridView1.Rows[i].Cells["Factura_Nro"].Value.ToString());
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("Se solicitó rendir mas comisiones que las que había. Se rindieron las que habia");
                    break;
                }
            }
            MessageBox.Show("Se rindieron exitosamente las comisiones elegidas");
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            filtros.Add("CUIL_Empresa", Conexion.Filtro.Exacto(infoEmpresas["Espec_Empresa_Cuit"][infoEmpresas["Espec_Empresa_Razon_Social"].IndexOf(cbbEmpresa.Text)].ToString()));
            filtros.Add("rendido", Conexion.Filtro.Exacto("0"));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Factura, ref dataGridView1, filtros);
            dataGridView1.Sort(this.dataGridView1.Columns["factura_fecha"], ListSortDirection.Ascending);
        }

        private void Rendicion_Load(object sender, EventArgs e)
        {
            List<string> columnas = new List<string>(new string[] {"id", "Espec_Empresa_Cuit", "Espec_Empresa_Razon_Social"});
            infoEmpresas = Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Empresa, columnas, null);
            cbbEmpresa.DataSource = infoEmpresas["Espec_Empresa_Razon_Social"];
            cbbEmpresa.SelectedIndex = -1;
            textBox1.Enabled = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
            else if (char.IsNumber(e.KeyChar) && textBox1.Text.Length == 0)
                btnRendir.Enabled = true;
            else if(char.IsControl(e.KeyChar) && textBox1.Text.Length == 1)
                btnRendir.Enabled = false;
        }

        private void cbbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbEmpresa.SelectedIndex == -1)
            {
                dataGridView1.DataSource = null;
            }
            else
            {
                textBox1.Enabled = true;
                Dictionary<string, string> filtros = new Dictionary<string, string>();
                filtros.Add("CUIL_Empresa", Conexion.Filtro.Exacto(infoEmpresas["Espec_Empresa_Cuit"][infoEmpresas["Espec_Empresa_Razon_Social"].IndexOf(cbbEmpresa.Text)].ToString()));
                //filtros.Add("rendido", Conexion.Filtro.Exacto("0"));
                Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Factura, ref dataGridView1, filtros);
                dataGridView1.Sort(this.dataGridView1.Columns["factura_fecha"], ListSortDirection.Ascending);
            }
        }
    }
}
