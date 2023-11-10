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
        public string Nombre_Completo { get; set; }
        public int status { get; set; }
        public int IdUsuario { get; set; }
        public int IdEvento { get; set; }
        public char TipoAsistente { get; set; }
        public string Nombre { get; set; }
        public string edad { get; set; }
        public string direccion { get; set; }
        public string contacto { get; set; }
        public string cedula { get; set; }
        public int id_rol_event { get; set; }
    }
}
