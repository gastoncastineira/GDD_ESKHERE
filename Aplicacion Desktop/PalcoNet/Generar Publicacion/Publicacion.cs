using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Generar_Publicacion
{
    public class Publicacion
    {
        public String descripcion { get; set; }
        public String rubro { get; set; }
        public Int32 estado { get; set; }
        public String direccion { get; set; }
        public Int32 grado { get; set; }
        public Int32 codigo { get; set; }
        
        public Publicacion(){}
    }
}
