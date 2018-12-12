﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Listado_Estadistico
{
    public partial class CliMayoresPtosvencidos : Form
    {
        public CliMayoresPtosvencidos(Dictionary<string, string> filtros)
        {
            InitializeComponent();
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.CliMayorPtosVencidos, ref dgvCMPV, filtros);
        }


    }
}
