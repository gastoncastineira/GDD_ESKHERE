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
            if(string.IsNullOrEmpty(txtContraseña.Text) || string.IsNullOrEmpty(txtusuario.Text))
            {
                MessageBox.Show("Se detecto un campo vacio. Revise");
                return;
            }
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            filtros["usuario"] = Conexion.Filtro.Exacto(txtusuario.Text);
            if (!Conexion.getInstance().existeRegistro(Conexion.Tabla.Usuario, new List<string>(new string[] { "usuario" }), filtros))
            {
                MessageBox.Show("No existe dicho usuario en el sistema");
                return;
            }
            bool cambioContraseña = false;
            filtros = new Dictionary<string, string>();
            filtros["usuario"] = Conexion.Filtro.Exacto(txtusuario.Text);
            Dictionary<string, List<object>> resul = Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Usuario, new List<string>(new string[] { "ID", "cant_accesos_fallidos", "habilitado" }), filtros);
            if (!Convert.ToBoolean(resul["habilitado"][0]))
            {
                MessageBox.Show("Este usuario se encuentra deshabilitado");
                return;
            }
            int cantAccesos = Convert.ToInt32(resul["cant_accesos_fallidos"][0]);
            if (Conexion.getInstance().ValidarLogin(txtusuario.Text, txtContraseña.Text, ref cambioContraseña))
            {
                if (cambioContraseña)
                {
                    if (new Registro_de_Usuario.CambiarContraseña(txtusuario.Text).ShowDialog() != DialogResult.OK)
                    {
                        MessageBox.Show("Se canceló la operación");
                        return;
                    }
                }
                Hide();
                new EntutarRoles(txtusuario.Text).Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecto");
                cantAccesos++;
            }
            if (cantAccesos >= CANT_MAXIMA)
            {
                MessageBox.Show("Se llegó al límite de intentos y se inhabilitó el usuario. Por favor, contacte al administrador");
                Conexion.getInstance().deshabilitar(Conexion.Tabla.Usuario, Convert.ToInt32(resul["ID"][0]));
                Dictionary<string, object> datos = new Dictionary<string, object>();
                datos["cant_accesos_fallidos"] = 0;
                Conexion.getInstance().Modificar(Convert.ToInt32(resul["ID"][0]), Conexion.Tabla.Usuario, datos);
            }
            txtContraseña.Text = string.Empty;
            txtusuario.Text = string.Empty;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Hide();
            new Registro_de_Usuario.RegistroUsuario().ShowDialog();
            Show();
        }

    }
}
