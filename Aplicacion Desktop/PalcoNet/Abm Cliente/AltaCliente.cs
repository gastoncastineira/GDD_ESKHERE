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
        private bool flag = true;

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
            dtpNac.MaxDate = ConfigurationHelper.fechaActual;
        }

        public AltaCliente(int id)
        {
            flag = false;
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

        private bool cuilEsValido(object sender)
        {
            string cuil = txtCUIL.Text;
            if (cbbTipo.Text == "LE")
                return true;
            if ((cuil.Substring(0, 2).Equals("20") || cuil.Substring(0, 2).Equals("23") || cuil.Substring(0, 2).Equals("24") || cuil.Substring(0, 2).Equals("27"))/*&& cuil.Substring(4, cuil.Length - 2).Equals(txtDoc.Text)*/)
            { return CalculoCUITCUIL.cuitEsValido(sender.ToString()); }
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
                if (!cuilEsValido(txtCUIL.Text))
                {
                    MessageBox.Show("Se detectó un CUIL invalido. Revise");
                    errorCUIL = true;
                    Refresh();
                }
                else
                {
                    AgregarParaInsert("fecha_creacion", ConfigurationHelper.fechaActual.ToString("yyyy-MM-dd hh:mm:ss"));
                    string usuario = string.Empty;
                    string contraseña = string.Empty;
                    if (idUser == -1)
                    {
                        AgregarParaInsert("id_usuario", Conexion.getInstance().GenerarUsuarioAleatorio(txtDoc.Text, "Cliente", ref usuario, ref contraseña));
                        MessageBox.Show("Se generado un usuario aleatorio\nUsuario:" + usuario + "\nContraseña: " + contraseña);
                    }
                    else
                        AgregarParaInsert("id_usuario", idUser);
                    if (Conexion.getInstance().Insertar(Conexion.Tabla.Cliente, datos)!=-1)
                    
                        DialogResult = DialogResult.OK;
                        
                    
                    else
                        DialogResult = DialogResult.Abort;
                }
            }
            flag = true;
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
            List<string> columnas = new List<string>();
            columnas.Add("Cli_Dni");
            Dictionary<string, string> filtroCliDni = new Dictionary<string, string>();
            filtroCliDni.Add("Cli_Dni", Conexion.Filtro.Exacto(txtDoc.Text));


            if (Conexion.getInstance().existeRegistro(Conexion.Tabla.Cliente, columnas, filtroCliDni))
            {
                MessageBox.Show("Ese DNI está en uso. Elija otro.");
                txtDoc.Text = string.Empty;
            }
            else
            {
                AgregarParaInsert("cli_dni", txtDoc.Text);
            }
        }

        private void txtCUIL_Leave(object sender, EventArgs e)
        {
            List<string> columnas = new List<string>();
            columnas.Add("Cuil");
            Dictionary<string, string> filtro = new Dictionary<string, string>();
            filtro.Add("Cuil", Conexion.Filtro.Exacto(txtCUIL.Text));


            if (Conexion.getInstance().existeRegistro(Conexion.Tabla.Cliente, columnas, filtro))
            {
                MessageBox.Show("Ese cuil está en uso. Elija otro.");
                txtCUIL.Text = string.Empty;
            }
            else
            {
                AgregarParaInsert("cuil", txtCUIL.Text);
            }
            
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
            AgregarParaInsert("cli_fecha_nac", dtpNac.Value.ToString("yyyy-MM-dd hh:mm:ss"));
        }

        private void AltaCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!flag)
            {
                MessageBox.Show("No se pudo cancelar");
                e.Cancel = true;
            }
        }

        private void SoloNumerico(ref KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumerico(ref e);
        }

        private void txtCodPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumerico(ref e);
        }

        private void txtDepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumerico(ref e);
        }

        private void txtTel_keyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumerico(ref e);
        }

        private void cbbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTipo.Text != "DNI")
                txtCUIL.Enabled = false;
            if (cbbTipo.Text != "DNI" && datos.ContainsKey("cuil"))
                datos.Remove("cuil");
            else if (chbDepto.Text == "DNI" && !string.IsNullOrEmpty(txtCUIL.Text))
                datos["cuil"] = txtCUIL.Text;

        }
    }
}
