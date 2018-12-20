using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet
{
    public partial class EnrutarFuncion : Form
    {
        private string rolSeleccionado;
        private string usuario;
        private int idCliente;
        List<Funcion> funcion;
        private bool flag = false;

        public EnrutarFuncion(string rolSeleccionado, string usuario)
        {
            InitializeComponent();
            this.rolSeleccionado = rolSeleccionado;
            this.usuario = usuario;
        }

        private void enrutar(int index)
        {
            if (!flag)
                return;
            switch (funcion[index])
            {
                case Funcion.ABM_CLIENTE:
                    new Abm_Cliente.ListadoClientes().Show();
                    break;
                case Funcion.ABM_EMPRESA:
                    new Abm_Empresa_Espectaculo.ListadoEmpresas().Show();
                    break;
                case Funcion.ABM_GRADO:
                    new Abm_Grado.ListaGrado().Show();
                    break;
                case Funcion.CANJE_DE_PUNTOS:
                    new Canje_Puntos.Canje_Puntos(idCliente).Show();
                    break;
                case Funcion.COMPRAR:
                    new Comprar.Comprar(usuario).Show();
                    break;
                case Funcion.EDITAR_PUBLICACION:
                    //new Editar_Publicacion.EditarPublicacion().Show();
                    break;
                case Funcion.GENERAR_PUBLICACION:
                    new Generar_Publicacion.GenerarPublicacion().Show();
                    break;
                case Funcion.GENERAR_RENDICION_COMISIONES:
                    new Generar_Rendicion_Comisiones.Rendicion().Show();
                    break;
                case Funcion.HISTORIAL_COMPRAS:
                    //new Historial_Cliente.ListadoDeCompras().Show;
                    break;
                case Funcion.LISTADO_ESTADISTICO:
                    new Listado_Estadistico.ListadoEstadistico().Show();
                    break;
                case Funcion.ABM_ROL:
                    new Abm_Rol.ListadoRoles().Show();
                    break;
            }
            flag = false;
            Close();
        }

        private void EnrutarFuncion_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            filtros.Add("usuario", Conexion.Filtro.Exacto(usuario));
            filtros.Add("nombre_rol", Conexion.Filtro.Exacto(rolSeleccionado));
            Dictionary<string, List<object>> resul = Conexion.getInstance().ConsultaPlana(Conexion.Tabla.FuncionesUsuarios, new List<string>(new string[] { "nombre_funcion", "funcion_id" }), filtros);
            funcion = resul["funcion_id"].Cast<Funcion>().ToList();
            
            //me cazo el id del cliente con el usuario
            List<string> columnas = new List<string>();
            columnas.Add("idCliente");
            columnas.Add("nombreUsr");

            Dictionary<string, string> filtrosUsr = new Dictionary<string, string>();
            filtrosUsr.Add("nombreUsr", Conexion.Filtro.Exacto(usuario));
            Dictionary<string, List<object>> resultadoConsulta = (Conexion.getInstance().ConsultaPlana(Conexion.Tabla.idDelCliente, columnas, filtrosUsr));
            idCliente = Convert.ToInt32(resultadoConsulta["idCliente"][0].ToString());

            FormTemplate.idCliente = idCliente;  
            FormTemplate.Funciones = funcion;
            FormTemplate.usuario = usuario;


            if (resul["nombre_funcion"].Count > 1)
            {
                MessageBox.Show("Se detecto que tiene mas de una funcion asignada. Por favor, elija a la que desea ingresar");
                cbbSeleccion.DataSource = resul["nombre_funcion"];
                cbbSeleccion.SelectedIndex = -1;
            }
            else
            {
                enrutar(0);
            }
            flag = true;
        }

        private void cbbSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            enrutar(cbbSeleccion.SelectedIndex);
        }

        private void EnrutarFuncion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(flag)
                Program.FormInicial.Show();
        }
    }
}
