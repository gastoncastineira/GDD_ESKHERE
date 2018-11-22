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

        public AltaEmpresa()
        {
            InitializeComponent();
        }

        private void chbPiso_CheckedChanged(object sender, EventArgs e)
        {
            this.txtDepto.Enabled = !this.txtDepto.Enabled;
        }

        private void chbDepto_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPiso.Enabled = !this.txtPiso.Enabled;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!cuitEsValido())
            {
                errorCUIT = true;
                this.Refresh();
            }
            //TODO: cambiar a null el piso y depto para isnertar en BD si no tiene el usuario. validar con Checkbox
            this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private bool cuitEsValido()
        {
            string cuil = txtCUIL.Text;
            if ((cuil.Substring(0, 2).Equals("20") || cuil.Substring(0, 2).Equals("23") || cuil.Substring(0, 2).Equals("24") || cuil.Substring(0, 2).Equals("27")) && cuil.Substring(4, cuil.Length - 2).Equals(txtRazon.Text))
                return true;
            return false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            //this.Close();
        }

        private void AltaEmpresa_Paint(object sender, PaintEventArgs e)
        {
                if (errorCUIT)
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
