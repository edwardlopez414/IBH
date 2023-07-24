using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class ReportEvent
    {
        public int IdEvento { get; set; }
        public string Nombre { get; set; }

        public string Fecha { get; set; }
        public string LugarEvento { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }

        public string Usuario { get; set; }
        public string Cargo { get; set; }

        public int Restado { get; set; }
        public string estado { get; set; }
    }
}
