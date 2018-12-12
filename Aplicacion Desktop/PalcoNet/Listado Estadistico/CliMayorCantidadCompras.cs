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
    public partial class ClientesConMayorCantComprasForm : Form
    {
        public ClientesConMayorCantComprasForm(Dictionary<string, string> filtros)
        {
            InitializeComponent();
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.CliMayorCantCompras, ref dgvCMCC, filtros);
        }
    }
}
