using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PalcoNet
{
    public partial class FormTemplate : Form
    {
        private bool flag = false;
        public static List<Funcion> Funciones { get; set; }
        public static string usuario { get; set; }
        public static int idCliente { get; set; }
        public static bool isAdmin { get; set; }
        public FormTemplate()
        {
            InitializeComponent();

            foreach (Funcion f in Funciones.Distinct().ToList())
            {
                ToolStripMenuItem item;
                switch (f)
                {
                    case Funcion.ABM_CLIENTE:
                        item = new ToolStripMenuItem("ABM Cliente");
                        item.Click += ABM_Cliente_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.ABM_EMPRESA:
                        item = new ToolStripMenuItem("ABM Empresa");
                        item.Click += ABM_Empresa_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.ABM_GRADO:
                        item = new ToolStripMenuItem("ABM Grado");
                        item.Click += ABM_Grado_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.ABM_ROL:
                        item = new ToolStripMenuItem("ABM Rol");
                        item.Click += ABM_Rol_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.CANJE_DE_PUNTOS:
                        item = new ToolStripMenuItem("Canje de puntos");
                        item.Click += CanjePuntos_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.COMPRAR:
                        item = new ToolStripMenuItem("Comprar");
                        item.Click += Comprar_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.EDITAR_PUBLICACION:
                        item = new ToolStripMenuItem("Editar Publicacion");
                        item.Click += Editar_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.GENERAR_PUBLICACION:
                        item = new ToolStripMenuItem("Generar Publicacion");
                        item.Click += GenerarPublicacion_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.GENERAR_RENDICION_COMISIONES:
                        item = new ToolStripMenuItem("Generar rendicion");
                        item.Click += Rendicion_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.HISTORIAL_COMPRAS:
                        item = new ToolStripMenuItem("historial de compras");
                        item.Click += Historial_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                    case Funcion.LISTADO_ESTADISTICO:
                        item = new ToolStripMenuItem("Listado estadistico");
                        item.Click += ListadoEstadistico_Click;
                        verToolStripMenuItem.DropDownItems.Add(item);
                        break;
                }
            }
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            Program.FormInicial.Show();
        }

        private void ABM_Cliente_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new Abm_Cliente.ListadoClientes().Show();
        }

        private void ABM_Empresa_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new Abm_Empresa_Espectaculo.ListadoEmpresas().Show();
        }

        private void ABM_Rol_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new Abm_Rol.ListadoRoles().Show();
        }

        private void ABM_Grado_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new Abm_Grado.ListaGrado().Show();
        }

        private void CanjePuntos_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new Canje_Puntos.Canje_Puntos(idCliente).Show();
        }

        private void Comprar_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();          
            new Comprar.Comprar(usuario).Show();
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new Editar_Publicacion.SeleccionarPublicacion(idCliente).Show();
        }

        private void GenerarPublicacion_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new Generar_Publicacion.GenerarPublicacion(idCliente).Show();
        }

        private void Rendicion_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new Generar_Rendicion_Comisiones.Rendicion().Show();
        }

        private void Historial_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new Historial_Cliente.ListadoDeCompras(idCliente).Show();
        }

        private void ListadoEstadistico_Click(object sender, EventArgs e)
        {
            flag = true;
            Close();
            new Listado_Estadistico.ListadoEstadistico().Show();
        }

        private void FormTemplate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!flag)
                Program.FormInicial.Show();
            flag = false;
        }
    }
}
