using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Generar_Publicacion
{
    public class Ubicacion
    {
        public String tipo { get; set; }
        public int filas { get; set; }
        public int asientosPorFila { get; set; }
        public decimal precio { get; set; }

        public Ubicacion() { }
    }
}
