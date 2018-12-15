using System;
using System.Windows.Forms;

namespace PalcoNet.Registro_de_Usuario
{
    public partial class CambiarContraseña : Form
    {
        private string usuario;
        private bool flag = true;

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
            flag = false;
        }

        private void CambiarContraseña_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag)
                e.Cancel = true;
        }
    }
}
