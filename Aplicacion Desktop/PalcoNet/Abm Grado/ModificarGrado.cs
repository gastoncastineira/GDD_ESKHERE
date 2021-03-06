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
    public partial class ModificarGrado : Form
    {

        private Dictionary<string, object> datos = new Dictionary<string, object>();
        private int id;

        public ModificarGrado(DataGridViewCellCollection data)
        {
            id = Convert.ToInt32(data["id"].Value);

            InitializeComponent();
            txtComision.Text = data["comision"].Value.ToString();
            txtNombre.Text = data["descripcion"].Value.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtComision.Text) || string.IsNullOrEmpty(txtNombre.Text))
                MessageBox.Show("Se detectaron campos vacios. Por favor, revise");
            else
            {
                if (Conexion.getInstance().Modificar(id, Conexion.Tabla.Grado, datos))
                    DialogResult = DialogResult.OK;
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
            AgregarParaInsert("comision", Convert.ToInt32(txtComision.Text));
        }


        private void soloNumerico(object sender, KeyPressEventArgs e)
        {
            if (txtComision.Text == string.Empty || txtComision.Text == "0")
                txtComision.Text = "0.";
            if (char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }
    }
}