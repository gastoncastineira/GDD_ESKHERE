using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Cliente
{
    public partial class AltaCliente : Form
    {
        private bool errorCUIL = false;
        private List<TextBox> textos = new List<TextBox>();
        private Dictionary<string, object> datos = new Dictionary<string, object>();
        int idUser = -1;

        public AltaCliente()
        {
            InitializeComponent();
            foreach(Control c in Controls)
            {
                if (c is TextBox)
                    textos.Add(c as TextBox);
            }
            textos.Remove(txtPiso);
            textos.Remove(txtDepto);
        }

        public AltaCliente(int id)
        {
            id = -1;
            InitializeComponent();
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                    textos.Add(c as TextBox);
            }
            textos.Remove(txtPiso);
            textos.Remove(txtDepto);
            btnCancelar.Enabled = false;
        }

        private bool cuilEsValido()
        {
            string cuil = txtCUIL.Text;
            if (cbbTipo.Text == "LE")
                return true;
            if ((cuil.Substring(0, 2).Equals("20") || cuil.Substring(0, 2).Equals("23") || cuil.Substring(0, 2).Equals("24") || cuil.Substring(0, 2).Equals("27"))&& cuil.Substring(4, cuil.Length - 2).Equals(txtDoc.Text))
                return true;
            return false;
        }

        private void AgregarParaInsert(string nombreCol, object data)
        {
                datos[nombreCol] = data;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (textos.Any(t => string.IsNullOrEmpty(t.Text)) || cbbTipo.SelectedIndex == -1)
                MessageBox.Show("Se detectaron algunos campos obligatorios nulos. Revise");
            else
            {
                if (!cuilEsValido())
                {
                    MessageBox.Show("Se detectó un CUIL invalido. Revise");
                    errorCUIL = true;
                    Refresh();
                }
                else
                {
                    string usuario = string.Empty;
                    string contraseña = string.Empty;
                    if(idUser == -1)
                        AgregarParaInsert("id_usuario", Conexion.getInstance().GenerarUsuarioAleatorio(txtNombre.Text, txtApel.Text, ref usuario, ref contraseña));
                    else
                        AgregarParaInsert("id_usuario", idUser);
                    MessageBox.Show("Se generado un usuario aleatorio\nUsuario:" + usuario+"\nContraseña: "+contraseña);
                    if (Conexion.getInstance().Insertar(Conexion.Tabla.Cliente, datos))
                    
                        DialogResult = DialogResult.OK;
                        
                    
                    else
                        DialogResult = DialogResult.Abort;
                }
            }
        }

        private void chbPiso_CheckedChanged(object sender, EventArgs e)
        {
            txtDepto.Enabled = !txtDepto.Enabled;
        }

        private void chbDepto_CheckedChanged(object sender, EventArgs e)
        {
            txtPiso.Enabled = !txtPiso.Enabled;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            //this.Close();
        }

        private void formAltaUsuario_Paint(object sender, PaintEventArgs e)
        {
            if (errorCUIL)
            {
                txtCUIL.BorderStyle = BorderStyle.None;
                Pen p = new Pen(Color.Red);
                Graphics g = e.Graphics;
                int variance = 3;
                g.DrawRectangle(p, new Rectangle(txtCUIL.Location.X - variance, txtCUIL.Location.Y - variance, txtCUIL.Width + variance, txtCUIL.Height + variance));
            }
            else
                txtCUIL.BorderStyle = BorderStyle.FixedSingle;
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("Cli_nombre", txtNombre.Text.ToUpper());
        }

        private void txtApel_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("Cli_Apellido", txtApel.Text);
        }

        private void txtDoc_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("cli_dni", txtDoc.Text);
        }

        private void txtCUIL_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("cuil", txtCUIL.Text);
        }

        private void txtMail_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("cli_mail", txtMail.Text);
        }

        private void cbbTipo_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("Tipo_Doc", cbbTipo.Text);
        }

        private void txtTel_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("telefono", txtTel.Text);
        }

        private void txtDir_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("calle", txtDir.Text);
        }

        private void txtDepto_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("depto", txtDepto.Text);
        }

        private void txtPiso_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("piso", txtPiso.Text);
        }

        private void txtLocalidad_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("localidad", txtLocalidad.Text);
        }

        private void txtCodPostal_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("cod_postal", txtCodPostal.Text);
        }

        private void dtpNac_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("cli_fecha_nac", dtpNac.Value);
        }

        private void AltaCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(idUser != -1)
            {
                MessageBox.Show("No se pudo cancelar");
                e.Cancel = true;
            }
        }
    }
}
