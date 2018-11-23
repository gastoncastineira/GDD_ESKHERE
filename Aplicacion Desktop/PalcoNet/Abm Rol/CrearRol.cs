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
        public CrearRol()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Login_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                string nombreRol = textBox1.Text;
                //guardar nombre rol

                //chequeo que haya funcionalidades
                if(checkedListBox1.Items.Count > 0)
                {   
                    List<string> funcionalidades = new List<string>();
                    foreach(var item in checkedListBox1.CheckedItems){
	                    //guardo funcionalidades en una lista
                        funcionalidades.Add(item.ToString());
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
