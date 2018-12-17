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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbTipo.Text) || string.IsNullOrEmpty(txtContraseña.Text) || string.IsNullOrEmpty(txtUsuario.Text))
                MessageBox.Show("Se detectaron campos obligatorios vacios. Revise");
            else
            {
                if (MessageBox.Show("Se abrirá un dialogo adicional para cargar su informacion personal, el cual NO puede ser cancelado. ¿Desea continuar?", "Confirmacion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int id = -1;
                    if(cbbTipo.Text == "Cliente")
                        id = Conexion.getInstance().InsertarUsuario(txtUsuario.Text, txtContraseña.Text, "Cliente");
                    else
                        id = Conexion.getInstance().InsertarUsuario(txtUsuario.Text, txtContraseña.Text, "Empresa");

                    if (id != -1)
                    {
                        if (cbbTipo.Text == "Cliente")
                            new Abm_Cliente.AltaCliente(id).ShowDialog();
                        else
                            new Abm_Empresa_Espectaculo.AltaEmpresa(id).ShowDialog();
                        Close();
                        Program.FormInicial.Show();
                    }
                    else 
                    {
                        MessageBox.Show("Ese usuario ya se encuentra tomado");
                    }
                }
            }
        }
    }
}
