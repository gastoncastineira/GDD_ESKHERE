using System;
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
    public partial class Comprar : Form
    {
        String nomUsr;

        public Comprar(string nombreUsuario)
        {
            nomUsr = nombreUsuario;
            InitializeComponent();
            List<string> columnas = new List<string>();
            columnas.Add("Publicacion_Rubro");
            List<object> resultadoConsulta = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Rubros, columnas, null))["Publicacion_Rubro"]);
            for (int i=0; i<resultadoConsulta.Count();i++)
            {
                chkLBCat.Items.Add(resultadoConsulta[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

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
            if(!string.IsNullOrWhiteSpace(descripcion.Text))
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
            filtros=this.ArmaFiltro(categorias, descrip, desde.Date.ToShortDateString(), hasta.Date.ToShortDateString());
            
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.PublicacionesParaListar, ref dgvPublicaciones, filtros);
            dgvPublicaciones.Columns.Remove("FVenc");
            dgvPublicaciones.Sort(this.dgvPublicaciones.Columns["grado"], ListSortDirection.Ascending);
            dgvPublicaciones.Columns.Remove("grado");
        }

        private void fechaDesde_ValueChanged(object sender, EventArgs e)
        {
            fechaDesde.CustomFormat = " ";
            fechaDesde.Format = DateTimePickerFormat.Custom;
        }

        private void fechaHasta_ValueChanged(object sender, EventArgs e)
        {
            fechaHasta.CustomFormat = " ";
            fechaHasta.Format = DateTimePickerFormat.Custom;
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
            for (int i = 0; i < categorias.Count(); i++)
            {
                filtros.Add("Publicacion_Rubro", Conexion.Filtro.Exacto(categorias[i]));
            }
            //filtros.Add("FFuncion", Conexion.Filtro.Between('\'' + desde + '\'', '\'' + hasta + '\''));
            //filtros.Add("FVenc",Conexion.Filtro.MenorIgual('\''+ConfigurationHelper.fechaActual.ToShortDateString() + '\''));
            //filtros.Add("FFuncion ", Conexion.Filtro.MenorIgual(ConfigurationHelper.fechaActual.ToShortDateString()));
            return filtros;
        }

        private void dgvPublicaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Comprar_Load(object sender, EventArgs e)
        {

        }

        private void dgvPublicaciones_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            btnElegir.Enabled = true;
        }
    }
}
