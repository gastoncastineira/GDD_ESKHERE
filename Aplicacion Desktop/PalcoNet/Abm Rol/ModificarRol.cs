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
    public partial class ModificarRol : Form
    {
        int idRol;
        private List<Funcion> funcionesOriginales = new List<Funcion>();
        public ModificarRol(int id, string nombre)
        {
            idRol = id;
            InitializeComponent();
            txtNombre.Text = nombre;
        }

        private void ModificarRol_Load(object sender, EventArgs e)
        {
            Dictionary<string, List<object>> resul = Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Funcion, new List<string>(new string[] {"id", "nombre" }), null);
            //resul["nombre"].ForEach(o => checkedListBoxFuncion.Items.Add(o.ToString(), false));
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            for (int i = 1; i<=resul["nombre"].Count;i++)
            { 
                filtros["id_rol"] = Conexion.Filtro.Exacto(idRol.ToString());
                filtros["id_funcion"] = Conexion.Filtro.Exacto(i.ToString());
                checkedListBoxFuncion.Items.Add(resul["nombre"][i-1], (Conexion.getInstance().existeRegistro(Conexion.Tabla.RolXFuncion, new List<string>(new string[] { "id_rol", "id_funcion" }), filtros)));
            }

            for (int i = 1; i <= checkedListBoxFuncion.Items.Count; i++)
            {
                if (checkedListBoxFuncion.GetItemChecked(i-1))
                {
                    funcionesOriginales.Add((Funcion)i);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Funcion> aBorrar = new List<Funcion>();
            List<Funcion> aInsertar = new List<Funcion>();
            for (int i = 1; i <= checkedListBoxFuncion.Items.Count; i++)
            {
                if (checkedListBoxFuncion.GetItemChecked(i - 1) && !funcionesOriginales.Contains((Funcion)i))
                    aInsertar.Add((Funcion)i);
                if (!checkedListBoxFuncion.GetItemChecked(i - 1) && funcionesOriginales.Contains((Funcion)i))
                    aBorrar.Add((Funcion)i);
            }
            Dictionary<string, object> datos = new Dictionary<string, object>();
            datos["id_rol"] = idRol;
            foreach(int v in aInsertar)
            {
                datos["id_funcion"] = v;
                if (Conexion.getInstance().Insertar(Conexion.Tabla.RolXFuncion, datos)==-1)
                {
                    DialogResult = DialogResult.Abort;
                    return;
                }

            }
            foreach (int v in aBorrar)
            {
                datos["id_funcion"] = v;
                if (!Conexion.getInstance().eliminarTablaIntermedia(Conexion.Tabla.RolXFuncion, "id_rol", "id_funcion", idRol, v))
                {
                    DialogResult = DialogResult.Abort;
                    return;
                }
            }
            DialogResult = DialogResult.OK;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
