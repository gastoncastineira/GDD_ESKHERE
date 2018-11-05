using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class RegistroUsuario : Form
    {
        public RegistroUsuario()
        {
            InitializeComponent();
        }

        private void RegistroUsuario_Load(object sender, EventArgs e)
        {
            //cbbRol.DataSource = Metodo para conseguir roles de BD
            cbbRol.ValueMember = "rol";
            cbbRol.DisplayMember = "rol";
        }

        private void cbbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Se mostrará un diálogo adicional para cargar los datos correspondientes al tipo de usuario");
            if(cbbTipo.SelectedText == "Cliente")
            {
                //new AltaCliente
            }
            else
            {
                //new AltaEmpresa
            }
        }

    }
}
