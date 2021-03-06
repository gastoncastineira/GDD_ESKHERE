﻿using System;
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
        private List<TextBox> textos = new List<TextBox>();
        private Dictionary<string, object> datos = new Dictionary<string, object>();
        List<string> textosSinModificar = new List<string>();
        private int id;
        string dniOG;
        string cuilOG ;

        public ModificarCliente(DataGridViewCellCollection data)
        {
            InitializeComponent();

            id = Convert.ToInt32(data["id"].Value);
            dniOG = data["Cli_Dni"].Value.ToString();
            cuilOG = data["Cuil"].Value.ToString();

            txtApel.Text = data["Cli_Apellido"].Value.ToString();
            textosSinModificar.Add(txtApel.Text);
            txtCodPostal.Text = data["Cod_Postal"].Value.ToString() ;
            textosSinModificar.Add(txtCodPostal.Text);
            txtCUIL.Text = data["Cuil"].Value.ToString();
            textosSinModificar.Add(txtCUIL.Text);
            txtDepto.Text = data["Depto"].Value.ToString();
            textosSinModificar.Add(txtDepto.Text);
            txtDir.Text = data["Calle"].Value.ToString();
            textosSinModificar.Add(txtDir.Text);
            txtDoc.Text = data["Cli_Dni"].Value.ToString();
            textosSinModificar.Add(txtDoc.Text);
            txtLocalidad.Text = data["Localidad"].Value.ToString();
            textosSinModificar.Add(txtLocalidad.Text);
            txtMail.Text = data["Cli_mail"].Value.ToString() ;
            textosSinModificar.Add(txtMail.Text);
            txtNombre.Text = data["Cli_nombre"].Value.ToString();
            textosSinModificar.Add(txtNombre.Text);
            txtPiso.Text = data["piso"].Value.ToString();
            textosSinModificar.Add(txtPiso.Text);
            txtTel.Text = data["telefono"].Value.ToString() ;
            textosSinModificar.Add(txtTel.Text);
            dtpNac.Text = data["cli_fecha_nac"].Value.ToString();
            textosSinModificar.Add(dtpNac.Text);
            cbbTipo.Text = data["tipo_doc"].Value.ToString();
            textosSinModificar.Add(cbbTipo.Text);
            if (string.IsNullOrEmpty(txtPiso.Text))
                chbPiso.Enabled = true;
            if (string.IsNullOrEmpty(txtDepto.Text))
                chbDepto.Enabled = true;

            foreach(Control c in Controls)
            {
                if (c is TextBox)
                    textos.Add(c as TextBox);
            }
            textos.Remove(txtDepto);
            textos.Remove(txtPiso);
            dtpNac.MaxDate = ConfigurationHelper.fechaActual;
        }

        private bool cuilEsValido(object sender)
        {
            string cuil = txtCUIL.Text;
            if (cbbTipo.Text == "LE")
                return true;
            if ((cuil.Substring(0, 2).Equals("20") || cuil.Substring(0, 2).Equals("23") || cuil.Substring(0, 2).Equals("24") || cuil.Substring(0, 2).Equals("27"))/* && cuil.Substring(4, cuil.Length - 2).Equals(txtDoc.Text)*/)
            { return CalculoCUITCUIL.cuitEsValido(sender.ToString()); }
            return false;
        }

        private void AgregarParaUpdate(string nombreCol, object data)
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
                    if (Conexion.getInstance().Modificar(id, Conexion.Tabla.Cliente, datos))
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
            AgregarParaUpdate("Cli_nombre", txtNombre.Text.ToUpper());
        }

        private void txtApel_Leave(object sender, EventArgs e)
        {
            AgregarParaUpdate("Cli_Apellido", txtApel.Text);
        }

        private void txtDoc_Leave(object sender, EventArgs e)
        {
            
            List<string> columnas = new List<string>();
            columnas.Add("cli_dni");
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            filtros.Add("cli_dni", Conexion.Filtro.Exacto(txtDoc.Text));
            filtros.Add("cli_dni ", Conexion.Filtro.Distinto(dniOG));

            if (Conexion.getInstance().existeRegistro(Conexion.Tabla.Cliente, columnas, filtros))
            {
                MessageBox.Show("Ese DNI ya está en uso. Elija otro o siga usando el mismo.");
                txtDoc.Text = dniOG;
            }
            else { AgregarParaUpdate("cli_dni", txtDoc.Text);}
        }

        private void txtCUIL_Leave(object sender, EventArgs e)
        {
            List<string> columnas = new List<string>();
            columnas.Add("Cuil");
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            filtros.Add("Cuil", Conexion.Filtro.Exacto(txtCUIL.Text));
            filtros.Add("Cuil ", Conexion.Filtro.Distinto(cuilOG));

            if (Conexion.getInstance().existeRegistro(Conexion.Tabla.Cliente, columnas, filtros))
            {
                MessageBox.Show("Ese cuil ya está en uso. Elija otro o siga usando el mismo.");
                txtCUIL.Text = cuilOG;
            }
            else {AgregarParaUpdate("cuil", txtCUIL.Text); }
            
        }

        private void txtMail_Leave(object sender, EventArgs e)
        {
            AgregarParaUpdate("cli_mail", txtMail.Text);
        }

        private void cbbTipo_Leave(object sender, EventArgs e)
        {
            AgregarParaUpdate("Tipo_Doc", cbbTipo.Text);
        }

        private void txtTel_Leave(object sender, EventArgs e)
        {
            AgregarParaUpdate("telefono", txtTel.Text);
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

        private void dtpNac_Leave(object sender, EventArgs e)
        {
            AgregarParaUpdate("cli_fecha_nac", dtpNac.Value.ToString("yyyy-MM-dd hh:mm:ss"));
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

        private void txtCUIL_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
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
