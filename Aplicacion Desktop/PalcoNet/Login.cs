using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet
{
    public partial class Login : Form
    {
        private int cantAccesos;
        private const int CANT_MAXIMA = 3;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool cambioContraseña = false;
            if (Conexion.getInstance().ValidarLogin(txtusuario.Text, txtContraseña.Text, ref cambioContraseña))
            {
                cantAccesos = 0;
                if (cambioContraseña)
                {
                   /* if (new Registro_de_Usuario.CambiarContraseña(txtusuario.Text).ShowDialog() == DialogResult.OK)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Se canceló la operación");
                    }*/
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecto");
                cantAccesos++;
            }
            if (cantAccesos == CANT_MAXIMA)
            {
                tmrLoginFallido.Enabled = true;
                btnLogin.Enabled = false;
                MessageBox.Show("Ha superado la cantidad de intentos. Se lo bloquea por cinco segundos");
                cantAccesos = 0;
            }
        }

        private void tmrLoginFallido_Tick(object sender, EventArgs e)
        {
            tmrLoginFallido.Enabled = false;
            btnLogin.Enabled = true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Hide();
            new Registro_de_Usuario.RegistroUsuario().ShowDialog();
            Show();
        }
    }
}
