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
    public partial class GenerarPublicacion : FormTemplate
    {
        List<DateTime> funciones;
        List<Ubicacion> ubicaciones;
        List<Publicacion> publicaciones;
        //int idEmpresa;
        public GenerarPublicacion() : base()
        {
            InitializeComponent();
            //this.idEmpresa = idEmpresa;
            funciones = new List<DateTime>();
            ubicaciones = new List<Ubicacion>();
            publicaciones = new List<Publicacion>();

        }

        private void GenerarPublicacion_Load(object sender, EventArgs e)
        {
            DataTable estados = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Estado, null);
            estado.DataSource = estados;
            estado.ValueMember = "ID";
            estado.DisplayMember = "Descripcion";
            estado.SelectedIndex = -1;
            DataTable grados = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Grado, null);
            grado.DataSource = grados;
            grado.ValueMember = "ID";
            grado.DisplayMember = "Descripcion";
            grado.SelectedIndex = -1;
            DataTable tipos = Conexion.getInstance().conseguirTabla(Conexion.Tabla.TipoUbicacion, null);
            ubicacionTipo.DataSource = tipos;
            ubicacionTipo.ValueMember = "tipo";
            ubicacionTipo.DisplayMember = "ubicacion_tipo_descripcion";
            ubicacionTipo.SelectedIndex = -1;
            List<int> filas = new List<int>();
            for (int i = 1; i < 27; i++)
            {
                filas.Add(i);
            }
            ubicacionFilas.DataSource = filas;
            //ubicacionFilas.SelectedIndex = -1;
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

            if (Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)) || groupBox2.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            {
                MessageBox.Show("Se deben completar todos los campos");
            }
            else
            {
                if (ubicaciones.Any(ubicacion => ubicacion.tipo == ubicacionTipo.Text))
                {
                    MessageBox.Show("Ya cargo un conjunto de ubicaciones de ese tipo");
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
                    ubicacionLista.tipoId = Convert.ToInt32(ubicacionTipo.SelectedValue);
                    ubicacionLista.filas = Convert.ToInt32(ubicacionFilas.Text);
                    ubicacionLista.asientosPorFila = Convert.ToInt32(ubicacionAsientos.Text);
                    ubicacionLista.precio = Convert.ToDecimal(ubicacionPrecio.Text);
                    ubicaciones.Add(ubicacionLista);
                }

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
                DataTable codigoTabla = Conexion.getInstance().conseguirTabla(Conexion.Tabla.CodigoPublicacion, null);
                DataRow row = codigoTabla.Rows[0];
                Int32 codigo = Convert.ToInt32(row["codigo"])+1;
                for (int i = 0; i < funciones.Count;i++ )
                {
                    Publicacion publicacion = new Publicacion();
                    publicacion.descripcion = descripcion.Text;
                    publicacion.rubro = rubro.Text;
                    publicacion.grado = Convert.ToInt32(grado.SelectedValue);
                    publicacion.estado = Convert.ToInt32(estado.SelectedValue);
                    publicacion.codigo = codigo;
                    publicacion.direccion = direccion.Text;
                    publicaciones.Add(publicacion);
                }
                List<UbicacionIndividual> ubicacionesIndividuales = generarUbicacionesIndividuales();
                if (Conexion.getInstance().InsertarPublicaciones(10, publicaciones, funciones, ubicacionesIndividuales))
                {
                    MessageBox.Show("Se ha grenerado una nueva publicacion");
                }
                else
                {
                    MessageBox.Show("No se pudo generar la publicacion");
                }


            }
            //limpiar listas
            listView1.Items.Clear();
            funciones.Clear();
            listView2.Items.Clear();
            ubicaciones.Clear();
            publicaciones.Clear();
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
                        ubicacion.tipoDescripcion = unaUbicacion.tipo;
                        ubicacion.tipo = unaUbicacion.tipoId;
                        ubicacion.precio = unaUbicacion.precio;
                        ubicacion.fila = obtenerLetra(j);
                        ubicacion.asiento = k;
                        ubicacionesIndividuales.Add(ubicacion);
                    }
                }
            }

            return ubicacionesIndividuales;
        }


        private void ubicacionFilas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void ubicacionPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

    }
}
