﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Editar_Publicacion
{
    public partial class SeleccionarPublicacion : Form
    {
        public SeleccionarPublicacion()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Enviar al update fila seleccionada
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String rub = rubro.Text;
            String desc = descripcion.Text;
            String emp = empresa.Text;

            //filtrar
        }
    }
}
