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
        public String estado { get; set; }
        public String direccion { get; set; }
        public String grado { get; set; }
        public List<DateTime> funciones { get; set; }
        public List<Ubicacion> ubicaciones {get; set;}

        public Publicacion(){}
    }
}
