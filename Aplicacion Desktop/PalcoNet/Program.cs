using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet
{
    static class Program
    {
        public static Form FormInicial { get; set; }
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormInicial = new Abm_Cliente.AltaCliente();
            //FormInicial = new Abm_Cliente.ListadoClientes();
            //FormInicial = new Abm_Empresa_Espectaculo.AltaEmpresa();
            Application.Run(FormInicial);
        }
    }
}
