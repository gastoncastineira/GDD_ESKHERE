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
            Dictionary<string, object> datos = new Dictionary<string, object>();
            datos.Add("rendido", 1);
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                try
                {
                    Conexion.getInstance().Modificar(Convert.ToInt32(dataGridView1.Rows[0].Cells["id"].Value), Conexion.Tabla.Factura, datos);
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
            MessageBox.Show("Se rindieron exitosamente las comisiones elegidas");
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
            if (textBox1.Text.Length == 0)
                btnRendir.Enabled = false;
            else
                btnRendir.Enabled = true;
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
