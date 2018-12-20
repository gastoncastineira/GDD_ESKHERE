using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Rol
{
    public partial class ModificarRol : Form
    {
        int idRol;
        string nombreOG;
        private List<Funcion> funcionesOriginales = new List<Funcion>();
        private const int MAX_FUNCION = 5;

        public ModificarRol(int id, string nombre)
        {
            idRol = id;
            InitializeComponent();
            nombreOG = nombre;
            txtNombre.Text = nombre;
            if (nombre.ToLower() == "empresa" || nombre.ToLower() == "cliente")
                txtNombre.Enabled = false;
        }

        private void ModificarRol_Load(object sender, EventArgs e)
        {
            Dictionary<string, List<object>> resul = Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Funcion, new List<string>(new string[] {"id", "nombre" }), null);
            //resul["nombre"].ForEach(o => checkedListBoxFuncion.Items.Add(o.ToString(), false));
            Dictionary<string, string> filtros = new Dictionary<string, string>();
            for (int i = 1; i<=resul["nombre"].Count;i++)
            { 
                filtros["id_rol"] = Conexion.Filtro.Exacto(idRol.ToString());
                filtros["id_funcion"] = Conexion.Filtro.Exacto(i.ToString());
                checkedListBoxFuncion.Items.Add(resul["nombre"][i-1], (Conexion.getInstance().existeRegistro(Conexion.Tabla.RolXFuncion, new List<string>(new string[] { "id_rol", "id_funcion" }), filtros)));
            }

            for (int i = 1; i <= checkedListBoxFuncion.Items.Count; i++)
            {
                if (checkedListBoxFuncion.GetItemChecked(i-1))
                {
                    funcionesOriginales.Add((Funcion)i);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Se debe ingresar un nombre");
                return;
            }

                List<Funcion> aBorrar = new List<Funcion>();
                List<Funcion> aInsertar = new List<Funcion>();
                Dictionary<string, string> filtrosFunc = new Dictionary<string, string>();
                //List<string> columnasFunc = new List<string>();
               // columnasFunc.Add("nombre");

               // Dictionary<string, List< object>> resultadoConsulta= Conexion.getInstance().ConsultaPlana(Conexion.Tabla.RolXFuncion, columnasFunc, filtrosFunc);

                for (int i = 0; i < checkedListBoxFuncion.Items.Count; i++)
                {

                    if (checkedListBoxFuncion.GetItemChecked(i) && !funcionesOriginales.Contains((Funcion)i + 1))
                        aInsertar.Add((Funcion)i + 1);
                    if (!checkedListBoxFuncion.GetItemChecked(i) && funcionesOriginales.Contains((Funcion)i + 1))
                        aBorrar.Add((Funcion)i + 1);
                }

                Dictionary<string, object> datos = new Dictionary<string, object>();
                datos["id_rol"] = idRol;

                //if (!Conexion.getInstance().existeRegistro(Conexion.Tabla.RolXFuncion, columnasFunc, filtrosFunc))
                //{
                    foreach (int v in aInsertar)
                    {
                        datos["id_funcion"] = v;
                        if (!Conexion.getInstance().InsertarTablaIntermedia(Conexion.Tabla.RolXFuncion, "id_rol", "id_funcion", idRol, v))
                        {
                            DialogResult = DialogResult.Abort;
                            return;
                        }

                    }
                    foreach (int v in aBorrar)
                    {
                        datos["id_funcion"] = v;
                        if (!Conexion.getInstance().eliminarTablaIntermedia(Conexion.Tabla.RolXFuncion, "id_rol", "id_funcion", idRol, v))
                        {
                            DialogResult = DialogResult.Abort;
                            return;
                        }
                    }
                    DialogResult = DialogResult.OK;
         }


        private void btnRegresar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void checkedListBoxFuncion_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (checkedListBoxFuncion.CheckedItems.Count >= MAX_FUNCION)
            {
                MessageBox.Show("Se excedió del máximo de cinco funciones por rol permitidas");
                e.NewValue = CheckState.Unchecked;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            List<string> columnas = new List<string>();
            columnas.Add("Nombre");
            Dictionary<string, string> filtrosNom = new Dictionary<string, string>();
            filtrosNom.Add("Nombre", Conexion.Filtro.Exacto(txtNombre.Text));
            filtrosNom.Add("Nombre ",Conexion.Filtro.Distinto(nombreOG));

            if (Conexion.getInstance().existeRegistro(Conexion.Tabla.Rol, columnas, filtrosNom))
            {
                MessageBox.Show("Ese rol ya existe. Elija otro o siga usando el mismo.");
                txtNombre.Text = nombreOG;
            }
        }
    }
}
