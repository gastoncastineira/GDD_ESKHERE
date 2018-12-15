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
        private const int CANT_MAXIMA = 3;

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool cambioContraseña = false;
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            filtros["usuario"] = Conexion.Filtro.Exacto(txtusuario.Text.Trim());
            Dictionary<string, List<object>> resul = Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Usuario, new List<string>(new string[] { "cant_accesos_fallidos" }), filtros);
            int cantAccesos = Convert.ToInt32(resul["cant_accesos_fallidos"][0]);
            if (cantAccesos >= CANT_MAXIMA)
            {
                MessageBox.Show("Se llegó al límite de intentos y se inhabilitó el usuario. Por favor, contacte al administrador");
                Conexion.getInstance().deshabilitar(Conexion.Tabla.Usuario, Convert.ToInt32(resul["id"][0]));
                return;
            }
            if (Conexion.getInstance().ValidarLogin(txtusuario.Text, txtContraseña.Text, ref cambioContraseña))
            {
                cantAccesos = 0;
                if (cambioContraseña)
                {
                    if (new Registro_de_Usuario.CambiarContraseña(txtusuario.Text).ShowDialog() != DialogResult.OK)
                    {
                        MessageBox.Show("Se canceló la operación");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecto");
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Hide();
            new Registro_de_Usuario.RegistroUsuario().ShowDialog();
            Show();
        }
    }
}
