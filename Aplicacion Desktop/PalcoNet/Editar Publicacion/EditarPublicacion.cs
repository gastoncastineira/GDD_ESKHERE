using PalcoNet.Generar_Publicacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Editar_Publicacion
{
    public partial class EditarPublicacion : Form
    {
        public EditarPublicacion(String descripcionM, String rubroM, String estadoM, String direccionM, String gradoM, List<DateTime> funcionesM, List<Ubicacion> ubicacionesM)
        {
            InitializeComponent();

            descripcion.Text = descripcionM;
            rubro.Text = rubroM;
            estado.Text = estadoM;
            direccion.Text = direccionM;
            grado.Text = gradoM;
            //agregar funciones
            //agregar ubicaciones
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime funcion = dateTimePicker1.Value;
            dataGridView1.Rows.Add(funcion);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String tipoU = tipo.Text;
            Int32 filasU = Convert.ToInt32(filas.Text);
            Int32 asientosU = Convert.ToInt32(asientos.Text);
            Decimal precioU = Convert.ToDecimal(precio.Text); ;
            dataGridView2.Rows.Add(tipoU, filasU, asientosU, precioU);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
        }

        private void EditarPublicacion_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //tomo datos
            String descripcionM = descripcion.Text;
            String rubroM = rubro.Text;
            String estadoM = estado.Text;
            String direccionM = direccion.Text;
            String gradoM = grado.Text;
            //agregar funciones
            //agregar ubicaciones

            //update
        }
    }
}
