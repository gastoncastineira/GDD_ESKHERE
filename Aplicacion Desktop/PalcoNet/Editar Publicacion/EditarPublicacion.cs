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
        List<string> fechasAEliminar;
        List<string> ubicacionesAEliminar;
        List<string> ubicacionesActuales;
        List<int> idsPublicaciones;
        List<DateTime> fechasAAgregar;
        List<Ubicacion> ubicacionesAAgregar;
        List<DateTime> fechasActuales;
        List<UbicacionIndividual> ubicacionesIndicidualesAAgregar;
        int idEmpresa;
        int codigoPublicacion;
        public EditarPublicacion(int codigoPublicacion,int idEmpresa)
        {
            InitializeComponent();
            this.codigoPublicacion = codigoPublicacion;
            this.idEmpresa = idEmpresa;
            this.fechasAEliminar = new List<string>();
            this.ubicacionesAEliminar = new List<string>();
            this.fechasAAgregar = new List<DateTime>();
            this.ubicacionesAAgregar = new List<Ubicacion>();
            this.ubicacionesActuales = new List<string>();
            this.fechasActuales = new List<DateTime>();
            this.ubicacionesIndicidualesAAgregar = new List<UbicacionIndividual>();
            this.idsPublicaciones=new List<int>();
        }

        private void EditarPublicacion_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            filtros.Add("Codigo", Conexion.Filtro.Exacto(codigoPublicacion.ToString()));
            filtros.Add("Habilitado", Conexion.Filtro.Exacto("1"));
            DataTable datos = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Publicacion,filtros);
            DataRow fila = datos.Rows[0];
            descripcionTxt.Text = fila["descripcion"].ToString();
            rubroTxt.Text = fila["publicacion_rubro"].ToString();
            direccionTxt.Text = fila["direccion"].ToString();
            llenarComboBox(fila);
            List<int> filas = new List<int>();
            for (int i = 1; i < 27; i++)
            {
                filas.Add(i);
            }
            ubicacionFilas.DataSource = filas;
            String id = fila["id"].ToString();
            llenarUbicacionesActuales(id);
            llenarFechasActuales(datos);
            obtenerPublicaciones(datos);
        }

        private void limpiarListas()
        {
            fechasAEliminar.Clear();
            ubicacionesAEliminar.Clear();
            ubicacionesActuales.Clear();
            idsPublicaciones.Clear();
            fechasAAgregar.Clear();
            ubicacionesAAgregar.Clear();
            fechasActuales.Clear();
            ubicacionesIndicidualesAAgregar.Clear();
        }

        private void obtenerPublicaciones(DataTable datos)
        {
            for (int i = 0; i < datos.Rows.Count;i++ )
            {
                DataRow fila=datos.Rows[i];
                idsPublicaciones.Add(Convert.ToInt32(fila["id"]));
            }
        }

        private void llenarComboBox(DataRow fila)
        {
            DataTable estados = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Estado, null);
            estadoTxt.DataSource = estados;
            estadoTxt.ValueMember = "ID";
            estadoTxt.DisplayMember = "Descripcion";
            estadoTxt.SelectedIndex = Convert.ToInt32(fila["id_estado"]) - 1;
            DataTable grados = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Grado, null);
            gradoTxt.DataSource = grados;
            gradoTxt.ValueMember = "ID";
            gradoTxt.DisplayMember = "Descripcion";
            gradoTxt.SelectedIndex = Convert.ToInt32(fila["id_grado"]) - 1;
            DataTable tipos = Conexion.getInstance().conseguirTabla(Conexion.Tabla.TipoUbicacion, null);
            ubicacionTipo.DataSource = tipos;
            ubicacionTipo.ValueMember = "tipo";
            ubicacionTipo.DisplayMember = "ubicacion_tipo_descripcion";
        }

        private void llenarUbicacionesActuales(String primerId)
        {
            dgvUbicacionesActuales.Columns.Clear();
            Dictionary<string, string> filtrosUbicaciones = new Dictionary<string, string>();
            filtrosUbicaciones.Add("ID_Publicacion", Conexion.Filtro.Exacto(primerId));
            DataTable ubicaciones = Conexion.getInstance().conseguirTabla(Conexion.Tabla.CantidadUbicaciones, filtrosUbicaciones);
            ubicaciones.Columns.Remove("ID_Publicacion");
            dgvUbicacionesActuales.DataSource = ubicaciones;
            dgvUbicacionesActuales.Columns[0].HeaderText = "Tipo";
            dgvUbicacionesActuales.Columns[1].HeaderText = "TipoId";
            dgvUbicacionesActuales.Columns[1].Width = 50;
            dgvUbicacionesActuales.Columns[2].HeaderText = "Filas";
            dgvUbicacionesActuales.Columns[2].Width = 50;
            dgvUbicacionesActuales.Columns[3].HeaderText = "Asientos";
            dgvUbicacionesActuales.Columns[3].Width = 70;
            dgvUbicacionesActuales.Columns[4].HeaderText = "Precio($)";
            dgvUbicacionesActuales.Columns[4].Width = 50;
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "Eliminar";
            dgvUbicacionesActuales.Columns.Add(chk);
            dgvUbicacionesActuales.AllowUserToAddRows = false;
        }

        private void llenarFechasActuales(DataTable tabla)
        {
            dgvFechasActuales.Columns.Clear();
            Dictionary<String,DateTime> idFechas = new Dictionary<string,DateTime>();
            DataTable fechas = new DataTable();
            foreach(DataRow fila in tabla.Rows)
            {
                String idFecha = fila["id_fecha"].ToString();
                Dictionary<string, string> filtroFecha= new Dictionary<string, string>();
                filtroFecha.Add("ID", Conexion.Filtro.Exacto(idFecha));
                DataTable fechaObtenida = Conexion.getInstance().conseguirTabla(Conexion.Tabla.PublicacionFechas, filtroFecha);
                DateTime dia = Convert.ToDateTime(fechaObtenida.Rows[0]["ffuncion"]);
                idFechas.Add(idFecha, dia);
            }
            dgvFechasActuales.DataSource = idFechas.ToArray();
            dgvFechasActuales.Columns[0].HeaderText = "ID";
            dgvFechasActuales.Columns[1].HeaderText = "Fecha";
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "Eliminar";
            dgvFechasActuales.Columns.Add(chk);
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            EditarPublicacion_Load(sender, e);
            btnLimpiarFunciones_Click_1(sender, e);
            btnLimpiarUbicaciones_Click_1(sender, e);
        }

        private void btnUbicacion_Click(object sender, EventArgs e)
        {
            if (Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)) || groupBox2.Controls.OfType<TextBox>().Any(t => string.IsNullOrEmpty(t.Text)))
            {
                MessageBox.Show("Se deben completar todos los campos");
            }
            else
            {
                if (ubicacionesAAgregar.Any(ubicacion => ubicacion.tipo == ubicacionTipo.Text) || existeUbicacion(ubicacionTipo.Text))
                {
                    MessageBox.Show("Ya existe un conjunto de ubicaciones de ese tipo");
                    ubicacionesActuales.Clear();
                    ubicacionesAEliminar.Clear();
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
                    ubicacionesAAgregar.Add(ubicacionLista);
                }

            }
        }

        private Boolean existeUbicacion(String tipo)
        {
            cargarUbicacionesAEliminar();
            return ubicacionesActuales.Any(ubicacion => ubicacion.Equals(tipo));
            
        }

        private void btnFuncion_Click(object sender, EventArgs e)
        {
            //Cheque que la fecha ingresada sea mayor que las anteriores
            if (esFechaMayor(dateTimePicker1.Value) && dateTimePicker1.Value.CompareTo(ConfigurationHelper.fechaActual) > 0)
            {
                if (existeFecha(dateTimePicker1.Value))
                {
                    MessageBox.Show("Ya existe una funcion en esa fecha y horario");
                    fechasAEliminar.Clear();
                    fechasActuales.Clear();
                }
                else
                {
                    //agrego fecha de funcion
                    fechasAAgregar.Add(dateTimePicker1.Value);

                    ListViewItem fecha = new ListViewItem(dateTimePicker1.Value.Date.ToString());
                    fecha.SubItems.Add(dateTimePicker1.Value.TimeOfDay.ToString());
                    listView1.Items.Add(fecha);
                }
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

        private Boolean existeFecha(DateTime fecha)
        {
            cargarFechasAEliminar();
            return fechasActuales.Any(unaFecha => unaFecha.Date.Equals(fecha.Date) && unaFecha.Hour.Equals(fecha.Hour) && unaFecha.Minute.Equals(fecha.Minute));
        }

        private Boolean esFechaMayor(DateTime fecha)
        {
            return fechasAAgregar.All(f => f < fecha);
        }

        private void btnLimpiarFunciones_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            fechasAAgregar.Clear();
        }

        private void cargarFechasAEliminar()
        {
            DataGridViewRow fila = new DataGridViewRow();
            List<string> fechas = new List<string>();
            for (int i = 0; i < dgvFechasActuales.Rows.Count;i++ )
            {
                fila = dgvFechasActuales.Rows[i];
                if (Convert.ToBoolean(dgvFechasActuales.Rows[i].Cells[2].Value))
                {
                    fechasAEliminar.Add(dgvFechasActuales.Rows[i].Cells[0].Value.ToString());
                   
                }
                else
                {
                    fechasActuales.Add(Convert.ToDateTime(dgvFechasActuales.Rows[i].Cells[1].Value));
                }
                
            }
        }

        private void cargarUbicacionesAEliminar()
        {
            DataGridViewRow fila = new DataGridViewRow();
            for (int i = 0; i < dgvUbicacionesActuales.Rows.Count; i++)
            {
                fila = dgvUbicacionesActuales.Rows[i];
                if (Convert.ToBoolean(dgvUbicacionesActuales.Rows[i].Cells[5].Value))
                {
                    ubicacionesAEliminar.Add(dgvUbicacionesActuales.Rows[i].Cells[0].Value.ToString());
                    
                }
                else
                {
                    ubicacionesActuales.Add(dgvUbicacionesActuales.Rows[i].Cells[0].Value.ToString());
                }
            }
        }

        private void btnLimpiarUbicaciones_Click_1(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            ubicacionesAAgregar.Clear();
        }

        private Boolean noSeRepitenFechas()
        {
            return fechasAAgregar.All(fecha => !existeFecha(fecha));
        }

        private Boolean noSeRepitenUbicaciones()
        {
            return ubicacionesAAgregar.All(ubicacion => !existeUbicacion(ubicacion.tipo));
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            cargarFechasAEliminar();
            cargarUbicacionesAEliminar();
            if (noSeRepitenFechas() && noSeRepitenUbicaciones())
            {
                if (fechasActuales.Count == 0)
                {
                    MessageBox.Show("No se puede eliminar la ultima funcion");
                    limpiarListas();
                }
                else
                {
                    deshabilitarUbicaciones();
                    deshabilitarFunciones();
                    insertarFunciones();
                    insertarUbicaciones();
                    modificar();
                    MessageBox.Show("Modificacion realizada");
                    limpiarListas();
                    EditarPublicacion_Load(sender, e);
                }
            }
            else
            {
                if (!noSeRepitenUbicaciones()) MessageBox.Show("Esta intentando crear un conjunto de ubicaciones ya existentes");
                if (!noSeRepitenFechas()) MessageBox.Show("Esta intentando crear funciones con fecha y horario ya existentes");
                ubicacionesAEliminar.Clear();
                ubicacionesActuales.Clear();
                fechasAEliminar.Clear();
                fechasActuales.Clear();
            }
        }

        private char obtenerLetra(int fila)
        {
            Dictionary<int, char> filas = diccionarioFilas();
            return filas[fila];
        }
        private Dictionary<int, char> diccionarioFilas()
        {
            Dictionary<int, char> filas = new Dictionary<int, char>();
            char letra = 'A';
            for (int i = 1; i <= 27; i++)
            {
                filas.Add(i, letra);
                letra++;
            }
            return filas;

        }

        //desglose del conjunto de ubicaciones, y asignacion de letra a cada fila
        private List<UbicacionIndividual> generarUbicacionesIndividuales(List<Ubicacion> ubicaciones)
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

        private void insertarFunciones()
        {
            List<Publicacion> publicaciones = new List<Publicacion>();
            List<Ubicacion> ubicaciones = new List<Ubicacion>();
            for (int i = 0; i < fechasAAgregar.Count; i++)
            {
                Publicacion publicacion = new Publicacion();
                publicacion.descripcion = descripcionTxt.Text;
                publicacion.rubro = rubroTxt.Text;
                publicacion.grado = Convert.ToInt32(gradoTxt.SelectedValue);
                publicacion.estado = Convert.ToInt32(estadoTxt.SelectedValue);
                publicacion.codigo = codigoPublicacion;
                publicaciones.Add(publicacion);
            }
            DataGridViewRow fila = new DataGridViewRow();
            for (int i = 0; i < dgvUbicacionesActuales.Rows.Count; i++)
            {
                fila = dgvUbicacionesActuales.Rows[i];
                Ubicacion ubicacion = new Ubicacion();
                if (!Convert.ToBoolean(dgvUbicacionesActuales.Rows[i].Cells[5].Value))
                {
                    ubicacion.tipo = dgvUbicacionesActuales.Rows[i].Cells[0].Value.ToString();
                    if (dgvUbicacionesActuales.Rows[i].Cells[1].Value.ToString().Equals(""))
                    {
                        ubicacion.tipoId = 0;
                    }
                    else
                    {
                        ubicacion.tipoId = Convert.ToInt32(dgvUbicacionesActuales.Rows[i].Cells[1].Value);
                    }
                    ubicacion.filas = Convert.ToInt32(dgvUbicacionesActuales.Rows[i].Cells[2].Value);
                    ubicacion.asientosPorFila = Convert.ToInt32(dgvUbicacionesActuales.Rows[i].Cells[3].Value);
                    ubicacion.precio = Convert.ToInt32(dgvUbicacionesActuales.Rows[i].Cells[4].Value);
                    ubicaciones.Add(ubicacion);
                }                
            }
            List<UbicacionIndividual> ubicacionesIndividuales = generarUbicacionesIndividuales(ubicaciones);
            
            Conexion.getInstance().InsertarPublicaciones(idEmpresa,publicaciones,fechasAAgregar,ubicacionesIndividuales);
        }

        private void deshabilitarUbicaciones()
        {
            foreach(string tipo in ubicacionesAEliminar)
            {
                foreach (int idPublicacion in idsPublicaciones)
                {
                    Conexion.getInstance().cambiarHabilitacionUbicacion(Conexion.Tabla.Ubicacion,tipo,idPublicacion,"0") ;
                }
            }
        }

        private void deshabilitarFunciones()
        {
            foreach (string fecha in fechasAEliminar)
            {
                Conexion.getInstance().cambiarHabilitacionPublicacion(Conexion.Tabla.Publicacion, Convert.ToInt32(fecha), "0");
            }
        }

        private List<String> obtenerPublicacionesActivas()
        {
            List<String> publicaciones = new List<string>();
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            filtros.Add("Codigo", Conexion.Filtro.Exacto(codigoPublicacion.ToString()));
            filtros.Add("Habilitado", Conexion.Filtro.Exacto("1"));
            DataTable publicacionesActivas = Conexion.getInstance().conseguirTabla(Conexion.Tabla.Publicacion, filtros);
            for (int i = 0; i < publicacionesActivas.Rows.Count; i++)
            {
                publicaciones.Add(publicacionesActivas.Rows[i][0].ToString());
            }
            return publicaciones;
        }


        private void insertarUbicaciones()
        {
            Conexion.getInstance().InsertarUbicacionesNuevas(obtenerPublicacionesActivas(),generarUbicacionesIndividuales(ubicacionesAAgregar));
        }

        public void modificar()
        {
            Dictionary<string,object> modificaciones = new Dictionary<string,object>();
            modificaciones.Add("Descripcion", descripcionTxt.Text.ToString());
            modificaciones.Add("Publicacion_Rubro", rubroTxt.Text.ToString());
            modificaciones.Add("ID_estado", Convert.ToInt32(estadoTxt.SelectedValue));
            modificaciones.Add("Direccion", direccionTxt.Text.ToString());
            modificaciones.Add("ID_grado", Convert.ToInt32(gradoTxt.SelectedValue));
            Conexion.getInstance().ModificarPublicacion(codigoPublicacion, Conexion.Tabla.Publicacion, modificaciones);
        }

        private void ubicacionAsientos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }
    }
}
