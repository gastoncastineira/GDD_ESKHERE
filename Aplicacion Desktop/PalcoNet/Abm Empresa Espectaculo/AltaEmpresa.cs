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
    public partial class AltaEmpresa : Form
    {
        private bool errorCUIT = false;
        private List<TextBox> textos = new List<TextBox>();
        private Dictionary<string, object> datos = new Dictionary<string, object>();
        private int idUser = -1;
        private bool flag = true;

        public AltaEmpresa()
        {
            InitializeComponent();
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                    textos.Add(c as TextBox);
            }
            textos.Remove(txtPiso);
            textos.Remove(txtDepto);
            dtp_FechaCreacion.MaxDate = ConfigurationHelper.fechaActual;
        }

        public AltaEmpresa(int idUser)
        {
            flag = false;
            this.idUser = idUser;
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
                if (!cuitEsValido(txtCUIT.Text))
                {
                    MessageBox.Show("Se ha detectado un CUIT invalido. Revise");
                    errorCUIT = true;
                    Refresh();
                }
                else
                {
                    string usuario = string.Empty;
                    string contraseña = string.Empty;
                    if (idUser == -1)
                    {
                        AgregarParaInsert("id_usuario", Conexion.getInstance().GenerarUsuarioAleatorio(txtCUIT.Text, "Cliente", ref usuario, ref contraseña));
                        MessageBox.Show("Se generado un usuario aleatorio\nUsuario:" + usuario + "\nContraseña: " + contraseña);
                    }
                    else
                        AgregarParaInsert("id_usuario", idUser);
                    if (Conexion.getInstance().Insertar(Conexion.Tabla.Empresa, datos)!=-1)
                        DialogResult = DialogResult.OK;
                    else
                        DialogResult = DialogResult.Abort;
                }
            }
            flag = true;
        }

        private void AgregarParaInsert(string nombreCol, object data)
        {
            datos[nombreCol] = data;
        }

        private bool cuitEsValido(object sender)
        {
            string cuil = txtCUIT.Text;
            if ((cuil.Substring(0, 2).Equals("30") || cuil.Substring(0, 2).Equals("33") || cuil.Substring(0, 2).Equals("34")))
            { return CalculoCUITCUIL.cuitEsValido(sender.ToString()); }
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

        private void txtCiudad_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("ciudad", txtCiudad.Text);
        }

        private void txtCUIT_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("Espec_Empresa_Cuit", txtCUIT.Text);
        }

        private void txtTel_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("telefono", txtTel.Text);
        }

        private void txtMail_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("Espec_Empresa_mail", txtMail.Text);
        }

        private void txtRazon_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("Espec_Empresa_razon_social", txtRazon.Text);
        }

  
        private void txtDepto_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("depto", txtDepto.Text);
        }

        private void txtPiso_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("piso", Convert.ToInt32(txtPiso.Text));
        }

        private void txtLocalidad_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("localidad", txtLocalidad.Text);
        }

        private void txtCodPostal_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("cod_postal", txtCodPostal.Text);
        }
 
        private void txt_Calle_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("Calle", txt_Calle.Text);
        }

        private void txt_Numero_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("Numero", Convert.ToInt32(txt_Numero.Text));

        }

        private void dtp_FechaCreacion_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("Espec_Empresa_Fecha_Creacion", dtp_FechaCreacion.Value.ToString("yyyy-MM-dd hh:mm:ss"));
        }

        private void AltaEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!flag)
            {
                MessageBox.Show("No se puede cancelar");
                e.Cancel = true;
            }
        }
        
        private void soloNumerico(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }
    }
}
