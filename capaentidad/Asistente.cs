using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class Asistente
    {
        public int IdAsistente { get; set; }
        public string PNombre { get; set; }
        public string SNombre { get; set; }
        public string PApellido { get; set; }
        public string SApellido { get; set; }
        public int IdEvento { get; set; }
        public char Sexo { get; set; }
        public char TipoAsistente { get; set; }

    }
}
