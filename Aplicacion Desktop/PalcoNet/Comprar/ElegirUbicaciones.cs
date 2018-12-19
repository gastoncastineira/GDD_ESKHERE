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
    public partial class ElegirUbicaciones : Form
    {
        String nomUsr;
        private Dictionary<string, object> datos = new Dictionary<string, object>();
        public ElegirUbicaciones(DataGridViewCellCollection data,string nombreUsuario)
        {
            nomUsr = nombreUsuario;
            int id;
            List<string> idUbis=new List<string>();
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            InitializeComponent();
           
            id = Convert.ToInt32(data["ID"].Value);
            filtros.Add("Publicacion", Conexion.Filtro.Exacto(id.ToString()));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.UbicacionesParaListar, ref dgvUbis, filtros);
            dgvUbis.Columns.Remove("Publicacion");
            

            dgvUbis.Sort(this.dgvUbis.Columns["Codigo_de_Ubicacion"], ListSortDirection.Ascending);

            this.cargaElComboDeIds();

            cmbMedioPago.Items.Add("Efectivo");
            cmbMedioPago.Items.Add("Boleta electrónica");
            cmbMedioPago.Items.Add("Tarjeta de crédito");
            cmbMedioPago.Text = "Tarjeta de crédito";

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarCompra_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> filtrosUbisSelec = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(cmbUbicacion.Text)) { 

                filtrosUbisSelec.Add("Codigo_de_Ubicacion", Conexion.Filtro.Exacto(cmbUbicacion.Text));

                List<string> columnas = new List<string>();
                columnas.Add("precio");

                List<object> resultadoConsulta = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.UbicacionesParaListar, columnas, filtrosUbisSelec))["precio"]);

                lstPrecios.Items.Add(resultadoConsulta[0].ToString());
                lstIds.Items.Add(cmbUbicacion.Text);
                cmbUbicacion.Items.RemoveAt(cmbUbicacion.SelectedIndex);

                txtPrecio.Text = (Convert.ToInt32(txtPrecio.Text) + Convert.ToInt32(resultadoConsulta[0].ToString())).ToString();
            }
            else { MessageBox.Show("Seleccione una ubicación del listado despegable por favor."); }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void dgvUbis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void ElegirUbicaciones_Load(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.cargaElComboDeIds();
            lstIds.Items.Clear();
            lstPrecios.Items.Clear();
            txtPrecio.Text = 0.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(lstIds.Text))
            {
                txtPrecio.Text = (Convert.ToInt32(txtPrecio.Text) - Convert.ToInt32(lstPrecios.Items[lstIds.SelectedIndex])).ToString();

                cmbUbicacion.Items.Add(lstIds.SelectedItem);
                lstPrecios.Items.RemoveAt(lstIds.SelectedIndex);
                lstIds.Items.RemoveAt(lstIds.SelectedIndex);
                
            }
            else { MessageBox.Show("Seleccione la ubicación que quiere eliminar."); }
        }

        private void cargaElComboDeIds()
        {
            cmbUbicacion.Items.Clear();
            List<string> idUbis = new List<string>();
            for (int rows = 0; rows < dgvUbis.Rows.Count ; rows++)
            {
                idUbis.Add(dgvUbis.Rows[rows].Cells["Codigo_de_Ubicacion"].Value.ToString());
            }
            idUbis.Sort();
            idUbis = idUbis.Distinct().ToList();
            for (int i = 0; i < idUbis.Count(); i++)
            {
                cmbUbicacion.Items.Add(idUbis[i].ToString());
            }
        }

        private void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            //chequeo que haya items a comprar e importe positivo
            if (lstIds.Items.Count > 0 && Convert.ToInt32(txtPrecio.Text) > 0 )
            {
                //consulto por el usuario 
                List<string> columnas = new List<string>();
                columnas.Add("idCliente");
                columnas.Add("nombreUsr");
                columnas.Add("numero_tarjeta_credito");

                Dictionary<string, string> filtrosUsr = new Dictionary<string, string>();
                filtrosUsr.Add("nombreUsr", Conexion.Filtro.Exacto(nomUsr));

                Dictionary<string, List<object>> resultadoConsulta = (Conexion.getInstance().ConsultaPlana(Conexion.Tabla.idDelCliente, columnas, filtrosUsr));

                List<object> resultadoID = resultadoConsulta["idCliente"];
                List<object> resultadoNumTarj = resultadoConsulta["numero_tarjeta_credito"];
                List<object> resultadoUsr = resultadoConsulta["nombreUsr"];

                //si selecciono tarjeta me fijo si tiene o no tarjeta 
                if (cmbMedioPago.Text == "Tarjeta de crédito") {

                    //label8.Text = "llegue id= "+resultadoID[0].ToString()+" numero tarjeta " + resultadoNumTarj[0].ToString() + " separo nombre de usuario " +nomUsr + " " +resultadoUsr[0].ToString() ;

                    if (string.IsNullOrWhiteSpace(resultadoNumTarj[0].ToString()))
                    {
                        MessageBox.Show("No tiene ninguna tarjeta de credito asociada, se le pedira que asocie una.");
                        AgregarTarjeta agregTarj = new AgregarTarjeta(resultadoConsulta["idCliente"][0].ToString());
                        agregTarj.ShowDialog();
                    }
                }

                //inserto en compras :)
                List<string> idsUbicaciones = new List<string>();
                for (int i = 0; i < lstIds.Items.Count; i++)
                {
                    idsUbicaciones.Add(lstIds.Items[i].ToString());
                }
                if (Conexion.getInstance().InsertarCompras(resultadoID[0].ToString(),"1", cmbMedioPago.Text,idsUbicaciones))
                {
                    MessageBox.Show("Compra exitosa");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Falló la compra.");
                    DialogResult = DialogResult.Abort;

                }

            }
            else { MessageBox.Show("No tiene ninguna ubicacion seleccionada para comprar. Seleccione como minimo una."); }
        }

        private void AgregarParaInsert(string nombreCol, object data)
        {
            datos[nombreCol] = data;
        }
    }
}
