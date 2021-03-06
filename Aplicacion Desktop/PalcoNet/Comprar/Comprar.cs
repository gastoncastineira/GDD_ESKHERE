﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Comprar
{
    public partial class Comprar : FormTemplate
    {
        String nomUsr;
        private DataTable datos;
        private int numPag = 0;

        public Comprar(string nombreUsuario) : base()
        {
            nomUsr = nombreUsuario;
            InitializeComponent();
            List<string> columnas = new List<string>();
            columnas.Add("Publicacion_Rubro");
            fechaDesde.MinDate = ConfigurationHelper.fechaActual;
            List<object> resultadoConsulta = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Rubros, columnas, null))["Publicacion_Rubro"]);
            for (int i=0; i<resultadoConsulta.Count;i++)
            {
                chkLBCat.Items.Add(resultadoConsulta[i]);
            }
            if(isAdmin)
            {
                MessageBox.Show("El administrador no puede realizar compras. Puede ver el formulario pero no confirmar");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnAvanzaPag.Enabled = true;
            btnRetrocede.Enabled = true;
            btnPrimeraPag.Enabled = true;
            btnUltimaPag.Enabled = true;
            List<String> categorias = new List<string>();
            String descrip;
            DateTime desde = DateTime.Now;
            DateTime hasta = DateTime.Now;
            Dictionary<string, string> filtros = new Dictionary<string, string>();

            //tomo valores
            if (chkLBCat.CheckedItems.Count > 0)
            {
                foreach (String s in chkLBCat.CheckedItems)
                {
                    categorias.Add(s);
                }
            }
            if (!string.IsNullOrWhiteSpace(descripcion.Text))
            {
                descrip = descripcion.Text;
            }
            else descrip = null;
            if (!string.IsNullOrWhiteSpace(fechaDesde.Value.ToString()))
            {
                desde = fechaDesde.Value;
            }
            if (!string.IsNullOrWhiteSpace(fechaHasta.Value.ToString()) && fechaHasta.Value >= desde)
            {
                hasta = fechaHasta.Value;
            }
            filtros = this.ArmaFiltro(categorias, descrip, desde.Date.ToString("yyyy-MM-dd hh:mm:ss"), hasta.Date.ToString("yyyy-MM-dd hh:mm:ss"));
            datos = Conexion.getInstance().conseguirTabla(Conexion.Tabla.PublicacionesParaListar, filtros);
            datos.Columns.Remove("FVenc");
            DataView dv = datos.DefaultView;
            dv.Sort = "grado asc";
            datos = dv.ToTable();
            datos.Columns.Remove("grado");
            pasarPagina();
            
            //Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.PublicacionesParaListar, ref dgvPublicaciones, filtros);
            //dgvPublicaciones.Sort(this.dgvPublicaciones.Columns["grado"], ListSortDirection.Ascending);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chkLBCat.ClearSelected();
            descripcion.Clear();
            fechaDesde.CustomFormat = " ";
            fechaDesde.Format = DateTimePickerFormat.Custom;
            fechaHasta.CustomFormat = " ";
            fechaHasta.Format = DateTimePickerFormat.Custom;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ElegirUbicaciones elegirUbis = new ElegirUbicaciones(dgvPublicaciones.SelectedCells[0].OwningRow.Cells,nomUsr);
            elegirUbis.ShowDialog();


        }

        private Dictionary<string, string> ArmaFiltro(List<String> categorias, string descrip, string desde, string hasta)
        {
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(descrip)) { 
             filtros.Add("Descripcion", Conexion.Filtro.Exacto(descrip));
            }
            for (int i = 0; i < categorias.Count; i++)
            {
                filtros.Add("Publicacion_Rubro", Conexion.Filtro.Exacto(categorias[i]));
            }
            filtros.Add("FFuncion", Conexion.Filtro.Between('\'' + desde + '\'', '\'' + hasta + '\''));
            filtros.Add("FVenc", Conexion.Filtro.MayorIgual('\'' + ConfigurationHelper.fechaActual.ToString("yyyy-MM-dd hh:mm:ss") + '\''));
            filtros.Add("FFuncion ", Conexion.Filtro.MayorIgual("'" + ConfigurationHelper.fechaActual.ToString("yyyy-MM-dd hh:mm:ss") + "'"));
            return filtros;
        }

        private void dgvPublicaciones_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            btnElegir.Enabled = true;
        }

        private void btnRetrocede_Click(object sender, EventArgs e)
        {
            if (numPag > 0)
            {
                numPag--;
                pasarPagina();
            }
        }

        private void btnAvanzaPag_Click(object sender, EventArgs e)
        {
            int cantMaxPags = datos.Rows.Count / Convert.ToInt32(10) + 1;
            if (numPag < cantMaxPags)
            {
                numPag++;
                pasarPagina();
            }
        }

        private void pasarPagina()
        {
            int cantPag = numPag * 10;
            DataTable data = datos.Clone();
            
            for (int index = cantPag; index < cantPag + 10; index++)
            {
                try
                {
                    data.ImportRow(datos.Rows[index]);
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
            DataView dv = data.DefaultView;
            //dv.Sort = "ID desc";
            //data = dv.ToTable();
            dgvPublicaciones.DataSource = data;
            //dgvPublicaciones.Columns.Remove("grado");

        }

        private void btnPrimeraPag_Click(object sender, EventArgs e)
        {
            numPag = 0;
            int cantPag = numPag * 10;
            DataTable data = datos.Clone();

            for (int index = cantPag; index < cantPag + 10; index++)
            {
                try
                {
                    data.ImportRow(datos.Rows[index]);
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
            DataView dv = data.DefaultView;
            //dv.Sort = "ID desc";
            //data = dv.ToTable();
            dgvPublicaciones.DataSource = data;
            //dgvPublicaciones.Columns.Remove("grado");

        }

        private void btnUltimaPag_Click(object sender, EventArgs e)
        {
            numPag = datos.Rows.Count / Convert.ToInt32(10);
            int cantPag = numPag * 10;
            DataTable data = datos.Clone();

            for (int index = cantPag; index < cantPag + 10; index++)
            {
                try
                {
                    data.ImportRow(datos.Rows[index]);
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
            DataView dv = data.DefaultView;
            //dv.Sort = "ID desc";
            //data = dv.ToTable();
            dgvPublicaciones.DataSource = data;
        }
    }
}
