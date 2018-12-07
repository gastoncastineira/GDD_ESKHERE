using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        public GenerarPublicacion()
        {
            InitializeComponent();
            funciones = new List<DateTime>();
            ubicaciones = new List<Ubicacion>();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void GenerarPublicacion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //Cheque que la fecha ingresada sea mayor que las anteriores
            if (esFechaMayor(dateTimePicker1.Value))
            {
                //agrego fecha de funcion
                String fecha = dateTimePicker1.ToString();
                
                listView1.Items.Add(fecha);
            }
        }

        private List<DateTime> obtenerFunciones()
        {
            List<DateTime> fechas=new List<DateTime>();
            CultureInfo provider = CultureInfo.InvariantCulture;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                DateTime fecha = Convert.ToDateTime(listView1.Items[i].SubItems[0].Text);
                fechas.Add(fecha);
                
            }
            return fechas;
        }

        private Boolean esFechaMayor(DateTime fecha)
        {
            List<DateTime> fechas = obtenerFunciones();
            return fechas.All(f=>f < fecha);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            ubicaciones.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            Publicacion publicacion = new Publicacion();
            List<DateTime> funcionesNuevas = new List<DateTime>();
            List<Ubicacion> ubicacionesNuevas = new List<Ubicacion>();

            publicacion.descripcion = descripcion.Text;
            publicacion.rubro = rubro.Text;
            publicacion.estado = estado.Text;
            publicacion.direccion = direccion.Text;
            publicacion.grado = grado.Text;
            publicacion.funciones = obtenerFunciones();
            publicacion.ubicaciones = ubicaciones;
        }
    }
}
