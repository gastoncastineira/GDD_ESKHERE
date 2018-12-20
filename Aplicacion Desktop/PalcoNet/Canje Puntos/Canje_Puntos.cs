using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Canje_Puntos
{
    public partial class Canje_Puntos : FormTemplate
    {
        public Canje_Puntos(int id_clienteP): base()
        {
            InitializeComponent();
            id_cliente = id_clienteP;


        }

        int id_cliente;
        private List<TextBox> textos = new List<TextBox>();
        private Dictionary<string, object> datos = new Dictionary<string, object>();
        private Dictionary<string, object> datosPuntos = new Dictionary<string, object>();

        private void cargarPtos_Premios(object sender, EventArgs e)
        {
            //Para el dgv de los premios asociados al cliente
            this.cargar_dgv_premios_cliente();

            //Obtengo la CANT MAX de ptos disponibles del cliente
            this.ptos_disp_cliente();

            //Aca obtengo el dgv de ptos disponibles
            this.cargar_dgv_ptos_cliente();

            if (isAdmin)
            {
                MessageBox.Show("El admin no puede canjear puntos. Puede ver los premios disponibles del sistema");

                btn_Aceptar.Enabled = false;
            }

            //Obtengo todos los premios del sistema
            Dictionary<string, string> filtrosPremios = new Dictionary<string, string>();
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Premios, ref dgv_Premios_Elegibles, filtrosPremios);
            cargaElComboDeIds();
            

        }
        private void ptos_disp_cliente()
        {

            Dictionary<string, string> filtroIDCliente = new Dictionary<string, string>();
            filtroIDCliente.Add("ID_Cliente", Conexion.Filtro.Exacto(id_cliente.ToString()));
            filtroIDCliente.Add("YearObtenido", Conexion.Filtro.Exacto(ConfigurationHelper.fechaActual.Year.ToString()));
            List<string> columnas = new List<string>();
            columnas.Add("Total_puntos");
            List<object> resultadoConsultaPtosCliente = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Vobtener_Puntos_cliente, columnas, filtroIDCliente))["Total_puntos"]);
            lbl_Puntos_Cliente.Text = resultadoConsultaPtosCliente[0].ToString();
        }
        private void cargar_dgv_premios_cliente()
        {
            Dictionary<string, string> filtrosPremiosCliente = new Dictionary<string, string>();
            filtrosPremiosCliente.Add("ID_Cliente", Conexion.Filtro.Exacto(id_cliente.ToString()));
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.PremiosPorCliente, ref dgv_PremiosPorCliente, filtrosPremiosCliente);
            
        }
        private void cargaElComboDeIds()
        {
            cmbIDsPremios.Items.Clear();
            List<string> idPremios = new List<string>();
            for (int rows = 0; rows < dgv_Premios_Elegibles.Rows.Count-1; rows++)
            {
                idPremios.Add(dgv_Premios_Elegibles.Rows[rows].Cells["ID"].Value.ToString());
            }
            idPremios.Sort();
            idPremios = idPremios.Distinct().ToList();
            for (int i = 0; i < idPremios.Count(); i++)
            {
                cmbIDsPremios.Items.Add(idPremios[i].ToString());
            }
        }
        private void cargar_dgv_ptos_cliente()
        {
            Dictionary<string, string> filtrosPtossCliente = new Dictionary<string, string>();
            filtrosPtossCliente.Add("ID_Cliente", Conexion.Filtro.Exacto(id_cliente.ToString()));
            filtrosPtossCliente.Add("year(FechaObtenIDos)", Conexion.Filtro.Exacto(ConfigurationHelper.fechaActual.Year.ToString()));//Tienen que ser de este año
            filtrosPtossCliente.Add("Utilizados", Conexion.Filtro.Between("0", "cant-1"));//Tienen que estar habilitados
            Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Puntos, ref dgv_Ptos_Cliente, filtrosPtossCliente);
            this.dgv_Ptos_Cliente.Sort(this.dgv_Ptos_Cliente.Columns["FechaObtenIDos"], ListSortDirection.Ascending);
        }
        private void AgregarParaInsert(string nombreCol, object data)
        {
            datos[nombreCol] = data;
        }
         private void AgregarParaUpdate(string nombreCol, object data)
        {
            datosPuntos[nombreCol] = data;
        }


        private void CanjearPremio_Leave(object sender, EventArgs e)
        {
            //Tengo que agregar en la tabla intermedia el id del premio y el id del cliente
            //AgregarParaInsert("ID_premio", Convert.ToInt32(cmbIDsPremios.Text));
        }

        private void btn_Canje_Premios(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbIDsPremios.Text))
            {
                //Aca filtro x id cliente la cantidad de ptos que tiene el cliente
                Dictionary<string, string> filtrosPtosCliente = new Dictionary<string, string>();
                filtrosPtosCliente.Add("ID_Cliente", Conexion.Filtro.Exacto(id_cliente.ToString()));
                List<string> columnasCliente = new List<string>();
                columnasCliente.Add("Total_puntos");
                List<object> resultadoConsultaPtosCliente = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Vobtener_Puntos_cliente, columnasCliente, filtrosPtosCliente))["Total_puntos"]);
                int ptos_actuales_cliente = Convert.ToInt32(resultadoConsultaPtosCliente[0].ToString());
                lbl_Puntos_Cliente.Text = resultadoConsultaPtosCliente[0].ToString();

                //Aca obtengo el id del premio que quiero canjear
                Dictionary<string, string> filtrosPuntosPremio = new Dictionary<string, string>();
                filtrosPuntosPremio.Add("ID", Conexion.Filtro.Exacto(cmbIDsPremios.Text.ToString()));
                //Consulta para los ptos que cuesta el premio
                List<string> columnasPremio = new List<string>();
                columnasPremio.Add("Puntos");
                List<object> resultadoConsultaPtosPremio = ((Conexion.getInstance().ConsultaPlana(Conexion.Tabla.CostoPremio, columnasPremio, filtrosPuntosPremio))["Puntos"]);
                int ptos_premio = Convert.ToInt32(resultadoConsultaPtosPremio[0]);
                if (dgv_Ptos_Cliente.Rows.Count >1 &&  dgv_Ptos_Cliente.Rows != null)
                {
                    //Aca evaluo si tengo ptos suf para hacer el canje
                    if (ptos_actuales_cliente > ptos_premio)
                    {
                        DialogResult = DialogResult.OK;
                        //Aca resuelvo la logica de quitarle los ptos al cliente, empezando de los mas viejos a los mas nuevos siempre y cuando esten habilitados
                        foreach (DataGridViewRow row in dgv_Ptos_Cliente.Rows)
                        {
                            //Checkeo si los ptos actuales son mayores a los del premio
                            int ptos_Cant = Convert.ToInt32(row.Cells["Cant"].Value.ToString());// - Convert.ToInt32(row.Cells["Utilizados"].Value.ToString());
                            int id_fila_ptos = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                            int ptos_utilizados = Convert.ToInt32(row.Cells["Utilizados"].Value.ToString());

                            //Aca hay 2 caminos, que alcance con lo disponible o que no alcance
                            if ((ptos_Cant - ptos_utilizados - ptos_premio) >= 0)//ALCANZA
                            {

                                ptos_utilizados += ptos_premio;

                                //AgregarParaUpdate("Utilizados", ptos_premio.ToString());
                                AgregarParaUpdate("Utilizados", ptos_utilizados.ToString());
                                Conexion.getInstance().Modificar(id_fila_ptos, Conexion.Tabla.Puntos, datosPuntos);

                                AgregarParaInsert("ID_premio", Convert.ToInt32(cmbIDsPremios.Text));
                                AgregarParaInsert("ID_cliente", id_cliente);
                                Conexion.getInstance().Insertar(Conexion.Tabla.Cliente_Premio, datos);//Finalmente aca le adjudico el premio
                                this.ptos_disp_cliente();//Obtengo la CANT MAX (actual) de ptos disponibles del cliente
                                break;
                            }
                            else//Si NO es mayor, hago update y voy con el siguiente elemento
                            {
                                if (ptos_utilizados == 0)
                                { ptos_premio -= ptos_Cant; }
                                else { ptos_premio -= ptos_Cant - ptos_utilizados; }
                                AgregarParaUpdate("Utilizados", ptos_Cant.ToString());
                                Conexion.getInstance().Modificar(id_fila_ptos, Conexion.Tabla.Puntos, datosPuntos);
                            }
                        }//CIERRE DEL FOREACH

                        this.cargar_dgv_ptos_cliente();//Actualizo el dgv de pto cliente
                        this.cargar_dgv_premios_cliente();
                        //Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.PremiosPorCliente, ref dgv_PremiosPorCliente, filtrosPtosCliente);//Le adjudico el premio al titi
                    }
                    else
                    {
                        MessageBox.Show("Puntos insuficientes");

                    }
                }
                else { MessageBox.Show("No tiene puntos habilitados como para pedir premios."); }

            }
            else { MessageBox.Show("Seleccione un premio del listado despegable por favor.");}
        }

    }
}
