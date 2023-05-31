using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaentidad
{
    public class Miembro
    {
        public int IdMiembro { get; set; }
        public string PNombre { get; set; }

        public string SNombre { get; set; }
        public string Papellido { get; set; }
        public string Sapellido { get; set; }
        public int Edad { get; set; }

        public string Telefono { get; set; }
        public string Cargo { get; set; }
        public string Direccion { get; set; }
        public char Sexo { get; set; }
    }
}
