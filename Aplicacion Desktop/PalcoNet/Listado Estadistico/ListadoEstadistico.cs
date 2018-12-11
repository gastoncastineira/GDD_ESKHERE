using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Listado_Estadistico
{
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
            List<string> lista = new List<string>();
            lista.Add("AniosPublicacion"); 
            List<object> resultadoConsulta = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.AniosQueSePublicaron, lista, null))["AniosPublicacion"]) ;
            resultadoConsulta.Sort(); 
            cmbAño.DataSource = resultadoConsulta;
            cmbTrimestre.Items.Add("1");
            cmbTrimestre.Items.Add("2");
            cmbTrimestre.Items.Add("3");
            cmbTrimestre.Items.Add("4");
        }

        private void btnClientesPtsVnc_Click(object sender, EventArgs e)
        {
            CliMayoresPtosvencidos cpv = new CliMayoresPtosvencidos();
            cpv.ShowDialog();
        }

        private void btnClientesCantCompra_Click(object sender, EventArgs e)
        {
            CliMayoresPtosvencidos cpv = new CliMayoresPtosvencidos();
            cpv.ShowDialog();
        }
    }
}
