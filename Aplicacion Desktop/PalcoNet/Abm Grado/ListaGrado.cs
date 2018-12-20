using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Abm_Grado
{
    public partial class ListaGrado : FormTemplate
    {
        public ListaGrado():base()
        {
            InitializeComponent();
        }

        private void MostrarResultado(DialogResult dr)
        {
            if (dr == DialogResult.OK)
                MessageBox.Show("Se actualizó correctamente");
            if (dr == DialogResult.Abort)
                MessageBox.Show("Se encontró un error fatal y se abortó la actualización");
            if (dr == DialogResult.Cancel)
                MessageBox.Show("Se canceló la solicitud");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) && string.IsNullOrEmpty(txtComision.Text))
                MessageBox.Show("Se debe ingresar algun filtro");
            else
            {
                Dictionary<string, string> filtros = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(txtNombre.Text))
                    filtros.Add("descripcion", Conexion.Filtro.Libre(txtNombre.Text));
                if (!string.IsNullOrEmpty(txtComision.Text))
                    filtros.Add("comision", Conexion.Filtro.Exacto(txtComision.Text));

                Conexion.getInstance().LlenarDataGridView(Conexion.Tabla.Grado, ref dgvGrado, filtros);

                btnModificar.Enabled = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //MostrarResultado(new ModificarGrado().ShowDialog());
            MostrarResultado(new ModificarGrado(dgvGrado.SelectedCells[0].OwningRow.Cells).ShowDialog());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MostrarResultado(new AltaGrado().ShowDialog());
        }
    }
}
