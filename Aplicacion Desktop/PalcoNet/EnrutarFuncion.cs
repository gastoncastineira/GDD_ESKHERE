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
        private int id;
        private string usuario;

        public EnrutarFuncion(int id, string usuario)
        {
            InitializeComponent();
            this.id = id;
            this.usuario = usuario;
        }

        private void EnrutarFuncion_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            filtros.Add("usuario", Conexion.Filtro.Exacto(usuario));
            Dictionary<string, List<object>> resul = Conexion.getInstance().ConsultaPlana(Conexion.Tabla.FuncionesUsuario, new List<string>(new string[] { "nombre_funcion", "funcion_id" }), filtros);
            if (resul["nombre_funcion"].Count > 1)
            {
                cbbSeleccion.DataSource = resul["nombre_funcion"];
                //cosas
            }
            else
            {
                //sacar enum a partir de los id. Usarlo para crear el menubar
            }
        }
    }
}
