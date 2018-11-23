using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Grado
{
    public partial class AltaGrado : Form
    {
        public AltaGrado()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtComision.Text) || string.IsNullOrEmpty(txtNombre.Text))
                MessageBox.Show("Se detectaron campos vacios. Por favor, revise");
            else
            {
                //TODO: Persistir
                DialogResult = DialogResult.OK;
                //this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            //this.Close();
        }
    }
}
