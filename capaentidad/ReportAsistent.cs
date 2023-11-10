using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class ReportAsistent
    {
        public int IdAsistente { get; set; }
        public string TipoAsistente { get; set; }

        public string Nombre_completo { get; set; }
        public int IdEvento { get; set; }
        public string Nombre { get; set; }
        public string  Fecha { get; set; }

        public string rol_evento { get; set; }
        public string Descripcion { get; set; }
    }
}
