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
    public partial class ABMRol : Form
    {
        public ABMRol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearRol crearRol = new CrearRol();
            crearRol.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListadoRoles listadoRoles = new ListadoRoles();
            listadoRoles.Show();
        }
    }
}
