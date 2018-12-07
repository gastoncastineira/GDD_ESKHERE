using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet
{
    public static class ConfigurationHelper
    {
        public static string ConnectionString { get { return Properties.PalcoNET.Default.ConnectionString; } }
        public static DateTime fechaActual { get { return Properties.PalcoNET.Default.MyDate; } }
    }
}
