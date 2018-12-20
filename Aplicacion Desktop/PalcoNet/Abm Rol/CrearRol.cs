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
            if(string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Se debe ingresar un nombre");
                return;
            }
            List<Funcion> funciones = new List<Funcion>();
            for (int i = 1; i <= checkedListBoxFuncion.Items.Count; i++)
            {
                if (checkedListBoxFuncion.GetItemChecked(i))
                {
                    funciones.Add((Funcion)i);
                }
            }
            if(funciones.Count == 0)
            {
                MessageBox.Show("Se debe seleccionar al menos una funcion");
                return;
            }
            Dictionary<string, object> datos = new Dictionary<string, object>();
            datos["nombre"] = txtNombre.Text;
            Conexion.getInstance().Insertar(Conexion.Tabla.Rol, datos);
            datos = new Dictionary<string, object>();
            datos["id_rol"] = Conexion.getInstance().ConsultaPlana(Conexion.Tabla.Rol, new List<string>(new string[] { "SCOPE_IDENTITY() AS id" }), null)["id"][0];
            foreach(int f in funciones)
            {
                datos["ID_funcion"] = f;
                Conexion.getInstance().Insertar(Conexion.Tabla.Rol, datos);
            }
            MessageBox.Show("Rol creado exitosamente");
            foreach (int i in checkedListBoxFuncion.CheckedIndices)
            {
                checkedListBoxFuncion.SetItemCheckState(i, CheckState.Unchecked);
            }
            txtNombre.Text = string.Empty;
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
    }
}
