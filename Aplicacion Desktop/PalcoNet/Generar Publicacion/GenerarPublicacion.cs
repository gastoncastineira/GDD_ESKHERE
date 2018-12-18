using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Generar_Publicacion
{
    public partial class GenerarPublicacion : Form
    {
        List<DateTime> funciones;
        List<Ubicacion> ubicaciones;
        //int idEmpresa;
        public GenerarPublicacion()
        {
            InitializeComponent();
            //this.idEmpresa = idEmpresa;
            funciones = new List<DateTime>();
            ubicaciones = new List<Ubicacion>();

        }

        private void GenerarPublicacion_Load(object sender, EventArgs e)
        {
            DataTable estados = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Estado, null);
            estado.DataSource = estados;
            estado.ValueMember = "ID";
            estado.DisplayMember = "Descripcion";
            DataTable grados = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Grado, null);
            grado.DataSource = grados;
            grado.ValueMember = "ID";
            grado.DisplayMember = "Descripcion";
            DataTable tipos = Conexion.getInstance().conseguirTabla(Conexion.Tabla.TipoUbicacion, null);
            ubicacionTipo.DataSource = tipos;
            ubicacionTipo.ValueMember = "tipo";
            ubicacionTipo.DisplayMember = "ubicacion_tipo_descripcion";
        }

        private void btnFuncion_Click(object sender, EventArgs e)
        {
            //Cheque que la fecha ingresada sea mayor que las anteriores
            if (esFechaMayor(dateTimePicker1.Value) && dateTimePicker1.Value.CompareTo(ConfigurationHelper.fechaActual) > 0)
            {
                //agrego fecha de funcion
                funciones.Add(dateTimePicker1.Value);

                ListViewItem fecha = new ListViewItem(dateTimePicker1.Value.Date.ToString());
                fecha.SubItems.Add(dateTimePicker1.Value.TimeOfDay.ToString());
                listView1.Items.Add(fecha);
            }
            else
            {
                if (dateTimePicker1.Value.CompareTo(ConfigurationHelper.fechaActual) < 0)
                {
                    MessageBox.Show("El dia que desea ingresar ya paso");
                }
                else
                {
                    MessageBox.Show("Debe ingresar una fecha y hora posteriores a las ya ingresadas");
                }

            }
        }

        private void btnLimpiarFunciones_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            funciones.Clear();
        }

        private void btnUbicacion_Click(object sender, EventArgs e)
        {

            if (Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            {
                MessageBox.Show("Se deben completar todos los campos");
            }
            else
            {
                //Agrego la ubicacion a la vista
                ListViewItem ubicacion = new ListViewItem(ubicacionTipo.Text);
                ubicacion.SubItems.Add(ubicacionFilas.Text);
                ubicacion.SubItems.Add(ubicacionAsientos.Text);
                ubicacion.SubItems.Add(ubicacionPrecio.Text);
                listView2.Items.Add(ubicacion);

                //agrego ubicacion a la lista
                Ubicacion ubicacionLista = new Ubicacion();
                ubicacionLista.tipo = ubicacionTipo.Text;
                ubicacionLista.filas = Convert.ToInt32(ubicacionFilas.Text);
                ubicacionLista.asientosPorFila = Convert.ToInt32(ubicacionAsientos.Text);
                ubicacionLista.precio = Convert.ToDecimal(ubicacionPrecio.Text);
                ubicaciones.Add(ubicacionLista);
            }
        }

        private void btnLimpiarUbicaciones_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            ubicaciones.Clear();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)) || !funciones.Any() || !ubicaciones.Any())
            {
                MessageBox.Show("Se deben completar todos los campos");
            }
            else
            {
                foreach (DateTime funcion in funciones)
                {
                    //inserto en tabla Publicacion_Fechas
                    Dictionary<string, object> datosFuncion = new Dictionary<string, object>();
                    datosFuncion["fpublicacion"] = ConfigurationHelper.fechaActual;
                    datosFuncion["ffuncion"] = funcion;
                    datosFuncion["fvenc"] = funcion;
                    if (Conexion.getInstance().Insertar(Conexion.Tabla.PublicacionFechas, datosFuncion)!=-1)
                    {
                        MessageBox.Show("Fecha insertada");
                    }
                    else
                    {
                        MessageBox.Show("Error fecha");
                    }
                    
                    //inserto en tabla PUblicacion
                    Dictionary<string, object> datosPublicacion = new Dictionary<string, object>();
                    datosPublicacion["ID_Fecha"] = Conexion.getInstance().Insertar(Conexion.Tabla.PublicacionFechas, datosFuncion);
                    //datosPublicacion["Codigo"] = Convert.ToInt32(Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Publicacion, new List<string>(new string[] { "SCOPE_IDENTITY() AS Codigo" }), null)["Codigo"][0]) +1;
                    datosPublicacion["Descripcion"] = descripcion.Text ;
                    datosPublicacion["Publicacion_Rubro"] = rubro.Text ;
                    datosPublicacion["ID_Empresa_Publicante"] = 10;
                    datosPublicacion["ID_grado"] =  grado.SelectedIndex +1;
                    datosPublicacion["ID_estado"] = estado.SelectedIndex +1;
                    if(Conexion.getInstance().Insertar(Conexion.Tabla.Publicacion, datosPublicacion)!=-1)
                    {
                        MessageBox.Show("publi insertada");
                    }
                    else
                    {
                        MessageBox.Show("Error publi");
                    }
/*
                    object idPublicacion = Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Publicacion, new List<string>(new string[] { "SCOPE_IDENTITY() AS id" }), null)["id"][0];
                    List<UbicacionIndividual> ubicacionesIndividuales = generarUbicacionesIndividuales();
                    //inserto en tabla ubicacion
                    foreach (UbicacionIndividual ubicacion in ubicacionesIndividuales)
                    {
                        Dictionary<string, object> datosUbicacion = new Dictionary<string, object>();
                        datosUbicacion["ubicacion_Fila"] = ubicacion.fila;
                        datosUbicacion["ubicacion_Asiento"] = ubicacion.asiento;
                        datosUbicacion["Ubicacion_Tipo_Descripcion"] = ubicacion.tipo;
                        Dictionary<string,string> filtroTipo = new Dictionary<string,string>();
                        filtroTipo.Add("Ubicacion_Tipo_Descripcion", ubicacion.tipo);
                        datosUbicacion["tipo"] = Conexion.getInstance().ConsultaPlana(Conexion.Tabla.TipoUbicacion, new List<string>(new string[] { "tipo" }), filtroTipo) ;
                        datosUbicacion["precio"] = ubicacion.precio;
                        datosUbicacion["ID_Publicacion"] = idPublicacion;
                    }*/
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private List<DateTime> obtenerFunciones()
        {
            List<DateTime> fechas = new List<DateTime>();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                DateTime fecha = Convert.ToDateTime(listView1.Items[i].SubItems[0].Text);
                fechas.Add(fecha);

            }
            return fechas;
        }

        private Boolean esFechaMayor(DateTime fecha)
        {
            return funciones.All(f => f < fecha);
        }

        private char obtenerLetra(int fila)
        {
            Dictionary<int, char> filas = diccionarioFilas();
            return filas[fila];
        }
        private Dictionary<int, char> diccionarioFilas()
        {
            Dictionary<int, char> filas = new Dictionary<int,char>();
            char letra ='A';
            for (int i = 1; i <= 27; i++)
            {
                filas.Add(i, letra);
                letra++;
            }
            return filas;

        }

        //desglose del conjunto de ubicaciones, y asignacion de letra a cada fila
        private List<UbicacionIndividual> generarUbicacionesIndividuales()
        {
            List<UbicacionIndividual> ubicacionesIndividuales = new List<UbicacionIndividual>();
            //recorro ubicaciones por tipo
            foreach (Ubicacion unaUbicacion in ubicaciones)
            {
                //recorro ubicaciones por fila
                for (int j = unaUbicacion.filas; j > 0; j--)
                {
                    //recorro ubicaciones por asiento
                    for (int k = unaUbicacion.asientosPorFila; k > 0; k--)
                    {
                        UbicacionIndividual ubicacion = new UbicacionIndividual();
                        ubicacion.tipo = unaUbicacion.tipo;
                        ubicacion.precio = unaUbicacion.precio;
                        ubicacion.fila = obtenerLetra(j);
                        ubicacion.asiento = k;
                        ubicacionesIndividuales.Add(ubicacion);
                    }
                }
            }

            return ubicacionesIndividuales;
        }

    }
}
