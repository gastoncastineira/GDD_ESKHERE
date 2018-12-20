using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Comprar
{
    public partial class AgregarTarjeta : Form
    {
        int id;
        private Dictionary<string, object> datos = new Dictionary<string, object>();
        public AgregarTarjeta(string idCliente)
        {
            InitializeComponent();
            id = Convert.ToInt32(idCliente);
            this.ControlBox = false;
        }

        private void btnAgregarTarj_Click(object sender, EventArgs e)
        {
            int parsedValue;

            if (!string.IsNullOrWhiteSpace(txtNumero.Text) && int.TryParse(txtNumero.Text, out parsedValue))
            { 
                AgregarParaUpdate("numero_tarjeta_credito", txtNumero.Text);
                //label2.Text = id + txtNumero.Text+" datos " + datos["numero_tarjeta_credito"].ToString() ;
                if (Conexion.getInstance().Modificar(id, Conexion.Tabla.Cliente, datos))
                {
                    MessageBox.Show("Tarjeta guardada correctamente.");
                    DialogResult = DialogResult.OK;
                    
                }
                else { 
                    MessageBox.Show("Fallo la asociacion de tarjeta de credito.");
                    DialogResult = DialogResult.Abort;
                }
            }
            else {
                txtNumero.Text = "";
                MessageBox.Show("Agregue un número válido de tarjeta.");
            }
        }

        private void AgregarParaUpdate(string nombreCol, object data)
        {
            datos[nombreCol] = data;
        }

        private void soloNumerico(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }
    }
}
