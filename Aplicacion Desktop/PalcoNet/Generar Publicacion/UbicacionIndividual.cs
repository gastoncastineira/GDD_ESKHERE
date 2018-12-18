using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Generar_Publicacion
{
    class UbicacionIndividual
    {
        public String tipoDescripcion { get; set; }
        public char fila { get; set; }
        public int asiento { get; set; }
        public decimal precio { get; set; }
        public int ubicacionSinNumerar { get; set; }
        public int tipo { get; set; }
        public int idPublicacion { get; set; }

        public UbicacionIndividual() { }
    }
}
