﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Rol
{
    public partial class ListadoRoles : FormTemplate
    {
        public ListadoRoles() : base()
        {
            InitializeComponent();
        }

        private void MostrarResultado(DialogResult dr)
        {
            if (dr == DialogResult.OK)
                MessageBox.Show("Se actualizó correctamente");
            if (dr == DialogResult.Abort)
                MessageBox.Show("Se encontró un error fatal y se abortó la actualización");
            if (dr == DialogResult.Cancel)
                MessageBox.Show("Se canceló la solicitud");
        }

        private void ListadoRoles_Load(object sender, EventArgs e)
        {
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Rol, ref dataGridView1, null);
            dataGridView1.Rows.RemoveAt(1);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MostrarResultado(new ModificarRol(Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["id"].Value), dataGridView1.SelectedCells[0].OwningRow.Cells["nombre"].Value.ToString()).ShowDialog());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MostrarResultado(new CrearRol().ShowDialog());
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            Conexion.getInstance().deshabilitar(Conexion.Tabla.Rol, Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["id"].Value));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Rol, ref dataGridView1, null);
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            Conexion.getInstance().habilitar(Conexion.Tabla.Rol, Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["id"].Value));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Rol, ref dataGridView1, null);
        }
    }
}
