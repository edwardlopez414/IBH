using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class estado_evento
    {
        public int Id_Estado { get; set; }
        public int Id_evento_estado { get; set; }
        public int Id_catalogo { get; set; }

        public DateTime Fecha_estado { get; set; }
    }
}
