using System;
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
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
            List<string> columnas = new List<string>();
            columnas.Add("anio"); 
            List<object> resultadoConsulta = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.AnioMinimo, columnas, null))["anio"]) ;
            //resultadoConsulta.Sort(); 
            //cmbAño.DataSource = resultadoConsulta;
            int añoactual = ConfigurationHelper.fechaActual.Year;
            
            for (int año = añoactual; año>= Convert.ToInt32(resultadoConsulta[0]); año--)
            {
                cmbAño.Items.Add(año);
            }
            cmbAño.Text = añoactual.ToString();
            cmbTrimestre.Items.Add("1");
            cmbTrimestre.Items.Add("2");
            cmbTrimestre.Items.Add("3");
            cmbTrimestre.Items.Add("4");
           
        }

        private void btnClientesPtsVnc_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> filtros = this.ArmaFiltroDeAñoYTrimestre(cmbTrimestre.Text, cmbAño.Text, "FechaObtenIDos");
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.CliMayorPtosVencidos, ref dgv, filtros);
            lblPiola.Text = "Clientes con mayores puntos vencidos";
        }

        private void btnClientesCantCompra_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> filtros = this.ArmaFiltroDeAñoYTrimestre(cmbTrimestre.Text, cmbAño.Text, "fechaCompra");
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.CliMayorCantCompras, ref dgv, filtros);
            lblPiola.Text= "Clientes con mayor cantidad de compras";
        }

        private void btnEmpresasLocNoVendidas_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> filtros = this.ArmaFiltroDeAñoYTrimestre(cmbTrimestre.Text, cmbAño.Text, "fechaPublicacion");
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.EmpMayorCantUbiSinVender, ref dgv, filtros);
            lblPiola.Text = "Empresas con mayor cantidad de ubicaciones no vendidas";
        }
        private Dictionary<string, string> ArmaFiltroDeAñoYTrimestre(string trimestre, string año, string campoFecha)
        {
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            filtros.Add("YEAR(" + campoFecha + ")", Conexion.Filtro.Exacto(año));
            switch (trimestre) {
                case "1":
                    filtros.Add("MONTH("+ campoFecha +")", Conexion.Filtro.Between("1", "3"));
                    break;
                case "2":
                    filtros.Add("MONTH(" + campoFecha + ")", Conexion.Filtro.Between("4", "6"));
                    break;
                case "3":
                    filtros.Add("MONTH(" + campoFecha + ")", Conexion.Filtro.Between("7", "9"));
                    break;
                case "4":
                    filtros.Add("MONTH(" + campoFecha + ")", Conexion.Filtro.Between("10", "12"));
                    break;

            }
            return filtros;
        }
    }
}
