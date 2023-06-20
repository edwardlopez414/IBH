using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class Miembro
    {
        public string Direccion { get; set; }
        public int Edad { get; set; }

        public string Email { get; set; }
        public string Fecha_bautismo { get; set; }
        public string Fecha_ingreso { get; set; }
        public int Id_Usuario { get; set; }

        public string Nombre_Completo { get; set; }
        public string Nro_contacto { get; set; }
        public string Sexo { get; set; }
        public char IDDatosuser { get; set; }

        public string usuario { get; set; }
        public string contrasena { get; set; }
        public int Id_rol { get; set; }
        public int activo { get; set; }
    }
}
