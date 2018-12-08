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
        private Dictionary<string, object> datos = new Dictionary<string, object>();
        private List<TextBox> textos = new List<TextBox>();
        List<string> textosSinModificar = new List<string>();
        private int id;

        public ModificarEmpresa(DataGridViewCellCollection data)
        {
            InitializeComponent();

            foreach(Control c in Controls)
            {
                if (c is TextBox)
                    textos.Add(c as TextBox);
            }

            textos.Remove(txtPiso);
            textos.Remove(txtDepto);

            id = Convert.ToInt32(data["id"].Value);

            txtCodPostal.Text = data["cod_postal"].Value.ToString();
            textosSinModificar.Add(txtCodPostal.Text);
            txtCUIT.Text = data["Espec_Empresa_Cuit"].Value.ToString();
            textosSinModificar.Add(txtCUIT.Text);
            txtDepto.Text = data["depto"].Value.ToString();
            textosSinModificar.Add(txtDepto.Text);
            txtDir.Text = data["calle"].Value.ToString();
            textosSinModificar.Add(txtDir.Text);
            txtRazon.Text = data["Espec_Empresa_Razon_Social"].Value.ToString();
            textosSinModificar.Add(txtRazon.Text);
            txtLocalidad.Text = data["localidad"].Value.ToString();
            textosSinModificar.Add(txtLocalidad.Text);
            txtMail.Text = data["Espec_Empresa_Mail"].Value.ToString();
            textosSinModificar.Add(txtMail.Text);
            txtCiudad.Text = data["ciudad"].Value.ToString();
            textosSinModificar.Add(txtCiudad.Text);
            txtPiso.Text = data["piso"].Value.ToString();
            textosSinModificar.Add(txtPiso.Text);
            txtTel.Text = data["telefono"].Value.ToString();
            textosSinModificar.Add(txtTel.Text);
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
                    if (Conexion.getInstance().Modificar(id, Conexion.Tabla.Empresa, datos))
                        DialogResult = DialogResult.OK;
                    else
                        DialogResult = DialogResult.Abort;
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

        private void AgregarParaUpdate(string nombreCol, object data)
        {
                datos[nombreCol] = data;
        }

        private void txtCiudad_Leave(object sender, EventArgs e)
        {
            AgregarParaUpdate("ciudad", txtCiudad.Text);
        }

        private void txtCUIT_Leave(object sender, EventArgs e)
        {
            AgregarParaUpdate("Espec_Empresa_Cuit", txtCUIT.Text);
        }

        private void txtTel_Leave(object sender, EventArgs e)
        {
            AgregarParaUpdate("telefono", txtTel.Text);
        }

        private void txtMail_Leave(object sender, EventArgs e)
        {
            AgregarParaUpdate("Espec_Empresa_mail", txtMail.Text);
        }

        private void txtRazon_Leave(object sender, EventArgs e)
        {
            AgregarParaUpdate("Espec_Empresa_razon_social", txtRazon.Text);
        }

        private void txtDir_Leave(object sender, EventArgs e)
        {
            AgregarParaUpdate("calle", txtDir.Text);
        }

        private void txtDepto_Leave(object sender, EventArgs e)
        {
            AgregarParaUpdate("depto", txtDepto.Text);
        }

        private void txtPiso_Leave(object sender, EventArgs e)
        {
            AgregarParaUpdate("piso", txtPiso.Text);
        }

        private void txtLocalidad_Leave(object sender, EventArgs e)
        {
            AgregarParaUpdate("localidad", txtLocalidad.Text);
        }

        private void txtCodPostal_Leave(object sender, EventArgs e)
        {
            AgregarParaUpdate("cod_postal", txtCodPostal.Text);
        }
    }
}
