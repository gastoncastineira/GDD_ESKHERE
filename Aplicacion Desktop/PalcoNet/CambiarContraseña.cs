using System;
using System.Windows.Forms;

namespace PalcoNet
{
    public partial class CambiarContraseña : Form
    {
        private string usuario;

        public CambiarContraseña(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.Equals(txtContra.Text, txtContraRepe.Text))
            {
                if(Conexion.getInstance().ActualizarContraseña(txtContra.Text, usuario))
                {
                    MessageBox.Show("Se realizó la modificacion exitosamente");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Se encontró un error fatal y hubo que abortar");
                    DialogResult = DialogResult.Abort;
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no son iguales. Revise");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
