using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Empresa_Espectaculo
{
    public partial class ModificarEmpresa : Form
    {
        private bool errorCUIT = false;
        private List<TextBox> textos;

        public ModificarEmpresa(string nombre, string cuit, string razonSocial, string direccion, string mail, string telefono, string piso, string depto, string codPostal, string localidad)
        {
            InitializeComponent();
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                    textos.Add(c as TextBox);
            }
            textos.Remove(txtPiso);
            textos.Remove(txtDepto);


            txtCodPostal.Text = codPostal;
            txtCUIT.Text = cuit;
            txtDepto.Text = depto;
            txtDir.Text = direccion;
            txtRazon.Text = razonSocial;
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

        private void chbPiso_CheckedChanged(object sender, EventArgs e)
        {
            txtDepto.Enabled = !txtDepto.Enabled;
        }

        private void chbDepto_CheckedChanged(object sender, EventArgs e)
        {
            txtPiso.Enabled = !txtPiso.Enabled;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (textos.Any(t => string.IsNullOrEmpty(t.Text)))
                MessageBox.Show("Se detectaron algunos campos obligatorios nulos. Revise");
            else
            {
                if (!cuitEsValido())
                {
                    MessageBox.Show("Se ha detectado un CUIT invalido. Revise");
                    errorCUIT = true;
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

        private bool cuitEsValido()
        {
            string cuil = txtCUIT.Text;
            if ((cuil.Substring(0, 2).Equals("20") || cuil.Substring(0, 2).Equals("23") || cuil.Substring(0, 2).Equals("24") || cuil.Substring(0, 2).Equals("27")) && cuil.Substring(4, cuil.Length - 2).Equals(txtRazon.Text))
                return true;
            return false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            //this.Close();
        }

        private void AltaEmpresa_Paint(object sender, PaintEventArgs e)
        {
            if (errorCUIT)
            {
                txtCUIT.BorderStyle = BorderStyle.None;
                Pen p = new Pen(Color.Red);
                Graphics g = e.Graphics;
                int variance = 3;
                g.DrawRectangle(p, new Rectangle(txtCUIT.Location.X - variance, txtCUIT.Location.Y - variance, txtCUIT.Width + variance, txtCUIT.Height + variance));
            }
            else
                txtCUIT.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
