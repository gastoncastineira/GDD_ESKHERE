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
    public partial class ModificarCliente : Form
    {
        private bool errorCUIL = false;
        private List<TextBox> textos;

        public ModificarCliente(string nombre, string apellido, string mail, string doc, string Tipo, string cuil, string telefono, string direccion, string piso, string depto, string localidad, string codPostal)
        {
            InitializeComponent();

            txtApel.Text = apellido;
            txtCodPostal.Text = codPostal;
            txtCUIL.Text = cuil;
            txtDepto.Text = depto;
            txtDir.Text = direccion;
            txtDoc.Text = doc;
            txtLocalidad.Text = localidad;
            txtMail.Text = mail;
            txtNombre.Text = nombre;
            txtPiso.Text = piso;
            txtTel.Text = telefono;
            if (string.IsNullOrEmpty(txtPiso.Text))
                chbPiso.Enabled = true;
            if (string.IsNullOrEmpty(txtDepto.Text))
                chbDepto.Enabled = true;
        }

        private bool cuilEsValido()
        {
            string cuil = txtCUIL.Text;
            if (cbbTipo.Text == "LE")
                return true;
            if ((cuil.Substring(0, 2).Equals("20") || cuil.Substring(0, 2).Equals("23") || cuil.Substring(0, 2).Equals("24") || cuil.Substring(0, 2).Equals("27")) && cuil.Substring(4, cuil.Length - 2).Equals(txtDoc.Text))
                return true;
            return false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (textos.Any(t => string.IsNullOrEmpty(t.Text)) || cbbTipo.SelectedItem == null)
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
                    //TODO: cambiar a null el piso y depto para isnertar en BD si no tiene el usuario. validar con Checkbox
                    DialogResult = DialogResult.OK;
                    //this.Close();
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
    }
}
