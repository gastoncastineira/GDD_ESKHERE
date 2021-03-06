﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Grado
{
    public partial class AltaGrado : Form
    {
        private Dictionary<string, object> datos = new Dictionary<string, object>();

        public AltaGrado()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(txtComision.Text);
            if (val > 1.0 || val < 0)
            {
                MessageBox.Show("La comision debe ser un valor entre 0 y 1");
                return;
            }
            if (Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
                MessageBox.Show("Se detectaron algunos campos obligatorios nulos. Revise");
            else
            {
                if (Conexion.getInstance().Insertar(Conexion.Tabla.Grado, datos)!=-1)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                    DialogResult = DialogResult.Abort;

            }
        }

        private void AgregarParaInsert(string nombreCol, object data)
        {
            datos[nombreCol] = data;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("descripcion", txtNombre.Text);
        }

        private void txtComision_Leave(object sender, EventArgs e)
        {
            AgregarParaInsert("comision", Convert.ToDouble(txtComision.Text));
        }

        private void soloNumerico(object sender, KeyPressEventArgs e)
        {
            if (txtComision.Text == string.Empty || txtComision.Text == "0")
            {
                txtComision.Text = "0," + e.KeyChar;
                e.Handled = true;
                txtComision.SelectionStart = txtComision.Text.Length;
                txtComision.SelectionLength = 0;
            }
            if (char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }
    }
}
