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
    public partial class CrearRol : Form
    {
        private const int MAX_FUNCION = 5;
        public CrearRol()
        {
            InitializeComponent();
        }

        private void CrearRol_Load(object sender, EventArgs e)
        {
            Dictionary<string, List<object>> resul = Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Funcion, new List<string>(new string[] { "nombre" }), null);
            resul["nombre"].ForEach(o => checkedListBoxFuncion.Items.Add(o.ToString(), false));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Se debe ingresar un nombre");
                return;
            }


            List<string> columnas = new List<string>();
            columnas.Add("Nombre");
            Dictionary<string, string> filtrosNom = new Dictionary<string, string>();
            filtrosNom.Add("Nombre", Conexion.Filtro.Exacto(txtNombre.Text));

            if (!Conexion.getInstance().existeRegistro(Conexion.Tabla.Rol, columnas, filtrosNom))
            {
                List<Funcion> funciones = new List<Funcion>();
                for (int i = 0; i < checkedListBoxFuncion.Items.Count; i++)
                {
                    if (checkedListBoxFuncion.GetItemChecked(i))
                    {
                        funciones.Add((Funcion)i + 1);
                    }
                }
                if (funciones.Count == 0)
                {
                    MessageBox.Show("Se debe seleccionar al menos una funcion");
                    return;
                }
                Dictionary<string, object> datos = new Dictionary<string, object>();
                datos["nombre"] = txtNombre.Text;
                int idinsertada = Conexion.getInstance().Insertar(Conexion.Tabla.Rol, datos);
                foreach (int f in funciones)
                    Conexion.getInstance().InsertarTablaIntermedia(Conexion.Tabla.RolXFuncion, "id_rol", "id_funcion", idinsertada, f);
                MessageBox.Show("Rol creado exitosamente");
                foreach (int i in checkedListBoxFuncion.CheckedIndices)
                {
                    checkedListBoxFuncion.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
            else
            {
                MessageBox.Show("Ese rol ya existe.");
                txtNombre.Text = string.Empty;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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

        private void btnLimpia_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
        }
    }
}
